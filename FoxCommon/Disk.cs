using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Fox.Common
{
    public class Disk
    {
        //https://docs.microsoft.com/en-us/previous-versions/windows/desktop/stormgmt/msft-disk
        public delegate void UpdateStatus(string Text);
        public static event UpdateStatus OnUpdateStatus;

        static string EscapeString(string str)
        {
            return (str.Replace("\\", "\\\\").Replace("'", "''").Replace("\"", "\"\""));
        }

        static public Dictionary<string, string> GetDisks()
        {
            Dictionary<string, string> res = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\Microsoft\\Windows\\Storage");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSFT_Disk");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();

            foreach (ManagementObject m in queryCollection)
            {
                string DiskUID = Convert.ToString(m["UniqueId"]);
                string DiskName = Convert.ToString(m["Model"]).Trim() +
                    " - SIZE=" + FileTools.MakeNiceSize(Convert.ToInt64(m["Size"])) + " - USED=" + FileTools.MakeNiceSize(Convert.ToInt64(m["AllocatedSize"])) +
                    " (" + (Convert.ToString(m["SerialNumber"]).Trim() == "" ? "" : "SN: " + Convert.ToString(m["SerialNumber"]).Trim() + ", ") +
                    "Loc: " + Convert.ToString(m["Location"]).Trim() + ")";
                res.Add(DiskUID, DiskName);
            }
            return (res);
        }

        static public string GetEmptyDiskUID()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\Microsoft\\Windows\\Storage");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSFT_Disk WHERE AllocatedSize = 0");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();

            foreach (ManagementObject m in queryCollection)
            {
                return (Convert.ToString(m["UniqueId"]));
            }

            return ("");
        }

        static public Int64? GetAllocSize(string UID)
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\Microsoft\\Windows\\Storage");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSFT_Disk WHERE UniqueId = '" + EscapeString(UID) + "'");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();

            foreach (ManagementObject m in queryCollection)
            {
                return (Convert.ToInt64(m["AllocatedSize"]));
            }

            return (null);
        }

        static private Int64 ClearDisk(ManagementObject DiskToMess)
        {
            ManagementBaseObject ClearMethod = DiskToMess.GetMethodParameters("Clear");
            ClearMethod["RemoveData"] = true;
            ClearMethod["RemoveOEM"] = true;
            ClearMethod["RunAsJob"] = false;
            ClearMethod["Sanitize"] = false;
            ClearMethod["ZeroOutEntireDisk"] = false;

            ManagementBaseObject Output = DiskToMess.InvokeMethod("Clear", ClearMethod, null);
            Int64 res = Convert.ToInt64(Output["ReturnValue"]);
            if (res == 0xA028) //Disk already empty?
                return (0);
            return (res);
        }

        static private Int64 InitializeDisk(ManagementObject DiskToMess, int PartitionStyle)
        {
            ManagementBaseObject ConvMethod = DiskToMess.GetMethodParameters("Initialize");
            /*
             Windows:
                1 Legacy
                2 EFI
             */

            ConvMethod["PartitionStyle"] = PartitionStyle + 1;

            ManagementBaseObject Output = DiskToMess.InvokeMethod("Initialize", ConvMethod, null);
            return (Convert.ToInt64(Output["ReturnValue"]));
        }

        enum FileSystem
        {
            NTFS,
            FAT,
            FAT32,
            ReFS,
            ExFAT,
            NoFormat
        }

        enum EFIPartType
        {
            Pri,
            MSR,
            EFI,
            Recovery
        }

        enum MBRPartType
        {
            FAT12 = 1,
            FAT16 = 4,
            Extended = 5,
            Huge = 6,
            IFS = 7,
            FAT32 = 12
        }

        static private ManagementObject GetVolume(string PartitionID)
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\Microsoft\\Windows\\Storage");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSFT_PartitionToVolume");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            ManagementObject Volume = null;
            foreach (ManagementObject m in queryCollection)
            {
                ManagementObject Partition = new ManagementObject(Convert.ToString(m["Partition"]));
                if (Convert.ToString(Partition["UniqueId"]) == PartitionID)
                {
                    Volume = new ManagementObject(Convert.ToString(m["Volume"]));
                    break;
                }
            }

            if (Volume == null)
            {
                OnUpdateStatus?.Invoke("Cannot find Volume in MSFT_PartitionToVolume");
                return (null);
            }

            return (Volume);
        }

        static private Int64 FormatVolume(ManagementObject Volume, string Label, FileSystem FS)
        {
            string FSStr = "";
            switch (FS)
            {
                case FileSystem.FAT: FSStr = "FAT"; break;
                case FileSystem.FAT32: FSStr = "FAT32"; break;
                case FileSystem.ExFAT: FSStr = "ExFAT"; break;
                case FileSystem.NTFS: FSStr = "NTFS"; break;
                case FileSystem.ReFS: FSStr = "ReFS"; break;
            }

            if (FSStr == "")
                return (1);

            ManagementBaseObject FormatMethod = Volume.GetMethodParameters("Format");
            FormatMethod["RunAsJob"] = false;
            FormatMethod["Full"] = false;
            FormatMethod["Force"] = true;
            FormatMethod["Filesystem"] = FSStr;
            if (FS == FileSystem.NTFS)
            {
                FormatMethod["ShortFileNameSupport"] = true;
                FormatMethod["Compress"] = false;
            }
            FormatMethod["FileSystemLabel"] = Label;

            ManagementBaseObject Output = Volume.InvokeMethod("Format", FormatMethod, null);
            Int64 res = Convert.ToInt64(Output["ReturnValue"]);
            return (res);
        }

        static private Int64 CreateEFIPartition(ManagementObject DiskToMess, UInt64? Size, EFIPartType Type, FileSystem FS, string Label, out string Letter)
        {
            Letter = "";

            ManagementBaseObject CreParMethod = DiskToMess.GetMethodParameters("CreatePartition");
            CreParMethod["Alignment"] = 4096;
            if (Type != EFIPartType.MSR)
                CreParMethod["AssignDriveLetter"] = true;
            string ParID = "";
            switch (Type)
            {
                case EFIPartType.EFI: ParID = "{c12a7328-f81f-11d2-ba4b-00a0c93ec93b}"; break;
                case EFIPartType.MSR: ParID = "{e3c9e316-0b5c-4db8-817d-f92df00215ae}"; break;
                case EFIPartType.Pri: ParID = "{ebd0a0a2-b9e5-4433-87c0-68b6b72699c7}"; break;
                case EFIPartType.Recovery: ParID = "{de94bba4-06d1-4d40-a16a-bfd50179d6ac}"; break;
                default: ParID = ""; break;
            }

            CreParMethod["GptType"] = ParID;
            if (Size == null)
                CreParMethod["UseMaximumSize"] = true;
            else
                CreParMethod["Size"] = Size.Value;

            ManagementBaseObject Output = DiskToMess.InvokeMethod("CreatePartition", CreParMethod, null);
            if (Convert.ToInt64(Output["ReturnValue"]) != 0)
                return (Convert.ToInt64(Output["ReturnValue"]));

            if (Type == EFIPartType.MSR)
                return (0);

            ManagementBaseObject Partition = Output["CreatedPartition"] as ManagementBaseObject;
            string PartitionID = Partition["UniqueId"].ToString();

            ManagementObject Volume = GetVolume(PartitionID);
            if (Volume == null)
                return (3);

            Letter = Convert.ToString(Volume["DriveLetter"]);

            if (FS != FileSystem.NoFormat)
            {
                OnUpdateStatus?.Invoke("Creating filesystem (" + FS.ToString() + ")");

                Int64 res = FormatVolume(Volume, Label, FS);
                if (res != 0)
                    return (res);
            }

            return (0);
        }

        static private Int64 CreateMBRPartition(ManagementObject DiskToMess, UInt64? Size, MBRPartType Type, FileSystem FS, bool Active, string Label, out string Letter)
        {
            Letter = "";

            ManagementBaseObject CreParMethod = DiskToMess.GetMethodParameters("CreatePartition");
            CreParMethod["Alignment"] = 4096;
            CreParMethod["AssignDriveLetter"] = true;
            CreParMethod["IsActive"] = Active;

            CreParMethod["MbrType"] = (UInt16)Type;
            if (Size == null)
                CreParMethod["UseMaximumSize"] = true;
            else
                CreParMethod["Size"] = Size.Value;

            ManagementBaseObject Output = DiskToMess.InvokeMethod("CreatePartition", CreParMethod, null);
            if (Convert.ToInt64(Output["ReturnValue"]) != 0)
                return (Convert.ToInt64(Output["ReturnValue"]));

            ManagementBaseObject Partition = Output["CreatedPartition"] as ManagementBaseObject;
            string PartitionID = Partition["UniqueId"].ToString();

            ManagementObject Volume = GetVolume(PartitionID);
            if (Volume == null)
                return (3);

            Letter = Convert.ToString(Volume["DriveLetter"]);

            if (FS != FileSystem.NoFormat)
            {
                OnUpdateStatus?.Invoke("Creating filesystem (" + FS.ToString() + ")");

                Int64 res = FormatVolume(Volume, Label, FS);
                if (res != 0)
                    return (res);
            }

            return (0);
        }

        static public Int64 CreatePartitions(string UID, int Schema, out string BootLetter, out string SystemLetter)
        {
            BootLetter = "";
            SystemLetter = "";

            OnUpdateStatus?.Invoke("Querying disk");
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\Microsoft\\Windows\\Storage");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSFT_Disk WHERE UniqueId = '" + EscapeString(UID) + "'");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            ManagementObject DiskToMess = null;
            foreach (ManagementObject m in queryCollection)
            {
                DiskToMess = m;
                break;
            }

            if (DiskToMess == null)
                return (2);

            Int64 res;

            switch (Schema)
            {
                case 0: //Legacy
                case 1: //EFI
                    break;
                default:
                    return (13);
            }

            OnUpdateStatus?.Invoke("Clearing disk");
            res = ClearDisk(DiskToMess);
            if (res != 0)
                return (res);

            OnUpdateStatus?.Invoke("Converting Schema");
            res = InitializeDisk(DiskToMess, Schema);
            if (res != 0)
                return (res);

            string MSRLetter = ""; //dummy

            switch (Schema)
            {
                case 0:
                    OnUpdateStatus?.Invoke("Creating Boot Partition");
                    res = CreateMBRPartition(DiskToMess, 134217728, MBRPartType.IFS, FileSystem.NTFS, true, "Boot", out BootLetter);
                    if (res != 0)
                        return (res);
                    OnUpdateStatus?.Invoke("Creating Data Partition");
                    res = CreateMBRPartition(DiskToMess, null, MBRPartType.IFS, FileSystem.NTFS, false, "SYSTEM", out SystemLetter);
                    if (res != 0)
                        return (res);
                    break;
                case 1:
                    OnUpdateStatus?.Invoke("Creating EFI Partition");
                    res = CreateEFIPartition(DiskToMess, 134217728, EFIPartType.EFI, FileSystem.FAT32, "EFI", out BootLetter);
                    if (res != 0)
                        return (res);
                    OnUpdateStatus?.Invoke("Creating MSR Partition");
                    res = CreateEFIPartition(DiskToMess, 134217728, EFIPartType.MSR, FileSystem.NoFormat, "MSR", out MSRLetter);
                    if (res != 0)
                        return (res);
                    OnUpdateStatus?.Invoke("Creating Data Partition");
                    res = CreateEFIPartition(DiskToMess, null, EFIPartType.Pri, FileSystem.NTFS, "SYSTEM", out SystemLetter);
                    if (res != 0)
                        return (res);
                    break;
            }

            return (0);
        }
    }
}
