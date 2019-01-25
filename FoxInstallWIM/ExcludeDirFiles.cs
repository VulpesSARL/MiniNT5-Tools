using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoxMultiWIM
{
    public partial class frmExcludeDirFiles : Form
    {
        public frmExcludeDirFiles()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExcludeDirFiles_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToParent();
            foreach (string s in Program.ExcludeFiles)
                lstFiles.Items.Add(s);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtAddFile.Text.Trim() == "")
                return;
            lstFiles.Items.Add(txtAddFile.Text);
            txtAddFile.Text = "";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex == -1)
                return;
            lstFiles.Items.RemoveAt(lstFiles.SelectedIndex);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Program.ExcludeFiles.Clear();
            foreach (string s in lstFiles.Items)
                Program.ExcludeFiles.Add(s);
            this.Close();
        }
    }
}
