using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FoxShell
{
    public partial class frmSplash : Form
    {
        private static Thread splashThread = null;
        private static frmSplash splashForm = null;

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(IntPtr hWnd);

        public static void ShowSplash()
        {
            if (splashThread == null)
            {
                splashThread = new Thread(new ThreadStart(DoShowSplash));
                splashThread.IsBackground = true;
                splashThread.Start();
            }
        }

        public static Form GetSplashForm()
        {
            return (splashForm);
        }

        private static void DoShowSplash()
        {
            if (splashForm == null)
                splashForm = new frmSplash();
            Application.Run(splashForm);
        }

        public static void CloseSplash()
        {
            if (splashForm == null)
                return;
            if (splashForm.InvokeRequired)
                splashForm.Invoke(new MethodInvoker(CloseSplash));
            else
                splashForm.Close();
        }

        delegate void DUpdateText(string txt);

        public static void PutToFront()
        {
            if (splashForm == null)
                return;

            if (splashForm == null)
                return;
            if (splashForm.InvokeRequired)
            {
                splashForm.Invoke(new MethodInvoker(PutToFront));
                return;
            }

            SetForegroundWindow(splashForm.Handle);
        }

        public static void UpdateText(string txt)
        {
            if (splashForm == null)
                return;
            if (splashForm.InvokeRequired)
            {
                splashForm.Invoke(new DUpdateText(UpdateText), txt);
                return;
            }
            splashForm.lblText.Text = txt;
        }

        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            lblText.Text = "";
        }
    }
}
