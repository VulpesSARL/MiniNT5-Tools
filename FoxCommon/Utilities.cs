using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fox.Common
{
    public class Utilities
    {
        public static DialogResult MessageBoxInvoke(Form owner, string msg, string caption, MessageBoxButtons buttons, MessageBoxIcon image)
        {
            if (owner.InvokeRequired == true)
                return ((DialogResult)owner.Invoke(new Func<DialogResult>(() => MessageBoxInvoke(owner, msg, caption, buttons, image))));

            return (System.Windows.Forms.MessageBox.Show(owner, msg, caption, buttons, image));
        }
    }
}
