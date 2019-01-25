using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FoxShell
{
    static class Program
    {
        public static bool IsInWindowsPE = false;
        public static MainDLG maindlg;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            maindlg = new MainDLG();
            Application.Run(maindlg);
        }
    }
}
