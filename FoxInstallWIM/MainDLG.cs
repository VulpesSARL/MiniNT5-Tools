using Fox;
using Fox.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoxMultiWIM
{
    public partial class MainDLG : Form
    {
        uint SelectedEditionIndex = 0;
        bool Running = false;
        BackgroundWorker bg;

        delegate void MyUpdateStatus(bool EnableGrp1, bool EnableGrp2, int ProgressValue, string ProgressText);
        delegate void MyUpdateStatusBarOnly(int ProgressValue);

        public void UpdateStatus(int ProgressValue)
        {
            this.BeginInvoke(new MyUpdateStatusBarOnly(UpdateMethod), ProgressValue);
        }

        public void UpdateMethod(int ProgressValue)
        {
            if (ProgressValue != -1)
                progressBar.Value = ProgressValue;
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
#if !DEBUG
            chkNoApplySec.Visible = false;
#endif
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
    }
}
