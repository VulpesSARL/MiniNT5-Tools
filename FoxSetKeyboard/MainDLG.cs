using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoxSetKeyboard
{
    public partial class MainDLG : Form
    {
        List<Fox.FoxKeyboardLayout> layouts;
        public MainDLG()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadList()
        {
            lstKeyboards.Items.Clear();
            foreach (Fox.FoxKeyboardLayout layout in layouts)
            {
                if (txtSearch.Text.Trim() != "")
                {
                    if (layout.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) == true)
                        lstKeyboards.Items.Add(layout);
                }
                else
                {
                    lstKeyboards.Items.Add(layout);
                }
            }
        }

        private void MainDLG_Load(object sender, EventArgs e)
        {
            this.Font = SystemFonts.CaptionFont;
            this.CenterToScreen();
            
            layouts = Fox.FoxCWrapper.KeyboardLayoutGetList();
            Fox.FoxKeyboardLayout current = Fox.FoxCWrapper.KeyboardLayoutGetCurrent();
            LoadList();
            for (int i = 0; i < lstKeyboards.Items.Count; i++)
            {
                Fox.FoxKeyboardLayout layout = (Fox.FoxKeyboardLayout)lstKeyboards.Items[i];
                if (layout.ID == current.ID)
                {
                    lstKeyboards.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstKeyboards.SelectedIndex == -1)
                return;
            Fox.FoxKeyboardLayout layout = (Fox.FoxKeyboardLayout)lstKeyboards.Items[lstKeyboards.SelectedIndex];
            int res = Fox.FoxCWrapper.KeyboardLayoutSet(layout.ID);
            if (res != 0)
            {
                MessageBox.Show(this, "Error setting the layout. (" + res.ToString() + ")", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
