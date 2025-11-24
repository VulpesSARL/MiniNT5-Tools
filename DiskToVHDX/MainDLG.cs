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
using DiscUtils.Vhdx;

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
                    lstDisks.Items.Add(new DiskInfoSTUB() { DI = kvp.Value });
                }

                if (lstDisks.Items.Count != 0)
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
            txtVHDXFile.Text = cmdlg.FileName;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (lstDisks.SelectedIndex == -1)
            {
                MessageBox.Show(this, "No disk is selected.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVHDXFile.Text) == true)
            {
                MessageBox.Show(this, "VHDX filename is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Fox.Common.Utilities.IsValidPath(txtVHDXFile.Text) == false)
            {
                MessageBox.Show(this, "The VHDX filename is invalid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SelectedDisk = (DiskInfoSTUB)lstDisks.SelectedItem;
            cmdStart.Enabled = false;
            cmdCancel.Enabled = true;
            panel1.Enabled = false;
            BGW.RunWorkerAsync();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to cancel?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            CancelOp = true;
        }

        private void MainDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BGW.IsBusy == true)
                e.Cancel = true;
        }

        private void BGW_DoWork(object sender, DoWorkEventArgs e)
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

                using (Stream vhdxStream = File.Open(txtVHDXFile.Text, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (Disk disk = Disk.InitializeDynamic(vhdxStream, DiscUtils.Streams.Ownership.None, SelectedDisk.DI.Size))
                    {
                        using (Stream sourceStream = new FileStream(Fox.Common.Utilities.OpenWithSafeHandle_RO("\\\\.\\PhysicalDrive" + SelectedDisk.DI.Number), FileAccess.Read))
                        {
                            int read = (int)BufferSize;
                            for (Int64 i = 0; i < SelectedDisk.DI.Size; i += read)
                            {
                                read = sourceStream.Read(buffer, 0, (int)BufferSize);
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
                Fox.Common.Utilities.MessageBoxInvoke(this, "SEH: " + ee.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            UpdateStatus(0, 1);
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmdStart.Enabled = true;
            cmdCancel.Enabled = false;
            panel1.Enabled = true;
        }
    }
}
