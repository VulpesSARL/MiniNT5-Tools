using Fox;
using Fox.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace FoxMultiWIM
{
    public partial class MainDLG : Form
    {
        public class DiskInfo
        {
            public string UID;
            public string Name;
            public override string ToString()
            {
                return (Name);
            }
        }

        uint SelectedEditionIndex = 0;
        bool Running = false;
        BackgroundWorker bg;

        delegate void MyUpdateStatus(bool EnableGrp1, bool EnableGrp2, int ProgressValue, string ProgressText);
        delegate void MyUpdateStatusBarOnly(int ProgressValue);
        delegate void MyUpdateText(string Text);

        public void UpdateStatus(int ProgressValue)
        {
            this.BeginInvoke(new MyUpdateStatusBarOnly(UpdateMethod), ProgressValue);
        }

        public void UpdateMethod(int ProgressValue)
        {
            if (ProgressValue != -1)
                progressBar.Value = ProgressValue;
        }

        public void UpdateText(string Text)
        {
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(new MyUpdateText(UpdateText), Text);
                return;
            }
            lblFileStatus.Text = Text;
        }

        public void UpdateMethod(bool EnableGrp1, bool EnableGrp2, int ProgressValue, string ProgressText)
        {
            tabControl1.Enabled = EnableGrp1;
            grpStatus.Enabled = EnableGrp2;
            if (ProgressValue != -1)
                progressBar.Value = ProgressValue;
            if (ProgressText != "")
                lblFileStatus.Text = ProgressText;
        }

        public MainDLG()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog cmdlg = new OpenFileDialog();
            cmdlg.Title = "Select WIM File";
            cmdlg.Multiselect = false;
            cmdlg.Filter = "WIM File|*.wim";
            cmdlg.CheckFileExists = true;
            cmdlg.SupportMultiDottedExtensions = true;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtSourceWIMFile.Text = cmdlg.FileName;
        }

        private void cmdSelectEdition_Click(object sender, EventArgs e)
        {
            frmSelectEdition frm = new frmSelectEdition(txtSourceWIMFile.Text);
            if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            SelectedEditionIndex = frm.SelectedIndex;
            lblEdition.Text = frm.SelectedString;
        }

        private void cmdBrowseTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cmdlg = new FolderBrowserDialog();
            cmdlg.ShowNewFolderButton = false;
            cmdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtTarget.Text = cmdlg.SelectedPath;
            txtInstallTempDir.Text = cmdlg.SelectedPath;
        }

        private void txtWIMFile_TextChanged(object sender, EventArgs e)
        {
            SelectedEditionIndex = 0;
            lblEdition.Text = "<Select Edition>";
        }

        private string GetComputerModelName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count > 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    return ((mo["Manufacturer"].ToString().Trim() + " " + mo["Model"].ToString().Trim()).Trim());
                }
            }
            return ("");
        }

        private string GetComputerSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count > 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    return (mo["SerialNumber"].ToString().Trim());
                }
            }
            return ("");
        }

        private void MainDLG_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToScreen();
            if (Fox.FoxCWrapperDISM.DISMInit() != 0)
            {
                MessageBox.Show(this, "Cannot init DISM", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            Program.ExcludeFiles = new List<string>();
            Program.ExcludeFiles.Add("\\$ntfs.log");
            Program.ExcludeFiles.Add("\\hiberfil.sys");
            Program.ExcludeFiles.Add("\\pagefile.sys");
            Program.ExcludeFiles.Add("\\swapfile.sys");
            Program.ExcludeFiles.Add("\\bootmgr");
            Program.ExcludeFiles.Add("\\bootnxt");
            Program.ExcludeFiles.Add("\\boot\\*");
            Program.ExcludeFiles.Add("\\System Volume Information\\*");
            Program.ExcludeFiles.Add("\\Recycler\\*");
            Program.ExcludeFiles.Add("\\$Recycle.Bin\\*");
            Program.ExcludeFiles.Add("\\Windows\\CSC\\*");
            Program.ExcludeFiles.Add("\\Windows\\Temp\\*");
            Program.ExcludeFiles.Add("\\Windows\\Logs\\*");
            Program.ExcludeFiles.Add("\\Windows\\SoftwareDistribution\\Download\\*");

            lstCompression.Items.Add("none");
            lstCompression.Items.Add("XPRESS");
            lstCompression.Items.Add("LZX");
            lstCompression.SelectedIndex = 2;

            chkExcludeFiles.Checked = true;
            chkExcludeFiles_CheckedChanged(sender, e);

            SelectedEditionIndex = 0;
            lblEdition.Text = "<Select Edition>";
            lblFileStatus.Text = "";
            grpStatus.Enabled = false;
            Fox.FoxCWrapperDISM.OnError += FoxCWrapper_OnError;
            Fox.FoxCWrapperDISM.OnFileStatus += FoxCWrapper_OnFileStatus;
            Fox.FoxCWrapperDISM.OnInfo += FoxCWrapper_OnInfo;
            Fox.FoxCWrapperDISM.OnPercentStatus += FoxCWrapper_OnPercentStatus;
            Fox.FoxCWrapperDISM.OnRetry += FoxCWrapper_OnRetry;
            Fox.FoxCWrapperDISM.OnWarning += FoxCWrapper_OnWarning;
            Fox.FoxCWrapperDISM.OnFileProcess += FoxCWrapperDISM_OnFileProcess;
            Fox.Common.Disk.OnUpdateStatus += Disk_OnUpdateStatus;
#if !DEBUG
            chkNoApplySec.Visible = false;
#endif
            lstDiskSchema.Items.Add("Legacy MBR partition style");
            lstDiskSchema.Items.Add("EFI GPT partition style");
            if (Fox.FoxCWrapper.IsFirmwareLEGACY() == true)
            {
                lstDiskSchema.SelectedIndex = 0;
                lstDiskSchema.Items[0] += " (this machine)";
            }
            if (Fox.FoxCWrapper.IsFirmwareEFI() == true)
            {
                lstDiskSchema.SelectedIndex = 1;
                lstDiskSchema.Items[1] += " (this machine)";
            }

            foreach (KeyValuePair<string, string> kvp in Disk.GetDisks())
            {
                lstDisks.Items.Add(new DiskInfo() { Name = kvp.Value, UID = kvp.Key });
            }

            string EmptyDisk = Disk.GetEmptyDiskUID();
            if (string.IsNullOrWhiteSpace(EmptyDisk) == false)
            {
                for (int i = 0; i < lstDisks.Items.Count; i++)
                {
                    DiskInfo di = lstDisks.Items[i] as DiskInfo;
                    if (di.UID == EmptyDisk)
                    {
                        lstDisks.SelectedIndex = i;
                        break;
                    }
                }
            }

            lstDestination.Items.Add("To disk");
            lstDestination.Items.Add("To folder");
            lstDestination.SelectedIndex = 0;

            chkInstallBootLoader.Checked = true;
            cmdPatchOptions.Enabled = chkPrePatch.Checked;

            if (Fox.FoxCWrapper.SetToken() == false)
            {
                MessageBox.Show(this, "Setting tokens failed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            /*
            List<List<string>> TXTRecs = Fox.FoxCWrapper.DNSQueryTXT("vulpes.lu");
            if (TXTRecs == null)
            {
                MessageBox.Show(this, "DNS TXT == null.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string txts = "";
                foreach (List<string> txt in TXTRecs)
                {
                    txts += "=======\n";
                    foreach (string stxt in txt)
                    {
                        txts += "* " + stxt + "\n";
                    }
                }
                MessageBox.Show(this, "DNS Result:\n" + txts, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            BrandingDNSDecoder.DecodeBranding(Fox.FoxCWrapper.DNSQueryTXT("minint-branding.my-vulpes-config.lu"));

            if (BrandingDNSDecoder.ValidData == false)
                frmPatchOptions.ApplyBranding = false;

            frmPatchOptions.ModelName = GetComputerModelName();
            frmPatchOptions.SerialNumber = GetComputerSerialNumber();
        }

        private void Disk_OnUpdateStatus(string Text)
        {
            UpdateText(Text);
        }

        bool FoxCWrapperDISM_OnFileProcess(string A_0)
        {
            if (chkExcludeFiles.Checked == false)
                return (true);
            return (Program.TestFilenamePattern(txtSource.Text, A_0));
        }

        void FoxCWrapper_OnWarning(uint A_0)
        {
        }

        void FoxCWrapper_OnRetry(uint A_0)
        {
        }

        void FoxCWrapper_OnPercentStatus(int A_0)
        {
            this.BeginInvoke(new MyUpdateStatus(UpdateMethod), false, true, A_0, "");
        }

        void FoxCWrapper_OnInfo(uint A_0)
        {
        }

        void FoxCWrapper_OnFileStatus(string A_0)
        {
            this.BeginInvoke(new MyUpdateStatus(UpdateMethod), false, true, -1, A_0);
        }

        void FoxCWrapper_OnError(uint A_0)
        {
            Win32Exception ex = new Win32Exception((int)A_0);
            Utilities.MessageBoxInvoke(this, "An error occured (" + A_0.ToString() + ")\n" + ex.ToString(),
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void MainDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Running == true)
            {
                e.Cancel = true;
                return;
            }
            Fox.FoxCWrapperDISM.DISMShutdown();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to cancel?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                Fox.FoxCWrapperDISM.CancelWIM = true;
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (SelectedEditionIndex == 0)
            {
                MessageBox.Show(this, "Select an edition", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            switch (lstDestination.SelectedIndex)
            {
                case 0:
                    if (lstDisks.SelectedIndex < 0)
                    {
                        MessageBox.Show(this, "Select a disk where to store the installation", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (lstDiskSchema.SelectedIndex < 0)
                    {
                        MessageBox.Show(this, "Select a partition schema that matches the destination installation", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    DiskInfo disk = lstDisks.SelectedItem as DiskInfo;
                    Int64? Allocated = Disk.GetAllocSize(disk.UID);
                    if (Allocated == null)
                    {
                        MessageBox.Show(this, "Cannot query disk status", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (Allocated.Value > 0)
                    {
                        if (MessageBox.Show(this, "WARNING: the selected disk seems to have data on it. Do you want to continue?\n\nALL DATA ON THIS DISK WILL BE ERASED!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                            return;
                    }
                    bg = new BackgroundWorker();
                    bg.WorkerSupportsCancellation = false;
                    bg.DoWork += bg_DoWork_AutoPartitionInstall;
                    bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                    grpStatus.Enabled = true;
                    tabControl1.Enabled = false;
                    bg.RunWorkerAsync();
                    break;
                case 1:
                    if (Directory.Exists(txtInstallTempDir.Text) == false)
                    {
                        MessageBox.Show(this, "The Temp directory must exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
#if DEBUG
                    Fox.FoxCWrapperDISM.DontApplySecurity = chkNoApplySec.Checked;
#endif
                    Fox.FoxCWrapperDISM.SetTempDir(txtInstallTempDir.Text);
                    bg = new BackgroundWorker();
                    bg.WorkerSupportsCancellation = false;
                    bg.DoWork += bg_DoWork_Install;
                    bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                    grpStatus.Enabled = true;
                    tabControl1.Enabled = false;
                    bg.RunWorkerAsync();
                    break;
            }
        }

        private void bg_DoWork_AutoPartitionInstall(object sender, DoWorkEventArgs e)
        {
            try
            {
                Running = true;
                UpdateText("Enabling Automounter");
                FoxCWrapper.EnableAutoMount(true);
                UpdateText("Creating partitions and filesystems");
                DiskInfo disk = lstDisks.SelectedItem as DiskInfo;
                string BootDrive;
                string SystemDrive;

                Int64 res = Disk.CreatePartitions(disk.UID, lstDiskSchema.SelectedIndex, out BootDrive, out SystemDrive);
                if (res != 0)
                {
                    Utilities.MessageBoxInvoke(this, "Failed create partitions / filesystems: 0x" + res.ToString("X"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                txtTarget.Text = SystemDrive + ":\\";
                txtInstallTempDir.Text = SystemDrive + ":\\";

                Fox.FoxCWrapperDISM.SetTempDir(txtInstallTempDir.Text);

                if (Fox.FoxCWrapperDISM.WIMApplyImage(txtSourceWIMFile.Text, SelectedEditionIndex, txtTarget.Text) != 0)
                {
                    Utilities.MessageBoxInvoke(this, "Failed to Apply WIM File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (chkInstallBootLoader.Checked == true)
                {
                    UpdateText("Installing Bootloader");
                    Process proc = new Process();
                    proc.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%systemroot%\\system32\\bcdboot.exe");
                    switch (lstDiskSchema.SelectedIndex)
                    {
                        case 0:
                            proc.StartInfo.Arguments = SystemDrive + ":\\Windows /s " + BootDrive + ": /f BIOS";
                            break;
                        case 1:
                            proc.StartInfo.Arguments = SystemDrive + ":\\Windows /s " + BootDrive + ": /f UEFI";
                            break;
                    }
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    try
                    {
                        proc.Start();
                        proc.WaitForExit();
                        if (proc.ExitCode != 0)
                        {
                            Utilities.MessageBoxInvoke(this, "Installing bootloader may not succeed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    catch
                    {
                        Utilities.MessageBoxInvoke(this, "Cannot install bootloader", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (chkPrePatch.Checked == true)
                {
                    UpdateText("Patching Windows installation");
                    res = frmPatchOptions.PatchWindows(txtTarget.Text);
                    if (res != 0)
                    {
                        Utilities.MessageBoxInvoke(this, "Failed patch Windows 0x" + res.ToString("X"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            catch (Exception ee)
            {
                Utilities.MessageBoxInvoke(this, "SEH: " + ee.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblFileStatus.Text = "";
            progressBar.Value = 0;
            grpStatus.Enabled = false;
            tabControl1.Enabled = true;
            Running = false;
        }

        void bg_DoWork_Install(object sender, DoWorkEventArgs e)
        {
            Running = true;
            if (Fox.FoxCWrapperDISM.WIMApplyImage(txtSourceWIMFile.Text, SelectedEditionIndex, txtTarget.Text) != 0)
            {
                Utilities.MessageBoxInvoke(this, "Failed to Apply WIM File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (chkPrePatch.Checked == true)
            {
                UpdateText("Patching Windows installation");
                Int64 res = frmPatchOptions.PatchWindows(txtTarget.Text);
                if (res != 0)
                {
                    Utilities.MessageBoxInvoke(this, "Failed patch Windows 0x" + res.ToString("X"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        void bg_DoWork_Capture(object sender, DoWorkEventArgs e)
        {
            Running = true;
            DISMCompressionMethod compression;
            switch (lstCompression.SelectedIndex)
            {
                case 1:
                    compression = DISMCompressionMethod.fast;
                    break;
                case 2:
                    compression = DISMCompressionMethod.max;
                    break;
                default:
                    compression = DISMCompressionMethod.none;
                    break;
            }
            if (Fox.FoxCWrapperDISM.WIMCaptureImage(txtDestWIM.Text, txtSource.Text, compression) != 0)
            {
                MessageBox.Show(this, "Failed to capture WIM File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cmdBrowseTempDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cmdlg = new FolderBrowserDialog();
            cmdlg.ShowNewFolderButton = false;
            cmdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtInstallTempDir.Text = cmdlg.SelectedPath;
        }

        private void cmdBrowseSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cmdlg = new FolderBrowserDialog();
            cmdlg.ShowNewFolderButton = false;
            cmdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtSource.Text = cmdlg.SelectedPath;
        }

        private void cmdBrowseDestWIM_Click(object sender, EventArgs e)
        {
            SaveFileDialog cmdlg = new SaveFileDialog();
            cmdlg.Title = "Create target WIM File";
            cmdlg.Filter = "WIM File|*.wim";
            cmdlg.DefaultExt = ".wim";
            cmdlg.OverwritePrompt = true;
            cmdlg.SupportMultiDottedExtensions = true;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtDestWIM.Text = cmdlg.FileName;
            txtCaptureTempDir.Text = Path.GetDirectoryName(cmdlg.FileName);
        }

        private void chkExcludeFiles_CheckedChanged(object sender, EventArgs e)
        {
            cmdListExcludeFiles.Enabled = chkExcludeFiles.Checked;
        }

        private void cmdListExcludeFiles_Click(object sender, EventArgs e)
        {
            frmExcludeDirFiles frm = new frmExcludeDirFiles();
            frm.ShowDialog(this);
        }

        private void cmdBrowseCaptureTempDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cmdlg = new FolderBrowserDialog();
            cmdlg.ShowNewFolderButton = false;
            cmdlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (cmdlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtCaptureTempDir.Text = cmdlg.SelectedPath;
        }

        private void cmdStartCapture_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtCaptureTempDir.Text) == false)
            {
                MessageBox.Show(this, "The Temp directory must exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Fox.FoxCWrapperDISM.SetTempDir(txtCaptureTempDir.Text);
            bg = new BackgroundWorker();
            bg.WorkerSupportsCancellation = false;
            bg.DoWork += bg_DoWork_Capture;
            bg.RunWorkerCompleted += bg_RunWorkerCompleted;
            grpStatus.Enabled = true;
            tabControl1.Enabled = false;
            bg.RunWorkerAsync();
        }

        private void lstDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstDestination.SelectedIndex)
            {
                case 0:
                    grpDestDisk.Enabled = true;
                    grpDestFolder.Enabled = false;
                    break;
                case 1:
                    grpDestDisk.Enabled = false;
                    grpDestFolder.Enabled = true;
                    break;
            }
        }

        private void cmdPatchOptions_Click(object sender, EventArgs e)
        {
            frmPatchOptions frm = new frmPatchOptions();
            frm.ShowDialog(this);
        }

        private void chkPrePatch_CheckedChanged(object sender, EventArgs e)
        {
            cmdPatchOptions.Enabled = chkPrePatch.Checked;
        }
    }
}
