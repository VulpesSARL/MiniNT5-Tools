using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoxMultiWIM
{
    static class SDCData
    {
        public static string MachineID;
        public static string MachinePassword;

        public static string ContractID;
        public static string ContractPassword;

        public static bool UseOnPrem;
        public static string URL;

        public static void ReadContractData()
        {
            using (RegistryKey r = Registry.LocalMachine.OpenSubKey("Software\\Fox\\SDC"))
            {
                if (r == null)
                    return;
                MachineID = r.GetValue("ID", "").ToString();
                MachinePassword = r.GetValue("PassID", "").ToString();
                ContractID = r.GetValue("ContractID", "").ToString();
                ContractPassword = r.GetValue("ContractPassword", "").ToString();
                UseOnPrem = r.GetValue("UseOnPremServer", "0").ToString() == "1" ? true : false;
                URL = r.GetValue("URL", "").ToString();
            }
        }
    }
}
