using Fox.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FoxMultiWIM
{
    public static class Program
    {
        public static List<string> ExcludeFiles;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainDLG frm = new MainDLG();
            Application.Run(frm);
        }

        public static bool TestFilenamePattern(string Source, string Test)
        {
            string SourceFilename = Source;
            if (SourceFilename.EndsWith("\\") == true)
                SourceFilename = SourceFilename.Substring(0, SourceFilename.Length - 1);
            string FilenameTest;
            if (Test.ToLower().StartsWith(SourceFilename.ToLower()))
                FilenameTest = Test.Substring(SourceFilename.Length, Test.Length - SourceFilename.Length);
            else
                FilenameTest = Test;

            foreach (string s in Program.ExcludeFiles)
                if (FileRegexTest.WildcardMatchesWindowsStyle(FilenameTest, s) == true)
                    return (false);
            return (true);
        }

    }
}
