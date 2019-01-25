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
    public partial class frmSelectEdition : Form
    {
        public uint SelectedIndex;
        public string SelectedString;
        string Filename;

        public frmSelectEdition(string filename)
        {
            Filename = filename;
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstEditions.SelectedItems.Count == 0)
                return;
            SelectedIndex = (uint)lstEditions.SelectedItems[0].Tag;
            SelectedString = lstEditions.SelectedItems[0].SubItems[1].Text + ", " + lstEditions.SelectedItems[0].SubItems[2].Text+", "+
                lstEditions.SelectedItems[0].SubItems[3].Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmSelectEdition_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToParent();
            List<Fox.FoxDismImageInfo> lst = Fox.FoxCWrapperDISM.DISMGetInfo(Filename);
            foreach (Fox.FoxDismImageInfo l in lst)
            {
                ListViewItem li = new ListViewItem(l.ImageIndex.ToString ());
                li.Tag = l.ImageIndex;
                li.SubItems.Add(l.ImageDescription);
                li.SubItems.Add(Fox.FoxCWrapperDISM.DISMDecodeArchitecture(l.Architecture));
                li.SubItems.Add(l.Language.Count > 0 ? l.Language[0] : "");
                lstEditions.Items.Add(li);
            }
        }

        private void lstEditions_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(sender, e);
        }
    }
}
