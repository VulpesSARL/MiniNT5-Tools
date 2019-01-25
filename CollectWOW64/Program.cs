using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CollectWOW64
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ROOTDIR = args[0];
                string CDDIR = args[1];
                string CMDFILE = args[2];
                string Lang = args[3];
                string BatchData = "";

                if (ROOTDIR.EndsWith("\\") == false)
                    ROOTDIR += "\\";
                if (CDDIR.EndsWith("\\") == false)
                    CDDIR += "\\";

                foreach (string file in Directory.GetFiles(ROOTDIR + "WINDOWS\\SYSTEM32"))
                {
                    Debug.WriteLine(file);
                    string Fileonly = Path.GetFileName(file);
                    if (File.Exists(CDDIR + "WINDOWS\\SYSWOW64\\" + Fileonly) == false)
                        continue;
                    BatchData += "xcopy /g /h /r /y \"" + CDDIR + "WINDOWS\\SYSWOW64\\" + Fileonly + "\" \"" + ROOTDIR + "WINDOWS\\SYSWOW64\"\r\n";
                    if (File.Exists(CDDIR + "WINDOWS\\SYSWOW64\\" + Lang + "\\" + Fileonly + ".mui") == false)
                        continue;
                    BatchData += "xcopy /g /h /r /y \"" + CDDIR + "WINDOWS\\SYSWOW64\\" + Lang + "\\" + Fileonly + ".mui" + "\" \"" + ROOTDIR + "WINDOWS\\SYSWOW64\\" + Lang + "\"\r\n";
                }
                File.WriteAllText(CMDFILE, BatchData);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }

        }
    }
}
