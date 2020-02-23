using Fox.Common;
using FoxMultiWIM.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoxMultiWIM
{
    public partial class frmPatchOptions : Form
    {
        static public uint KeyboardSelection = 0x807;
        static public int LCID = 0x46E;
        static public string LCIDStr = "lb";
        static public string TimeZone = "W. Europe Standard Time";
        static public string Username = "User";
        static public string UsernameDesc = "User";
        static public string RegCompany = "";
        static public string RegOwner = "User";
        static public bool ConfigOOBE = true;
        static public bool UACMax = true;
        static public bool DisableCortana = true;
        static public bool DisableMSAccount = true;
        static public bool DisableTelemetry = true;
        static public bool DisableFileRegVirtualization = false;
        static public bool DisablePrivacyAsk = true;
        static public bool ApplyBranding = true;
        static public bool DisableCloudContent = true;
        static public bool DisableOneDrive = true;
        static public string ModelName = "";
        static public string SerialNumber = "";

        class CultureListInfo
        {
            public CultureInfo C;
            public override string ToString()
            {
                //return (C.EnglishName + " (0x" + C.LCID.ToString("X") + "-0x" + C.KeyboardLayoutId.ToString("X") + ")");
                //return (C.EnglishName + " " + C.Name);
                return (C.EnglishName);
            }
        }

        class TimeZoneListInfo
        {
            public TimeZoneInfo T;
            public override string ToString()
            {
                return (DisplayTZ(T));
            }

            public static string DisplayTZ(TimeZoneInfo T)
            {
                return (T.DisplayName);
            }
        }

        public frmPatchOptions()
        {
            InitializeComponent();
        }

        private void frmPatchOptions_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToParent();

            List<Fox.FoxKeyboardLayout> Keyboards = Fox.FoxCWrapper.KeyboardLayoutGetList();
            foreach (Fox.FoxKeyboardLayout keyb in Keyboards)
            {
                lstKeyboardFormat.Items.Add(keyb);
                if (keyb.ID == KeyboardSelection)
                    lstKeyboardFormat.SelectedItem = keyb;
            }

            foreach (CultureInfo cult in CultureInfo.GetCultures(CultureTypes.NeutralCultures).OrderBy(s => s.EnglishName))
            {
                CultureListInfo l = new CultureListInfo() { C = cult };
                lstRegionFormat.Items.Add(l);
                if (l.C.Name.ToLower() == LCIDStr.ToLower())
                    lstRegionFormat.SelectedItem = l;
            }

            foreach (TimeZoneInfo TZI in TimeZoneInfo.GetSystemTimeZones().OrderBy(s => TimeZoneListInfo.DisplayTZ(s)))
            {
                TimeZoneListInfo t = new TimeZoneListInfo() { T = TZI };
                lstTimeZone.Items.Add(t);
                if (t.T.Id == TimeZone)
                    lstTimeZone.SelectedItem = t;
            }

            txtInitialUsername.Text = Username;
            txtInitialUsernameDesc.Text = UsernameDesc;
            txtRegCompany.Text = RegCompany;
            txtRegOwner.Text = RegOwner;

            chkConfigOOBE.Checked = ConfigOOBE;

            chkUAC.Checked = UACMax;
            chkNoCortana.Checked = DisableCortana;
            chkDisableMSAccount.Checked = DisableMSAccount;
            chkDisableTelemetry.Checked = DisableTelemetry;
            chkDisableFileRegVirtualization.Checked = DisableFileRegVirtualization;
            chkDisablePrivacy.Checked = DisablePrivacyAsk;
            chkApplyBranding.Checked = ApplyBranding;
            chkDisableOneDrive.Checked = DisableOneDrive;
            txtModel.Text = ModelName;
            txtSerialNumber.Text = SerialNumber;
            chkDisableCloudContent.Checked = DisableCloudContent;

            panel1.Enabled = chkConfigOOBE.Checked;
            grpBranding.Enabled = chkApplyBranding.Checked;

            if (BrandingDNSDecoder.ValidData == false)
            {
                chkApplyBranding.Enabled = false;
                chkApplyBranding.Checked = false;
                ApplyBranding = false;
            }
        }

        private void chkConfigOOBE_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = chkConfigOOBE.Checked;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            UACMax = chkUAC.Checked;
            DisableCortana = chkNoCortana.Checked;
            DisableMSAccount = chkDisableMSAccount.Checked;
            DisableTelemetry = chkDisableTelemetry.Checked;
            DisablePrivacyAsk = chkDisablePrivacy.Checked;
            ConfigOOBE = chkConfigOOBE.Checked;
            DisableCloudContent = chkDisableCloudContent.Checked;
            DisableOneDrive = chkDisableOneDrive.Checked;
            DisableFileRegVirtualization = chkDisableFileRegVirtualization.Checked;
            ApplyBranding = chkApplyBranding.Checked;
            KeyboardSelection = (lstKeyboardFormat.SelectedItem as Fox.FoxKeyboardLayout).ID;
            LCID = (lstRegionFormat.SelectedItem as CultureListInfo).C.LCID;
            LCIDStr = (lstRegionFormat.SelectedItem as CultureListInfo).C.Name;
            TimeZone = (lstTimeZone.SelectedItem as TimeZoneListInfo).T.Id;

            Username = txtInitialUsername.Text.Trim();
            UsernameDesc = txtInitialUsernameDesc.Text.Trim();
            RegCompany = txtRegCompany.Text.Trim();
            RegOwner = txtRegOwner.Text.Trim();
            ModelName = txtModel.Text.Trim();
            SerialNumber = txtSerialNumber.Text.Trim();

            this.Close();
        }

        static void PutDWORD(string Path, string Key, int Value)
        {
            using (RegistryKey k = Registry.LocalMachine.CreateSubKey("FoxMultiWIMS\\" + Path))
            {
                if (k == null)
                    return;
                k.SetValue(Key, Value, RegistryValueKind.DWord);
            }
        }

        static void PutString(string Path, string Key, string Value)
        {
            using (RegistryKey k = Registry.LocalMachine.CreateSubKey("FoxMultiWIMS\\" + Path))
            {
                if (k == null)
                    return;
                k.SetValue(Key, Value, RegistryValueKind.String);
            }
        }

        static void PutStringExp(string Path, string Key, string Value)
        {
            using (RegistryKey k = Registry.LocalMachine.CreateSubKey("FoxMultiWIMS\\" + Path))
            {
                if (k == null)
                    return;
                k.SetValue(Key, Value, RegistryValueKind.ExpandString);
            }
        }

        public static Int64 PatchWindows(string SystemDriveDir)
        {
            if (SystemDriveDir.EndsWith("\\") == false)
                SystemDriveDir += "\\";

            if (ConfigOOBE == true)
            {
                try
                {
                    string XMLFile = string.Format(Resources.OOBEXML,
                        LCID.ToString("X4") + ":" + KeyboardSelection.ToString("X8"),
                        LCIDStr,
                        UsernameDesc,
                        Username,
                        RegOwner,
                        RegCompany);
                    if (Directory.Exists(SystemDriveDir + "WINDOWS\\Panther") == false)
                        Directory.CreateDirectory(SystemDriveDir + "WINDOWS\\Panther");
                    File.WriteAllText(SystemDriveDir + "WINDOWS\\Panther\\unattend.xml", XMLFile, Encoding.UTF8);
                }
                catch (Exception ee)
                {
                    Debug.WriteLine(ee.ToString());
                    return (0x8000FFFF);
                }
            }

            uint res = Fox.FoxCWrapper.LoadRegistryFile(SystemDriveDir + "WINDOWS\\SYSTEM32\\CONFIG\\SOFTWARE", "FoxMultiWIMS");
            if (res != 0)
                return (res);

            if (DisableMSAccount == true)
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "NoConnectedUser", 0x3);

            if (DisableTelemetry == true)
                PutDWORD("Policies\\Microsoft\\Windows\\DataCollection", "AllowTelemetry", 0x0);

            if (DisableCortana == true)
                PutDWORD("Policies\\Microsoft\\Windows\\Windows Search", "AllowCortana", 0x0);

            if (UACMax == true)
            {
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "FilterAdministratorToken", 0x1);
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", 0x4);
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorUser", 0x3);
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableInstallerDetection", 0x0);
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 0x1);
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "PromptOnSecureDesktop", 0x1);
            }

            if (DisableFileRegVirtualization == true)
            {
                PutDWORD("Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableVirtualization", 0x0);
            }

            if (DisablePrivacyAsk == true)
            {
                PutDWORD("Policies\\Microsoft\\Windows\\OOBE", "DisablePrivacyExperience", 0x1);
            }

            if (DisableCloudContent == true)
            {
                PutDWORD("Policies\\Microsoft\\Windows\\CloudContent", "DisableWindowsConsumerFeatures", 0x1);
                PutDWORD("Policies\\Microsoft\\Windows\\CloudContent", "DisableSoftLanding", 0x1);
            }

            if (DisableOneDrive == true)
            {
                PutDWORD("Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSync", 0x1);
                PutDWORD("Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSyncNGSC", 0x1);
                PutDWORD("Policies\\Microsoft\\OneDrive", "KFMBlockOptIn", 0x1);
            }

            if (BrandingDNSDecoder.ValidData == true && ApplyBranding == true)
            {
                PutString("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "Manufacturer", BrandingDNSDecoder.Manufacturer);
                PutString("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "SupportPhone", BrandingDNSDecoder.SupportPhone);
                PutString("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "SupportURL", BrandingDNSDecoder.SupportURL);
                PutString("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "Model", ModelName);
                PutString("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "SerialNumber", SerialNumber);
                PutStringExp("Microsoft\\Windows\\CurrentVersion\\OEMInformation", "Logo", "%SYSTEMROOT%\\System32\\OEMLogo.bmp");
                try
                {
                    if (Directory.Exists(SystemDriveDir + "WINDOWS\\SYSTEM32") == false)
                        Directory.CreateDirectory(SystemDriveDir + "WINDOWS\\SYSTEM32");
                    File.WriteAllBytes(SystemDriveDir + "WINDOWS\\SYSTEM32\\OEMLogo.bmp", BrandingDNSDecoder.BitmapData);
                }
                catch
                {

                }
            }

            GC.Collect();

            res = Fox.FoxCWrapper.UnloadRegistryFile("FoxMultiWIMS");
            if (res != 0)
                return (res);

            return (0);
        }

        private void chkApplyBranding_CheckedChanged(object sender, EventArgs e)
        {
            grpBranding.Enabled = chkApplyBranding.Checked;
        }
    }
}
