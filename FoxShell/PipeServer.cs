using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Fox.Common;

namespace FoxShell
{
    static class PipeServer
    {
        static Thread SrvThread;
        static NamedPipeServerStream Pipe = null;
        static bool StopThread = false;
        const string PipeName = "Fox-Shell Comm Pipe";
        static ManualResetEvent cancel;

        #region Hack
        public static void WaitForConnectionEx(this NamedPipeServerStream stream, ManualResetEvent cancelEvent)
        {
            Exception e = null;
            AutoResetEvent connectEvent = new AutoResetEvent(false);
            stream.BeginWaitForConnection(ar =>
            {
                try
                {
                    stream.EndWaitForConnection(ar);
                }
                catch (Exception er)
                {
                    e = er;
                }
                connectEvent.Set();
            }, null);
            if (WaitHandle.WaitAny(new WaitHandle[] { connectEvent, cancelEvent }) == 1)
                stream.Close();
            if (e != null)
                throw e; // rethrow exception
        }
        #endregion

        public static void StartPipeServer()
        {
            StopThread = false;
            cancel = new ManualResetEvent(false);
            SrvThread = new Thread(new ThreadStart(PipeServerThread));
            SrvThread.Start();
        }

        public static void StopPipeServer()
        {
            if (Pipe != null)
            {
                StopThread = true;
                Pipe.Close();
                Pipe = null;
                cancel.Set();
            }
            Thread.Sleep(100);
            SrvThread.Abort();
        }

        static void PipeServerThread()
        {
            try
            {
                Pipe = new NamedPipeServerStream(PipeName, PipeDirection.InOut,10,  PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                do
                {
                    try
                    {
                        if (StopThread == true)
                            break;
                        Pipe.WaitForConnectionEx(cancel);
                        XmlSerializer reader = new XmlSerializer(typeof(IcoListData));
                        IcoListData i = new IcoListData();
                        i = (IcoListData)reader.Deserialize(Pipe);
                        switch (i.Action)
                        {
                            case IcoListAction.Delete:
                                Program.maindlg.THREADDeleteIcon(i.ID, i.Type);
                                break;
                            case IcoListAction.Add:
                                Program.maindlg.THREADAddIcon(i.ID, i.Name, i.Group, i.IcoFile, i.Execute, i.Order, i.UseShellEx, i.Type);
                                break;
                        }
                        Pipe.Disconnect();
                    }
                    catch (Exception ee)
                    {
                        Debug.WriteLine("INNER CATCH");
                        Debug.WriteLine(ee.ToString());
                    }
                }
                while (true);
            }
            catch (Exception ee)
            {
                Debug.WriteLine("OUTER CATCH");
                Debug.WriteLine(ee.ToString());
            }
        }
    }
}
