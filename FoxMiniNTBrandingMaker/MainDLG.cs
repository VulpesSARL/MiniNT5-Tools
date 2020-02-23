using Fox.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxMiniNTBrandingMaker
{
    public partial class MainDLG : Form
    {
        public MainDLG()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog cmdlg = new OpenFileDialog();
            cmdlg.Filter = "Supported pictures|*.bmp;*.png;*.jpg;*.tif;*.tiff;*.jpeg";
            cmdlg.Title = "Select OEM Logo picture";
            cmdlg.CheckFileExists = true;
            cmdlg.Multiselect = false;
            if (cmdlg.ShowDialog(this) != DialogResult.OK)
                return;
            Image bmp = Bitmap.FromFile(cmdlg.FileName);
            if (bmp.Width != 120 || bmp.Height != 120)
            {
                MessageBox.Show(this, "Picture must be 120x120 in size", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            picOEM.Image = bmp;
        }

        private void cmdCreateDNS_Click(object sender, EventArgs e)
        {
            if (picOEM.Image == null)
            {
                MessageBox.Show(this, "Picture is needed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtManufacturer.Text.Trim() == "")
            {
                MessageBox.Show(this, "Manufacturer is needed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtSupportPhone.Text.Trim() == "")
            {
                MessageBox.Show(this, "Support Phone is needed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtSupportURL.Text.Trim() == "")
            {
                MessageBox.Show(this, "Support URL is needed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MemoryStream picmem = new MemoryStream();
            picOEM.Image.Save(picmem, ImageFormat.Png);
            picmem.Seek(0, SeekOrigin.Begin);
            byte[] picraw = new byte[picmem.Length];
            picmem.Read(picraw, 0, picraw.Length);

            txtManufacturer.Text = txtManufacturer.Text.Replace("|", "").Trim();
            txtSupportPhone.Text = txtSupportPhone.Text.Replace("|", "").Trim();
            txtSupportURL.Text = txtSupportURL.Text.Replace("|", "").Trim();

            string FullData = Convert.ToBase64String(picraw) + "|" +
                Convert.ToBase64String(Encoding.UTF8.GetBytes(txtManufacturer.Text)) + "|" +
                Convert.ToBase64String(Encoding.UTF8.GetBytes(txtSupportPhone.Text)) + "|" +
                Convert.ToBase64String(Encoding.UTF8.GetBytes(txtSupportURL.Text));

            Crc32 crc32 = new Crc32();
            byte[] crc = crc32.ComputeHash(Encoding.ASCII.GetBytes(FullData));

            string CRCStr = "";
            foreach (byte c in crc)
                CRCStr += c.ToString("X2");

            string DNSBlock = "";
            int NumBlocks = 0;

            DNSBlock += "Insert these TXT Records (multiple lines) as\r\n\r\n" +
                "minint-branding.my-vulpes-config.lu\r\n\r\n";

            for (int i = 0; i < FullData.Length; i += 200)
            {
                if (i + 200 > FullData.Length)
                    DNSBlock += "MININTBR" + NumBlocks.ToString("X2") + "=" + FullData.Substring(i)+"\r\n";
                else
                    DNSBlock += "MININTBR" + NumBlocks.ToString("X2") + "=" + FullData.Substring(i, 200) + "\r\n";
                NumBlocks++;
            }

            DNSBlock += "MININTBR=" + NumBlocks.ToString() + "," + CRCStr + "\r\n";

            txtOutput.Text = DNSBlock;
        }
    }
}
