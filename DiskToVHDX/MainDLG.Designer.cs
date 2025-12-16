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
            this.lstDisksRead = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowseVHDXWrite = new System.Windows.Forms.Button();
            this.txtVHDXFileWrite = new System.Windows.Forms.TextBox();
            this.progressb = new System.Windows.Forms.ProgressBar();
            this.cmdStartReadDisk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.BGW_D_to_VHDX = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lstDisksWrite = new System.Windows.Forms.ComboBox();
            this.cmdStartWriteDisk = new System.Windows.Forms.Button();
            this.txtVHDXFileRead = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdBrowseVHDXRead = new System.Windows.Forms.Button();
            this.BGW_VHDX_to_D = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDisksRead
            // 
            this.lstDisksRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDisksRead.FormattingEnabled = true;
            this.lstDisksRead.Location = new System.Drawing.Point(112, 11);
            this.lstDisksRead.Name = "lstDisksRead";
            this.lstDisksRead.Size = new System.Drawing.Size(467, 21);
            this.lstDisksRead.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disk to read:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write to:";
            // 
            // cmdBrowseVHDXWrite
            // 
            this.cmdBrowseVHDXWrite.Location = new System.Drawing.Point(504, 36);
            this.cmdBrowseVHDXWrite.Name = "cmdBrowseVHDXWrite";
            this.cmdBrowseVHDXWrite.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseVHDXWrite.TabIndex = 2;
            this.cmdBrowseVHDXWrite.Text = "Browse";
            this.cmdBrowseVHDXWrite.UseVisualStyleBackColor = true;
            this.cmdBrowseVHDXWrite.Click += new System.EventHandler(this.cmdBrowseVHDX_Click);
            // 
            // txtVHDXFileWrite
            // 
            this.txtVHDXFileWrite.Location = new System.Drawing.Point(112, 38);
            this.txtVHDXFileWrite.Name = "txtVHDXFileWrite";
            this.txtVHDXFileWrite.Size = new System.Drawing.Size(386, 20);
            this.txtVHDXFileWrite.TabIndex = 1;
            // 
            // progressb
            // 
            this.progressb.Location = new System.Drawing.Point(12, 178);
            this.progressb.Name = "progressb";
            this.progressb.Size = new System.Drawing.Size(600, 26);
            this.progressb.TabIndex = 7;
            // 
            // cmdStartReadDisk
            // 
            this.cmdStartReadDisk.Location = new System.Drawing.Point(504, 91);
            this.cmdStartReadDisk.Name = "cmdStartReadDisk";
            this.cmdStartReadDisk.Size = new System.Drawing.Size(75, 23);
            this.cmdStartReadDisk.TabIndex = 1;
            this.cmdStartReadDisk.Text = "Start";
            this.cmdStartReadDisk.UseVisualStyleBackColor = true;
            this.cmdStartReadDisk.Click += new System.EventHandler(this.cmdStartReadDisk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(537, 210);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // BGW_D_to_VHDX
            // 
            this.BGW_D_to_VHDX.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_D_to_VHDX_DoWork);
            this.BGW_D_to_VHDX.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 160);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstDisksRead);
            this.tabPage1.Controls.Add(this.cmdStartReadDisk);
            this.tabPage1.Controls.Add(this.txtVHDXFileWrite);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmdBrowseVHDXWrite);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 134);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Disk to VHDX";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lstDisksWrite);
            this.tabPage2.Controls.Add(this.cmdStartWriteDisk);
            this.tabPage2.Controls.Add(this.txtVHDXFileRead);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmdBrowseVHDXRead);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 134);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VHDX to Disk";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Disk to write to:";
            // 
            // lstDisksWrite
            // 
            this.lstDisksWrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDisksWrite.FormattingEnabled = true;
            this.lstDisksWrite.Location = new System.Drawing.Point(112, 38);
            this.lstDisksWrite.Name = "lstDisksWrite";
            this.lstDisksWrite.Size = new System.Drawing.Size(467, 21);
            this.lstDisksWrite.TabIndex = 4;
            // 
            // cmdStartWriteDisk
            // 
            this.cmdStartWriteDisk.Location = new System.Drawing.Point(504, 91);
            this.cmdStartWriteDisk.Name = "cmdStartWriteDisk";
            this.cmdStartWriteDisk.Size = new System.Drawing.Size(75, 23);
            this.cmdStartWriteDisk.TabIndex = 5;
            this.cmdStartWriteDisk.Text = "Start";
            this.cmdStartWriteDisk.UseVisualStyleBackColor = true;
            this.cmdStartWriteDisk.Click += new System.EventHandler(this.cmdStartWriteDisk_Click);
            // 
            // txtVHDXFileRead
            // 
            this.txtVHDXFileRead.Location = new System.Drawing.Point(112, 11);
            this.txtVHDXFileRead.Name = "txtVHDXFileRead";
            this.txtVHDXFileRead.Size = new System.Drawing.Size(386, 20);
            this.txtVHDXFileRead.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Read from:";
            // 
            // cmdBrowseVHDXRead
            // 
            this.cmdBrowseVHDXRead.Location = new System.Drawing.Point(504, 9);
            this.cmdBrowseVHDXRead.Name = "cmdBrowseVHDXRead";
            this.cmdBrowseVHDXRead.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseVHDXRead.TabIndex = 8;
            this.cmdBrowseVHDXRead.Text = "Browse";
            this.cmdBrowseVHDXRead.UseVisualStyleBackColor = true;
            this.cmdBrowseVHDXRead.Click += new System.EventHandler(this.cmdBrowseVHDXRead_Click);
            // 
            // BGW_VHDX_to_D
            // 
            this.BGW_VHDX_to_D.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_VHDX_to_D_DoWork);
            this.BGW_VHDX_to_D.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RunWorkerCompleted);
            // 
            // MainDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 246);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.progressb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fox Disk to VHDX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDLG_FormClosing);
            this.Load += new System.EventHandler(this.MainDLG_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lstDisksRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowseVHDXWrite;
        private System.Windows.Forms.TextBox txtVHDXFileWrite;
        private System.Windows.Forms.ProgressBar progressb;
        private System.Windows.Forms.Button cmdStartReadDisk;
        private System.Windows.Forms.Button cmdCancel;
        private System.ComponentModel.BackgroundWorker BGW_D_to_VHDX;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstDisksWrite;
        private System.Windows.Forms.Button cmdStartWriteDisk;
        private System.Windows.Forms.TextBox txtVHDXFileRead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdBrowseVHDXRead;
        private System.ComponentModel.BackgroundWorker BGW_VHDX_to_D;
    }
}

