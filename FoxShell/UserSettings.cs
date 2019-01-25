using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FoxShell
{
    class UserSettings
    {
        const string RegKey = "Software\\Fox\\Shell";

        public static Rectangle? GetRECT()
        {
            Rectangle rect = new Rectangle();
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegKey);
            if (reg == null)
                return (null);
            int X, Y, W, H;
            int.TryParse(Convert.ToString(reg.GetValue("X", "0")), out X);
            rect.X = X;
            int.TryParse(Convert.ToString(reg.GetValue("Y", "0")), out Y);
            rect.Y = Y;
            int.TryParse(Convert.ToString(reg.GetValue("W", "0")), out W);
            rect.Width = W;
            int.TryParse(Convert.ToString(reg.GetValue("H", "0")), out H);
            rect.Height = H;
            reg.Close();
            if (X + Y + W + H == 0)
                return (null);
            return (rect);
        }

        public static FormWindowState GetState()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(RegKey);
            if (reg == null)
                return (FormWindowState.Normal);
            string State = Convert.ToString(reg.GetValue("State", "Normal"));
            reg.Close();
            switch (State)
            {
                case "Normal":
                    return (FormWindowState.Normal);
                case "Maximized":
                    return (FormWindowState.Maximized);
                case "Minimized":
                    return (FormWindowState.Minimized);
                default:
                    return (FormWindowState.Normal);
            }
        }

        public static void SaveRECT(Rectangle rect, FormWindowState state)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(RegKey);
            if (reg == null)
                return;
            if (state == FormWindowState.Normal)
            {
                reg.SetValue("X", rect.X, RegistryValueKind.DWord);
                reg.SetValue("Y", rect.Y, RegistryValueKind.DWord);
                reg.SetValue("W", rect.Width, RegistryValueKind.DWord);
                reg.SetValue("H", rect.Height, RegistryValueKind.DWord);
            }
            switch (state)
            {
                case FormWindowState.Normal:
                    reg.SetValue("State", "Normal"); break;
                case FormWindowState.Maximized:
                    reg.SetValue("State", "Maximized"); break;
                case FormWindowState.Minimized:
                    reg.SetValue("State", "Minimized"); break;
            }
            reg.Close();
        }
    }
}
