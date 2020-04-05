using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Fox.Common;
using Microsoft.Win32;

namespace FoxShell
{
    public partial class MainDLG : Form
    {
        internal IcoList icolist;

        #region Icon Management via Named Pipes (Invokes)
        delegate void DelegateDeleteIcon(string ID, IcoListRegType Type);
        delegate void DelegateAddIcon(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t);

        public void THREADDeleteIcon(string ID, IcoListRegType Type)
        {
            this.BeginInvoke(new DelegateDeleteIcon(THREADDeleteIconMethod), ID, Type);
        }

        public void THREADAddIcon(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t)
        {
            this.BeginInvoke(new DelegateAddIcon(THREADAddIconMethod), id, name, group, icofile, exec, order, ShellEx, t);
        }

        void THREADDeleteIconMethod(string ID, IcoListRegType Type)
        {
            icolist.DeleteIcon(ID, Type);
        }

        void THREADAddIconMethod(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t)
        {
            icolist.AddIcon(id, name, group, icofile, exec, order, ShellEx, t);
        }
        #endregion

        public MainDLG()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.IsInWindowsPE == true)
            {
                frmShutDown frm = new frmShutDown();
                if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                this.Visible = false;
                if (frm.Restart == true)
                {
                    Fox.FoxCWrapper.WPEUtilCall("RebootW", "");
                }
                else
                {
                    Fox.FoxCWrapper.WPEUtilCall("ShutdownW", "");
                }
            }
            PipeServer.StopPipeServer();
            UserSettings.SaveRECT(new Rectangle(this.Left, this.Top, this.Width, this.Height), this.WindowState);
        }

        void ExecNoCrashSync(string Filename, string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(Filename);
                p.StartInfo.Arguments = args;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                p.WaitForExit();
            }
            catch
            {

            }
        }

        void ExecNoCrash(string Filename, string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(Filename);
                p.StartInfo.Arguments = args;
                p.Start();
            }
            catch
            {

            }
        }

        bool CheckForInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://google.com/generate_204"))
                    {
                        return (true);
                    }
                }
            }
            catch
            {
                return (false);
            }
        }

        private void MainDLG_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            CPU.CPUType cpu = CPU.GetCPU();

            string BIOSType = "??";
            if (Fox.FoxCWrapper.IsFirmwareLEGACY() == true)
                BIOSType = "Legacy";
            if (Fox.FoxCWrapper.IsFirmwareEFI() == true)
                BIOSType = "EFI";

            if (BIOSType == "EFI")
                BIOSType += ",SB=" + CPU.GetSecureBootState();

            switch (cpu)
            {
                case CPU.CPUType.Intel32:
                    this.Text = "Fox Program Manager [i386," + BIOSType + "]";
                    break;
                case CPU.CPUType.EM64T:
                    this.Text = "Fox Program Manager [x64," + BIOSType + "]";
                    break;
                case CPU.CPUType.IA64:
                    this.Text = "Fox Program Manager [IA64," + BIOSType + "]";
                    break;
                case CPU.CPUType.Unknown:
                    this.Text = "Fox Program Manager [????," + BIOSType + "]";
                    break;
            }

            this.Text += " " + FoxStamp.FoxVersion.DTS;

            frmSplash.UpdateText("Starting network ...");

            if (Fox.FoxCWrapper.WPEUtilInit() == false)
            {
                Program.IsInWindowsPE = false;
            }
            else
            {
                Program.IsInWindowsPE = true;
                Fox.FoxCWrapper.WPEUtilCall("InitializeNetworkW", "");
                ExecNoCrashSync("%SYSTEMROOT%\\System32\\regsvr32.exe", "/s wintrust.dll");
                if (cpu == CPU.CPUType.EM64T)
                {
                    ExecNoCrashSync("%systemroot%\\syswow64\\regsvr32.exe", "/s wintrust.dll");
                }
            }

            frmSplash.UpdateText("Waiting for network && internet connectivity ...");

            int Count = 0;
            do
            {
                if (CheckForInternetConnection() == true)
                    break;
                Thread.Sleep(1000);
                Count++;
            } while (Count < 30);

            frmSplash.UpdateText("Initialising SDC ...");

            if (File.Exists(Environment.ExpandEnvironmentVariables("%SYSTEMROOT%\\SDC\\FoxSDC_Agent.exe")) == true)
            {
                ExecNoCrashSync("%SYSTEMROOT%\\SDC\\FoxSDC_Agent.exe", "-autodnsconfig");
                ExecNoCrashSync("%SYSTEMROOT%\\SDC\\FoxSDC_Agent.exe", "-install");
                bool SDCInitOK = false;
                using (RegistryKey k = Registry.LocalMachine.OpenSubKey("Software\\Fox\\SDC"))
                {
                    if (k != null)
                    {
                        if (k.GetValue("UseOnPremServer", "0").ToString() == "1" || k.GetValue("ContractID", "").ToString() != "")
                            SDCInitOK = true;
                    }
                }
                if (SDCInitOK == true)
                {
                    frmSplash.UpdateText("Starting SDC ...");
                    ExecNoCrashSync("%SYSTEMROOT%\\SDC\\FoxSDC_Agent.exe", "-recovercreds");
                    if (File.Exists(Environment.ExpandEnvironmentVariables("%SYSTEMROOT%\\Fox SDC MachinePW.reg")) == true)
                    {
                        ExecNoCrashSync("%SYSTEMROOT%\\System32\\Reg.exe", "IMPORT \"" + Environment.ExpandEnvironmentVariables("%SYSTEMROOT%\\Fox SDC MachinePW.reg") + "\"");
                    }
                    ExecNoCrashSync("%SYSTEMROOT%\\System32\\net.exe", "start FoxSDCA");
                }
                else
                {
                    frmSplash.UpdateText("NOT Starting SDC ...");
                    Thread.Sleep(5000);
                }
                ExecNoCrash("%SYSTEMROOT%\\SDC\\FoxSDC_Agent_UI.exe", "");
            }

            frmSplash.UpdateText("Finalising ...");

            Rectangle? rect = UserSettings.GetRECT();
            if (rect != null)
            {
                this.Width = rect.Value.Width;
                this.Height = rect.Value.Height;
                this.Left = rect.Value.X;
                this.Top = rect.Value.Y;
            }
            this.WindowState = UserSettings.GetState();
            icolist = new IcoList(lstPrograms);
            PipeServer.StartPipeServer();
            frmSplash.CloseSplash();
        }

        private void lstPrograms_DoubleClick(object sender, EventArgs e)
        {
            if (lstPrograms.SelectedItems.Count == 0)
                return;
            IcoListData data = (IcoListData)lstPrograms.SelectedItems[0].Tag;
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Environment.ExpandEnvironmentVariables(data.Execute);
                proc.StartInfo.UseShellExecute = data.UseShellEx;
                proc.Start();
            }
            catch
            {

            }
        }

        private void lstPrograms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                lstPrograms_DoubleClick(sender, e);
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemProperty frm = new frmItemProperty();
            frm.ShowDialog(this);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPrograms.SelectedItems.Count == 0)
                return;
            frmItemProperty frm = new frmItemProperty((IcoListData)lstPrograms.SelectedItems[0].Tag);
            frm.ShowDialog(this);
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPrograms.SelectedItems.Count == 0)
                return;
            IcoListData data = (IcoListData)lstPrograms.SelectedItems[0].Tag;
            if (MessageBox.Show(this, "Do you really want to delete the item " + data.Name + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes)
                return;
            icolist.DeleteIcon(data.ID, data.Type);
        }
    }
}
