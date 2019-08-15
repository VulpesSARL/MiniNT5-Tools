using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoxSDC_AutoVersion
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("StampVersion Source.cs Namespace");
                return (1);
            }

            int Revision = 1;
            DateTime WasCompiled = DateTime.UtcNow;

            if (File.Exists(args[0]) == true)
            {
                IEnumerable<string> ielines = File.ReadLines(args[0]);
                string[] lines = ielines.ToArray();
                if (lines[0].StartsWith("//REV:") == true)
                {
                    string[] splitty = lines[0].Split(':');
                    if (int.TryParse(splitty[1], out Revision) == false)
                        Revision = 0;
                    Revision++;
                    if (splitty.Length > 2)
                    {
                        if (DateTime.TryParseExact(splitty[2], "yyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out WasCompiled) == false)
                        {
                            WasCompiled = DateTime.UtcNow;
                            Console.WriteLine("Cannot read DT from file");
                        }
                    }
                }
            }

            if (WasCompiled.Date < DateTime.UtcNow.Date)
                Revision = 1;

            WasCompiled = DateTime.UtcNow;

            if (Revision > 99)
                Revision = 1;

            string data = "";
            data = "//REV:" + Revision.ToString() + ":" + WasCompiled.ToString("yyMMddHHmmss") + "\r\n" +
                "using System;\r\n" +
                "namespace " + args[1].Trim() + "\r\n" +
                "{\r\n" +
                "\tpublic class FoxVersion\r\n" +
                "\t{\r\n" +
                "\t\tpublic const Int64 Version = " + DateTime.UtcNow.ToString("yyMMdd") + Revision.ToString("00") + ";\r\n" +
                "\t\tpublic const string DTV = \"" + DateTime.UtcNow.ToString("yyMM.dd") + Revision.ToString("00") + "\";\r\n" +
                "\t\tpublic const string DTS = \"" + DateTime.UtcNow.ToString("yyMMddHHmmss") + "\";\r\n" +
                "\t\tpublic static readonly DateTime DT = new DateTime(" + DateTime.UtcNow.Year + ", " + DateTime.UtcNow.Month + ", " +
                    DateTime.UtcNow.Day + ", " + DateTime.UtcNow.Hour + ", " + DateTime.UtcNow.Minute + ", " + DateTime.UtcNow.Second + ")" + ";\r\n" +
                "\t\tpublic const int Revision = " + Revision.ToString() + ";\r\n" +
                "\t}\r\n" +
                "}\r\n";
            try
            {
                File.WriteAllText(args[0], data, Encoding.UTF8);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                return (-1);
            }

            return (0);
        }

    }
}

