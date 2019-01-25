using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Fox.Common;
using FoxShell.Properties;
using Microsoft.Win32;

namespace FoxShell
{
    class IcoList
    {
        ListView lstList;
        List<IcoListData> icos;
        Dictionary<string, ListViewGroup> icogroup;
        const string RegKey = "Software\\Fox\\Shell\\Items";

        public IcoList(ListView lst)
        {
            lstList = lst;
            icos = new List<IcoListData>();
            InitRegistry();
        }

        void InitRegistry(RegistryKey root, IcoListRegType T)
        {
            RegistryKey dir = root.OpenSubKey(RegKey, false);
            if (dir == null)
                return;
            foreach (string keyname in dir.GetSubKeyNames())
            {
                RegistryKey key = dir.OpenSubKey(keyname, false);
                if (key == null)
                    continue;
                IcoListData ico = new IcoListData(keyname, T, key);
                if (ico.InitSuccess == true)
                    icos.Add(ico);
            }
            dir.Close();
        }

        public List<string> Groups
        {
            get
            {
                List<string> g = new List<string>();
                foreach (IcoListData i in icos)
                {
                    if (g.Contains(i.Group) == false)
                        g.Add(i.Group);
                }
                return (g);
            }
        }

        void InitRegistry()
        {
            InitRegistry(Registry.LocalMachine, IcoListRegType.System);
            InitRegistry(Registry.CurrentUser, IcoListRegType.User);
            LoadIcons();
        }

        void AddIcon(IcoListData ico)
        {
            ListViewItem lst = new ListViewItem(ico.Name);
            if (icogroup.ContainsKey(ico.Group.ToLower()) == false)
            {
                ListViewGroup lg = new ListViewGroup(ico.Group);
                icogroup.Add(ico.Group.ToLower(), lg);
                lstList.Groups.Add(icogroup[ico.Group.ToLower()]);
            }
            lst.Tag = ico;
            lst.Group = icogroup[ico.Group.ToLower()];
            lstList.SmallImageList.Images.Add(ico.Ico);
            lstList.LargeImageList.Images.Add(ico.Ico);
            lst.ImageIndex = lstList.SmallImageList.Images.Count - 1;
            lstList.Items.Add(lst);
        }

        void LoadIcons()
        {
            lstList.Items.Clear();
            lstList.Groups.Clear();
            lstList.ListViewItemSorter = new ListViewItemComparerIcoTag();
            lstList.SmallImageList.Images.Clear();
            lstList.LargeImageList.Images.Clear();
            icogroup = new Dictionary<string, ListViewGroup>();
            foreach (IcoListData ico in icos)
            {
                AddIcon(ico);
            }
        }

        public bool DeleteIcon(string ID, IcoListRegType Type)
        {
            foreach (IcoListData ico in icos)
            {
                if (ico.ID == ID && ico.Type == Type)
                {
                    RegistryKey reg;
                    if (Type == IcoListRegType.User)
                        reg = Registry.CurrentUser.OpenSubKey(RegKey, true);
                    else
                        reg = Registry.LocalMachine.OpenSubKey(RegKey, true);

                    if (reg == null)
                        return (false);
                    reg.DeleteSubKeyTree(ID, false);
                    foreach (ListViewItem l in lstList.Items)
                    {
                        if (l.Tag == ico)
                        {
                            lstList.Items.Remove(l);
                            break;
                        }
                    }
                    icos.Remove(ico);
                    reg.Close();
                    return (true);
                }
            }
            return (false);
        }

        public void AddIcon(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t)
        {
            foreach (IcoListData ico in icos)
            {
                if (ico.ID == id && ico.Type == t)
                {
                    if (DeleteIcon(id, t) == false)
                        return;
                    break;
                }
            }
            IcoListData newico = new IcoListData(id, name, group, icofile, exec, order, ShellEx, t);
            if (newico.InitSuccess == false)
                return;

            RegistryKey reg;
            if (t == IcoListRegType.User)
                reg = Registry.CurrentUser.CreateSubKey(RegKey);
            else
                reg = Registry.LocalMachine.CreateSubKey(RegKey);
            if (reg == null)
                return;

            RegistryKey sreg = reg.CreateSubKey(id);
            if (sreg == null)
                return;
            sreg.SetValue("Name", newico.Name);
            sreg.SetValue("IcoFile", newico.IcoFile);
            sreg.SetValue("Group", newico.Group);
            sreg.SetValue("Execute", newico.Execute);
            sreg.SetValue("Order", newico.Order, RegistryValueKind.DWord);
            sreg.SetValue("UseShellEx", newico.UseShellEx == true ? 1 : 0, RegistryValueKind.DWord);
            sreg.Close();
            reg.Close();
            AddIcon(newico);
            icos.Add(newico);
        }

        public bool IDExists(string ID, IcoListRegType T)
        {
            foreach (IcoListData i in icos)
            {
                if (i.ID == ID && i.Type == T)
                    return (true);
            }
            return (false);
        }

        class ListViewItemComparerIcoTag : IComparer
        {
            public int Compare(object x, object y)
            {
                ListViewItem a = (ListViewItem)x;
                ListViewItem b = (ListViewItem)y;
                IcoListData icoa = (IcoListData)a.Tag;
                IcoListData icob = (IcoListData)b.Tag;
                return (icoa.Order.CompareTo(icob.Order));
            }
        }


        /*
        public List<IcoListData> Icons;
        public IcoList()
        {
            Icons = new List<IcoListData>();
            Icons.Add(new IcoListData("Set keyboard layout", Resources.keyboard, "foxsetkeyboard.exe", 0));
            Icons.Add(new IcoListData("Command Prompt", Resources.cmd, "cmd.exe", 0));
            Icons.Add(new IcoListData("Registry Editor", Resources.regedit, "regedit.exe", 0));
            Icons.Add(new IcoListData("Calculator", Resources.calc, "calc.exe", 0));
            Icons.Add(new IcoListData("Map Network Drives", Resources.MapNet, "foxmapnet.exe", 0));
            Icons.Add(new IcoListData("Disconnect Network Drives", Resources.UnMapNet, "foxunmapnet.exe", 0));
            Icons.Add(new IcoListData("Team Viewer Support", Resources.tv, "TeamViewerQS.exe", 0));
            Icons.Add(new IcoListData("Install WIM File", Resources.exec, "FoxInstallWIM.exe", 0));
            Icons.Add(new IcoListData("CPU-Z", Resources.cpuz, "cpuz_x32.exe", 0));
            Icons.Add(new IcoListData("Autoruns", Resources.autoruns, "autoruns.exe", 0));
        }*/

    }
}
