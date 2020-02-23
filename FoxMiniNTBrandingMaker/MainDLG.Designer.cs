namespace FoxMiniNTBrandingMaker
{
    partial class MainDLG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.picOEM = new System.Windows.Forms.PictureBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtSupportPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupportURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.cmdCreateDNS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOEM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Picture:";
            // 
            // picOEM
            // 
            this.picOEM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOEM.Location = new System.Drawing.Point(135, 12);
            this.picOEM.Margin = new System.Windows.Forms.Padding(0);
            this.picOEM.Name = "picOEM";
            this.picOEM.Size = new System.Drawing.Size(120, 120);
            this.picOEM.TabIndex = 1;
            this.picOEM.TabStop = false;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(290, 109);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 0;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "120x120 in Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manufacturer:";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(135, 151);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(279, 20);
            this.txtManufacturer.TabIndex = 1;
            // 
            // txtSupportPhone
            // 
            this.txtSupportPhone.Location = new System.Drawing.Point(135, 177);
            this.txtSupportPhone.Name = "txtSupportPhone";
            this.txtSupportPhone.Size = new System.Drawing.Size(279, 20);
            this.txtSupportPhone.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Support Phone:";
            // 
            // txtSupportURL
            // 
            this.txtSupportURL.Location = new System.Drawing.Point(135, 203);
            this.txtSupportURL.Name = "txtSupportURL";
            this.txtSupportURL.Size = new System.Drawing.Size(279, 20);
            this.txtSupportURL.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Support URL:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hint: Computermodel && Serialnumber can be filled within MiniNT";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 296);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(517, 258);
            this.txtOutput.TabIndex = 5;
            // 
            // cmdCreateDNS
            // 
            this.cmdCreateDNS.Location = new System.Drawing.Point(15, 267);
            this.cmdCreateDNS.Name = "cmdCreateDNS";
            this.cmdCreateDNS.Size = new System.Drawing.Size(179, 23);
            this.cmdCreateDNS.TabIndex = 4;
            this.cmdCreateDNS.Text = "Create DNS TXT Records";
            this.cmdCreateDNS.UseVisualStyleBackColor = true;
            this.cmdCreateDNS.Click += new System.EventHandler(this.cmdCreateDNS_Click);
            // 
            // MainDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 569);
            this.Controls.Add(this.cmdCreateDNS);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSupportURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSupportPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.picOEM);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDLG";
            this.Text = "Fox - MiniNT Branding Maker";
            ((System.ComponentModel.ISupportInitialize)(this.picOEM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOEM;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtSupportPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupportURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button cmdCreateDNS;
    }
}

