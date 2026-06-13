using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiniNTUpdateChecksumCalc
{
    class Program
    {
        static string StripFoldername;

        static string CalcMD5File(string File)
        {
            try
            {
                FileStream file = new FileStream(File, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("X2"));
                }
                return (sb.ToString());
            }
            catch
            {
                return ("");
            }
        }

        static bool CollectDir(string SearchDir, ref List<string> CRCData)
        {
            foreach (string dir in Directory.EnumerateDirectories(SearchDir, "*.*", SearchOption.TopDirectoryOnly))
            {
                if (CollectDir(dir, ref CRCData) == false)
                    return (false);
            }

            foreach (string file in Directory.EnumerateFiles(SearchDir, "*.*", SearchOption.TopDirectoryOnly))
            {
                string nfile = file.Replace(StripFoldername, "");
                Console.Write("Checking file " + nfile + " ... ");
                string md5 = CalcMD5File(file);
                if (string.IsNullOrWhiteSpace(md5) == true)
                {
                    Console.WriteLine("failed");
                    return (false);
                }
                Console.WriteLine("OK");

                CRCData.Add(nfile + "|" + md5);
            }

            return (true);
        }

        static int Main(string[] args)
        {
            List<string> CRCData = new List<string>();

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: MiniNTUpdateChecksumCalc <path> <destfile>");
                return (1);
            }

            StripFoldername = new DirectoryInfo(args[0]).FullName;
            if (StripFoldername.EndsWith("\\") == false)
                StripFoldername += "\\";

            if (CollectDir(StripFoldername, ref CRCData) == false)
                return (2);

            Console.Write("Writing file ...");
            File.WriteAllText(args[1], String.Join("\r\n", CRCData), Encoding.UTF8);
            Console.WriteLine("OK");

            return (0);
        }
    }
}
