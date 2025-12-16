using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscUtils;
using DiscUtils.Vhdx;
using Fox.Common;
using Disk = DiscUtils.Vhdx.Disk;
using FoxDisk = Fox.Common.Disk;

namespace FoxDiskToVHDX
{
    public partial class MainDLG : Form
    {
        const Int64 BufferSize = 1 * 1024 * 1024;
        bool CancelOp = false;
        DiskInfoSTUB SelectedDisk;

        public class DiskInfoSTUB
        {
            public Fox.Common.Disk.DiskInfo DI;
            public override string ToString()
            {
                return (DI.Name);
            }
        }

        delegate void MyUpdateStatusBarOnly(int ProgressValue, int ProgressMax);

        public void UpdateStatus(int ProgressValue, int ProgressMax)
        {
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(new MyUpdateStatusBarOnly(UpdateStatus), ProgressValue, ProgressMax);
                return;
            }
            if (progressb.Maximum != ProgressMax)
                progressb.Maximum = ProgressMax;
            if (progressb.Value != ProgressValue)
                progressb.Value = ProgressValue;
        }


        public MainDLG()
        {
            InitializeComponent();
        }

        private void MainDLG_Load(object sender, EventArgs e)
        {
            DiscUtils.Containers.SetupHelper.SetupContainers();

            cmdCancel.Enabled = false;
            int Counter = 0;
            do
            {
                if (Counter > 5)
                    break;

                foreach (KeyValuePair<string, Fox.Common.Disk.DiskInfo> kvp in Fox.Common.Disk.GetDisks2())
                {
                    lstDisksRead.Items.Add(new DiskInfoSTUB() { DI = kvp.Value });
                    lstDisksWrite.Items.Add(new DiskInfoSTUB() { DI = kvp.Value });
                }

                if (lstDisksRead.Items.Count != 0)
                    break;
                else
                    Thread.Sleep(500);

                Counter++;
            } while (true);
        }

        private void cmdBrowseVHDX_Click(object sender, EventArgs e)
        {
            SaveFileDialog cmdlg = new SaveFileDialog();
            cmdlg.Title = "Save VHDX file";
            cmdlg.Filter = "VHDX file|*.vhdx";
            cmdlg.DefaultExt = ".vhdx";
            cmdlg.OverwritePrompt = true;
            if (cmdlg.ShowDialog(this) != DialogResult.OK)
                return;
            txtVHDXFileWrite.Text = cmdlg.FileName;
        }

        private void cmdBrowseVHDXRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog cmdlg = new OpenFileDialog();
            cmdlg.Title = "Read from VHDX file";
            cmdlg.Filter = "VHDX file|*.vhdx";
            cmdlg.DefaultExt = ".vhdx";
            cmdlg.CheckFileExists = true;
            if (cmdlg.ShowDialog(this) != DialogResult.OK)
                return;
            txtVHDXFileRead.Text = cmdlg.FileName;
        }

        private void cmdStartReadDisk_Click(object sender, EventArgs e)
        {
            if (lstDisksRead.SelectedIndex == -1)
            {
                MessageBox.Show(this, "No disk is selected.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVHDXFileWrite.Text) == true)
            {
                MessageBox.Show(this, "VHDX filename is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Fox.Common.Utilities.IsValidPath(txtVHDXFileWrite.Text) == false)
            {
                MessageBox.Show(this, "The VHDX filename is invalid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SelectedDisk = (DiskInfoSTUB)lstDisksRead.SelectedItem;
            cmdCancel.Enabled = true;
            tabControl1.Enabled = false;
            BGW_D_to_VHDX.RunWorkerAsync();
        }

        private void cmdStartWriteDisk_Click(object sender, EventArgs e)
        {
            if (lstDisksWrite.SelectedIndex == -1)
            {
                MessageBox.Show(this, "No disk is selected.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVHDXFileRead.Text) == true)
            {
                MessageBox.Show(this, "VHDX filename is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Utilities.IsValidPath(txtVHDXFileRead.Text) == false)
            {
                MessageBox.Show(this, "The VHDX filename is invalid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SelectedDisk = (DiskInfoSTUB)lstDisksWrite.SelectedItem;
            if (MessageBox.Show(this, "WARNING: ALL DATA WILL BE ERASED on disk\n\n" + SelectedDisk.DI.Name + "\n\nDo you really want to continue???", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            cmdCancel.Enabled = true;
            tabControl1.Enabled = false;
            BGW_VHDX_to_D.RunWorkerAsync();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to cancel?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            CancelOp = true;
        }

        private void MainDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BGW_D_to_VHDX.IsBusy == true || BGW_VHDX_to_D.IsBusy == true)
                e.Cancel = true;
        }

        private void BGW_D_to_VHDX_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[BufferSize];
            Int64 Divider = 1;
            Int64 LastUIUpdate = 0;
            
            while (true)
            {
                if (SelectedDisk.DI.Size / Divider > 1024 * 1024)
                {
                    Divider *= 1024;
                }
                else
                {
                    break;
                }
            }

            try
            {
                CancelOp = false;

                using (Stream vhdxStream = File.Open(txtVHDXFileWrite.Text, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (Disk disk = Disk.InitializeDynamic(vhdxStream, DiscUtils.Streams.Ownership.None, SelectedDisk.DI.Size))
                    {
                        using (Stream sourceStream = new FileStream(Utilities.OpenWithSafeHandle_RO("\\\\.\\PhysicalDrive" + SelectedDisk.DI.Number), FileAccess.Read))
                        {
                            int read = (int)BufferSize;
                            for (Int64 i = 0; i < SelectedDisk.DI.Size; i += read)
                            {
                                //reset SZ
                                read = (int)BufferSize;

                                if (i + BufferSize > SelectedDisk.DI.Size)
                                {
                                    read = (int)(SelectedDisk.DI.Size - i);
                                    if (read < 1)
                                        break;
                                }

                                read = sourceStream.Read(buffer, 0, read);
                                if (read == 0)
                                    break;
                                bool AllNull = true;
                                for (int j = 0; j < read; j++)
                                {
                                    if (buffer[j] != 0)
                                    {
                                        AllNull = false;
                                        break;
                                    }
                                }

                                if (AllNull == false)
                                {
                                    disk.Content.Write(buffer, 0, read);
                                }
                                else
                                {
                                    disk.Content.Seek(read, SeekOrigin.Current);
                                }

                                if (i - LastUIUpdate >= 100 * BufferSize)
                                {
                                UpdateStatus((int)(i / Divider), (int)(SelectedDisk.DI.Size / Divider));
                                    LastUIUpdate = i;
                                }

                                if (CancelOp == true)
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                Utilities.MessageBoxInvoke(this, "SEH: " + ee.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            UpdateStatus(0, 1);
        }

        private void BGW_VHDX_to_D_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[BufferSize];
            Int64 Divider = 1;
            Int64 LastUIUpdate = 0;

            while (true)
            {
                if (SelectedDisk.DI.Size / Divider > 1024 * 1024)
                {
                    Divider *= 1024;
                }
                else
                {
                    break;
            }
            }

            //we need to check the sizes first!
            try
            {
                using (VirtualDisk vhdxdisk = VirtualDisk.OpenDisk(txtVHDXFileRead.Text, FileAccess.Read))
                {
                    if (vhdxdisk.Content.Length > SelectedDisk.DI.Size)
                    {
                        Utilities.MessageBoxInvoke(this, "Destination disk is too small!\nDest: " + FileTools.MakeNiceSize(SelectedDisk.DI.Size) + "\nVHDX: " + FileTools.MakeNiceSize(vhdxdisk.Content.Length), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                Utilities.MessageBoxInvoke(this, "SEH: " + ee.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //on Windows NT, we need to "clean" the disk first, to allow full access to the disk to write
            //otherweise, it won't let me mess on partiton tables, and FS, if files are locked
            Int64 diskres = FoxDisk.CleanPartitions(SelectedDisk.DI.UID);
            if (diskres != 0)
            {
                Utilities.MessageBoxInvoke(this, "Failed to clean disk: 0x" + diskres.ToString("X"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                CancelOp = false;

                using (Stream destStream = new FileStream(Utilities.OpenWithSafeHandle_RW("\\\\.\\PhysicalDrive" + SelectedDisk.DI.Number), FileAccess.ReadWrite))
                {
                    using (VirtualDisk vhdxdisk = VirtualDisk.OpenDisk(txtVHDXFileRead.Text, FileAccess.Read))
                    {
                        int read = (int)BufferSize;
                        for (Int64 i = 0; i < vhdxdisk.Content.Length; i += read)
                        {
                            //reset SZ
                            read = (int)BufferSize;

                            if (i + BufferSize > vhdxdisk.Content.Length)
                            {
                                read = (int)(vhdxdisk.Content.Length - i);
                                if (read < 1)
                                    break;
                            }

                            read = vhdxdisk.Content.Read(buffer, 0, read);
                            if (read == 0)
                                break;

                            destStream.Write(buffer, 0, read);

                            if (i - LastUIUpdate >= 100 * BufferSize)
                            {
                                UpdateStatus((int)(i / Divider), (int)(vhdxdisk.Content.Length / Divider));
                                LastUIUpdate = i;
                            }

                            if (CancelOp == true)
                                break;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                Utilities.MessageBoxInvoke(this, "SEH: " + ee.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (CancelOp == false)
            {
                //refresh the disk status on Windows NT
                //this causes the system to reload the entire disk & may be mountable

                diskres = FoxDisk.RefreshDiskData(SelectedDisk.DI.UID);
                if (diskres != 0)
                {
                    Utilities.MessageBoxInvoke(this, "Failed to refresh disk: 0x" + diskres.ToString("X"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            UpdateStatus(0, 1);
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmdCancel.Enabled = false;
            tabControl1.Enabled = true;
        }
    }
}
