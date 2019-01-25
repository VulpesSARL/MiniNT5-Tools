using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fox.Common.Properties;
using Microsoft.Win32;

namespace Fox.Common
{

    #region Declarations

    [Serializable]
    public enum IcoListRegType
    {
        User,
        System
    }

    [Serializable]
    public enum IcoListAction
    {
        Add,
        Delete,
        Nix
    }

    [Serializable]
    public class IcoListData
    {
        public IcoListRegType Type = IcoListRegType.User;
        public IcoListAction Action = IcoListAction.Nix;
        public string ID;
        public string Name;
        public string Group;
        [NonSerialized]
        public Icon Ico;
        public string IcoFile;
        public string Execute;
        public int Order;
        public bool InitSuccess = false;
        public bool UseShellEx = false;
        public IcoListData()
        {

        }
        public IcoListData(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t)
        {
            Type = t;
            ID = id;
            Name = name;
            Group = group;
            IcoFile = icofile;
            Execute = exec;
            Order = order;
            UseShellEx = ShellEx;
            InitSuccess = true;
            try
            {
                string FullPath = FileTools.GetFullPath(Environment.ExpandEnvironmentVariables(IcoFile));
                if (FullPath != null)
                    Ico = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables(FullPath));
                else
                    Ico = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables(IcoFile));
                if (Ico == null)
                    Ico = Resources.exec;
            }
            catch
            {
                Ico = Resources.exec;
            }
        }

        public IcoListData(string id, IcoListRegType t, RegistryKey reg)
        {
            Type = t;
            ID = id;
            Name = Convert.ToString(reg.GetValue("Name", ""));
            if (Name == "")
                return;
            Group = Convert.ToString(reg.GetValue("Group", ""));
            if (Group == "")
                return;
            IcoFile = Convert.ToString(reg.GetValue("IcoFile", ""));
            if (IcoFile == "")
                return;
            Execute = Convert.ToString(reg.GetValue("Execute", ""));
            if (Execute == "")
                return;
            try
            {
                Order = Convert.ToInt32(reg.GetValue("Order"));
            }
            catch
            {
                return;
            }
            try
            {
                UseShellEx = Convert.ToInt32(reg.GetValue("UseShellEx")) == 1 ? true : false;
            }
            catch
            {

            }
            InitSuccess = true;
            try
            {
                string FullPath = FileTools.GetFullPath(Environment.ExpandEnvironmentVariables(IcoFile));
                if (FullPath != null)
                    Ico = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables(FullPath));
                else
                    Ico = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables(IcoFile));
                if (Ico == null)
                    Ico = Resources.exec;
            }
            catch
            {
                Ico = Resources.exec;
            }
        }
    }

    #endregion

    #region NamedPipes Communications

    public class IcoListNamedPipes
    {
        const string PipeName = "Fox-Shell Comm Pipe";

        static NamedPipeClientStream ConnectPipe()
        {
            try
            {
                NamedPipeClientStream pipe = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut);
                pipe.Connect(1000);
                return (pipe);
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                return (null);
            }
        }

        public static void DeleteIcon(string ID, IcoListRegType Type)
        {
            NamedPipeClientStream pipe = ConnectPipe();
            if (pipe == null)
                return;
            IcoListData ico = new IcoListData();
            ico.Action = IcoListAction.Delete;
            ico.ID = ID;
            ico.Type = Type;
            XmlSerializer ser = new XmlSerializer(typeof(IcoListData));
            ser.Serialize(pipe, ico);
            pipe.Flush();
            pipe.Close();
        }

        public static void AddIcon(string id, string name, string group, string icofile, string exec, int order, bool ShellEx, IcoListRegType t)
        {
            NamedPipeClientStream pipe = ConnectPipe();
            if (pipe == null)
                return;
            IcoListData ico = new IcoListData(id, name, group, icofile, exec, order, ShellEx, t);
            ico.Action = IcoListAction.Add;
            XmlSerializer ser = new XmlSerializer(typeof(IcoListData));
            ser.Serialize(pipe, ico);
            pipe.Flush();
            pipe.Close();
        }

    }

    #endregion
}
