using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FoxUnmapNet
{
    public partial class MainDLG : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetTopWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);
        [DllImport("user32.dll")]
        static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        const uint GW_HWNDNEXT = 2;
        const uint WS_VISIBLE = 0x10000000;
        const int GWL_STYLE = -16;

        public MainDLG()
        {
            InitializeComponent();
        }

        private void MainDLG_Load(object sender, EventArgs e)
        {
            this.Top = this.Left = 0;
            this.Height = this.Width = 1;
            Fox.FoxCWrapper.FoxNetworkUnmap(this.Handle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr Handle = GetTopWindow((IntPtr)0);
            while (Handle != (IntPtr)0)
            {
                if (GetParent(Handle) == this.Handle)
                {
                    int GWL = GetWindowLong(Handle, GWL_STYLE);
                    if ((GWL & WS_VISIBLE) != 0)
                    {
                        Debug.WriteLine("Visible Window - " + Handle.ToString());
                        return;
                    }
                }
                Handle = GetWindow(Handle, GW_HWNDNEXT);
            }
            this.Close();
        }
    }
}
