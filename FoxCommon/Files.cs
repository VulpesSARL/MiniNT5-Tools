using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Fox.Common
{
    public class FileTools
    {
        public static bool ExistsOnPath(string fileName)
        {
            if (GetFullPath(fileName) != null)
                return true;
            return false;
        }

        public static bool ValidFileSystesmCharactersPath(string path)
        {
            foreach (char c in path)
            {
                if (Path.GetInvalidPathChars().Contains(c) == true)
                    return (false);
            }
            return (true);
        }

        public static bool ValidFileSystesmCharactersFile(string filename)
        {
            foreach (char c in filename)
            {
                if (Path.GetInvalidFileNameChars().Contains(c) == true)
                    return (false);
            }
            return (true);
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            string values = Environment.GetEnvironmentVariable("PATH");
            foreach (string path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return (fullPath);
            }
            return (null);
        }

        public static string MakeNiceSize(Int64 Size)
        {
            double sz = Size;
            string unit = " B";
            if (sz > 1024)
            {
                sz /= 1024d;
                unit = " KiB";
            }
            if (sz > 1024)
            {
                sz /= 1024d;
                unit = " MiB";
            }
            if (sz > 1024)
            {
                sz /= 1024d;
                unit = " GiB";
            }

            return (sz.ToString("0.##") + unit);
        }

        public static string GetDirectory(string Path, string Filename)
        {
            if (File.Exists(Path) == false)
            {
                if (Path.ToLower().EndsWith(Filename.ToLower()) == false)
                    return (Path);
                Path = Path.Substring(0, Path.Length - Filename.Length);
                if (Path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == true && Path.Length > 3)
                    Path = Path.Substring(0, Path.Length - 1);
                return (Path);
            }
            FileInfo fi = new FileInfo(Path);
            if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                return (Path);
            return (System.IO.Path.GetDirectoryName(Path));
        }

        public static bool SamePaths(string Path1, string Path2)
        {
            if (Path1.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                Path1 += Path.DirectorySeparatorChar.ToString();
            if (Path2.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                Path2 += Path.DirectorySeparatorChar.ToString();
            if (Path1.ToLower() == Path2.ToLower())
                return (true);
            return (false);
        }

        public static string GetDirectory(string Path)
        {
            if (File.Exists(Path) == false)
                return (Path);
            FileInfo fi = new FileInfo(Path);
            if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                return (Path);
            return (System.IO.Path.GetDirectoryName(Path));
        }

        public static string GetExtensionDescription(string Ext)
        {
            if (Ext == "")
                return ("");
            RegistryKey Reg = Registry.ClassesRoot.OpenSubKey("." + Ext);
            if (Reg == null)
                return ("");
            string ExtType = Convert.ToString(Reg.GetValue(null, null));
            if (ExtType == null)
                return ("");
            if (ExtType == "")
                return ("");
            Reg.Close();
            Reg = Registry.ClassesRoot.OpenSubKey(ExtType);
            if (Reg == null)
                return ("");
            ExtType = Convert.ToString(Reg.GetValue(null, null));
            if (ExtType == null)
                return ("");
            return (ExtType);
        }
    }
}
