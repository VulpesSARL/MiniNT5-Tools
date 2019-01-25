namespace FoxShell
{
    partial class frmShutDown
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.radShutdown = new System.Windows.Forms.RadioButton();
            this.radRestart = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(182, 67);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(101, 67);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // radShutdown
            // 
            this.radShutdown.AutoSize = true;
            this.radShutdown.Checked = true;
            this.radShutdown.Location = new System.Drawing.Point(23, 12);
            this.radShutdown.Name = "radShutdown";
            this.radShutdown.Size = new System.Drawing.Size(73, 17);
            this.radShutdown.TabIndex = 0;
            this.radShutdown.TabStop = true;
            this.radShutdown.Text = "&Shutdown";
            this.radShutdown.UseVisualStyleBackColor = true;
            // 
            // radRestart
            // 
            this.radRestart.AutoSize = true;
            this.radRestart.Location = new System.Drawing.Point(23, 35);
            this.radRestart.Name = "radRestart";
            this.radRestart.Size = new System.Drawing.Size(59, 17);
            this.radRestart.TabIndex = 1;
            this.radRestart.Text = "&Restart";
            this.radRestart.UseVisualStyleBackColor = true;
            // 
            // frmShutDown
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(267, 99);
            this.Controls.Add(this.radRestart);
            this.Controls.Add(this.radShutdown);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShutDown";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shutdown";
            this.Load += new System.EventHandler(this.frmShutDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.RadioButton radShutdown;
        private System.Windows.Forms.RadioButton radRestart;
    }
}