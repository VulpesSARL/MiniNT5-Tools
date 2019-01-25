using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fox.Common;

namespace FoxShell
{
    public partial class frmItemProperty : Form
    {
        IcoListData ico;

        public frmItemProperty(IcoListData i)
        {
            ico = i;
            InitializeComponent();
        }

        public frmItemProperty()
        {
            ico = null;
            InitializeComponent();
        }

        private void cmdBrowseExec_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = "Browse for Executable";
            frm.Filter = "Executables|*.exe|All files|*.*";
            frm.CheckFileExists = true;
            if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtExec.Text = frm.FileName;
        }

        private void cmdBrowseIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = "Browse for Icon";
            frm.Filter = "Known icons|*.exe;*.dll;*.ico|All files|*.*";
            frm.CheckFileExists = true;
            if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            txtIcon.Text = frm.FileName;
        }

        private void frmItemProperty_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToParent();
            lstType.Items.Add("User");
            lstType.Items.Add("System");
            foreach (string s in Program.maindlg.icolist.Groups)
            {
                lstGroup.Items.Add(s);
            }

            if (ico == null)
            {
                this.Text = "New icon";
                lstType.SelectedIndex = 0;
            }
            else
            {
                this.Text = "Edit icon";
                txtExec.Text = ico.Execute;
                txtIcon.Text = ico.IcoFile;
                txtName.Text = ico.Name;
                txtOrder.Text = ico.Order.ToString();
                lstGroup.Text = ico.Group;
                txtID.Text = ico.ID;
                chkUseShellEx.Checked = ico.UseShellEx;
                if (ico.Type == IcoListRegType.User)
                    lstType.SelectedIndex = 0;
                else
                    lstType.SelectedIndex = 1;
                lstType.Enabled = false;
                txtID.Enabled = false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            int Order;
            if (int.TryParse(txtOrder.Text, out Order) == false)
            {
                MessageBox.Show(this, "Invalid Order number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ico == null)
            {
                IcoListData icon = new IcoListData(txtID.Text, txtName.Text, lstGroup.Text, txtIcon.Text, txtExec.Text, Order, chkUseShellEx.Checked,
                    lstType.SelectedIndex == 0 ? IcoListRegType.User : IcoListRegType.System);
                if (icon.InitSuccess == false)
                {
                    MessageBox.Show(this, "Some data are not complete", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Program.maindlg.icolist.IDExists(icon.ID, icon.Type) == true)
                {
                    MessageBox.Show(this, "The ID "+ico.ID+" already exists", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Program.maindlg.icolist.AddIcon(icon.ID, icon.Name, icon.Group, icon.IcoFile, icon.Execute, icon.Order, icon.UseShellEx, icon.Type);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                IcoListData icon = new IcoListData(txtID.Text, txtName.Text, lstGroup.Text, txtIcon.Text, txtExec.Text, Order, chkUseShellEx.Checked,
                    lstType.SelectedIndex == 0 ? IcoListRegType.User : IcoListRegType.System);
                if (icon.InitSuccess == false)
                {
                    MessageBox.Show(this, "Some data are not complete", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Program.maindlg.icolist.AddIcon(icon.ID, icon.Name, icon.Group, icon.IcoFile, icon.Execute, icon.Order, icon.UseShellEx, icon.Type);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
