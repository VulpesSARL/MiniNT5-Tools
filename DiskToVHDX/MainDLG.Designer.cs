namespace FoxDiskToVHDX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDLG));
            this.lstDisks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowseVHDX = new System.Windows.Forms.Button();
            this.txtVHDXFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressb = new System.Windows.Forms.ProgressBar();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.BGW = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDisks
            // 
            this.lstDisks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDisks.FormattingEnabled = true;
            this.lstDisks.Location = new System.Drawing.Point(109, 11);
            this.lstDisks.Name = "lstDisks";
            this.lstDisks.Size = new System.Drawing.Size(467, 21);
            this.lstDisks.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disk to read:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write to:";
            // 
            // cmdBrowseVHDX
            // 
            this.cmdBrowseVHDX.Location = new System.Drawing.Point(501, 36);
            this.cmdBrowseVHDX.Name = "cmdBrowseVHDX";
            this.cmdBrowseVHDX.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseVHDX.TabIndex = 2;
            this.cmdBrowseVHDX.Text = "Browse";
            this.cmdBrowseVHDX.UseVisualStyleBackColor = true;
            this.cmdBrowseVHDX.Click += new System.EventHandler(this.cmdBrowseVHDX_Click);
            // 
            // txtVHDXFile
            // 
            this.txtVHDXFile.Location = new System.Drawing.Point(109, 38);
            this.txtVHDXFile.Name = "txtVHDXFile";
            this.txtVHDXFile.Size = new System.Drawing.Size(386, 20);
            this.txtVHDXFile.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtVHDXFile);
            this.panel1.Controls.Add(this.lstDisks);
            this.panel1.Controls.Add(this.cmdBrowseVHDX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 76);
            this.panel1.TabIndex = 0;
            // 
            // progressb
            // 
            this.progressb.Location = new System.Drawing.Point(12, 148);
            this.progressb.Name = "progressb";
            this.progressb.Size = new System.Drawing.Size(564, 26);
            this.progressb.TabIndex = 7;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(501, 91);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(501, 180);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // BGW
            // 
            this.BGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_DoWork);
            this.BGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RunWorkerCompleted);
            // 
            // MainDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 219);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.progressb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fox Disk to VHDX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDLG_FormClosing);
            this.Load += new System.EventHandler(this.MainDLG_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lstDisks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowseVHDX;
        private System.Windows.Forms.TextBox txtVHDXFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressb;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdCancel;
        private System.ComponentModel.BackgroundWorker BGW;
    }
}

