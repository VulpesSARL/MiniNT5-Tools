using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoxShell
{
    public partial class frmShutDown : Form
    {
        public bool Restart = false;

        public frmShutDown()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Restart = radRestart.Checked;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmShutDown_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToParent();
        }
    }
}
