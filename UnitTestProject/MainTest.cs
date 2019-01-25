using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fox.Common;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void TestFilenamePatterns()
        {
            Assert.IsTrue(FileRegexTest.WildcardMatchesWindowsStyle("\\Recycler\\", "\\Recycler\\*"));
            Assert.IsTrue(FileRegexTest.WildcardMatchesWindowsStyle("\\Recycler\\Blahblah", "\\Recycler\\*"));
            Assert.IsTrue(FileRegexTest.WildcardMatchesWindowsStyle("\\Recycler\\xyz\\text.txt", "\\Recycler\\*"));
            Assert.IsTrue(FileRegexTest.WildcardMatchesWindowsStyle("\\windows\\system32\\foo.dll", "*.dll"));
            Assert.IsTrue(FileRegexTest.WildcardMatchesWindowsStyle("\\$ntfs.log", "\\$ntfs.log"));
            Assert.IsFalse(FileRegexTest.WildcardMatchesWindowsStyle("$ntfs.log", "\\$ntfs.log"));
            Assert.IsFalse(FileRegexTest.WildcardMatchesWindowsStyle("C:\\$ntfs.log", "\\$ntfs.log"));
        }

        [TestMethod]
        public void TestAllPattern()
        {
            FoxMultiWIM.Program.ExcludeFiles = new List<string>();
            FoxMultiWIM.Program.ExcludeFiles.Add("\\swapfile.sys");
            FoxMultiWIM.Program.ExcludeFiles.Add("\\System Volume Information\\*");
            Assert.IsTrue(FoxMultiWIM.Program.TestFilenamePattern("C:\\", "C:\\Test.txt"));
            Assert.IsFalse(FoxMultiWIM.Program.TestFilenamePattern("C:\\", "C:\\System Volume Information\\text.txt"));
            Assert.IsFalse(FoxMultiWIM.Program.TestFilenamePattern("C:\\", "C:\\swapfile.sys"));
            Assert.IsFalse(FoxMultiWIM.Program.TestFilenamePattern("C:\\", "C:\\System Volume Information\\{700A4049-AA0D-4506-B486-5751B9911E86}\\Blah.dat"));
            Assert.IsTrue(FoxMultiWIM.Program.TestFilenamePattern("C:\\", "C:\\Windows\\system32\\ntoskrnl.exe"));
        }
    }
}
