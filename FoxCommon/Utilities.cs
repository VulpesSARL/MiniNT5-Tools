using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace Fox.Common
{
    public class Utilities
    {
        #region P/Invoke

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint OPEN_EXISTING = 3;
        const uint FILE_SHARE_READ = 1;
        const uint FILE_SHARE_WRITE = 2;

        #endregion

        public static DialogResult MessageBoxInvoke(Form owner, string msg, string caption, MessageBoxButtons buttons, MessageBoxIcon image)
        {
            if (owner.InvokeRequired == true)
                return ((DialogResult)owner.Invoke(new Func<DialogResult>(() => MessageBoxInvoke(owner, msg, caption, buttons, image))));

            return (System.Windows.Forms.MessageBox.Show(owner, msg, caption, buttons, image));
        }

        public static bool IsValidPath(string path)
        {
            try
            {
                Path.GetFullPath(path);
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        public static SafeFileHandle OpenWithSafeHandle_RO(string path)
        {
            SafeFileHandle handle = CreateFile(path, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (handle.IsInvalid == true)
            {
                throw new IOException("Unable to open handle", Marshal.GetLastWin32Error());
            }
            return (handle);
        }

        public static SafeFileHandle OpenWithSafeHandle_RW(string path)
        {
            SafeFileHandle handle = CreateFile(path, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (handle.IsInvalid == true)
            {
                throw new IOException("Unable to open handle", Marshal.GetLastWin32Error());
            }
            return (handle);
        }
    }
}
