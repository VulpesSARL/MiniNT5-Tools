namespace FoxShell
{
    partial class frmItemProperty
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkUseShellEx = new System.Windows.Forms.CheckBox();
            this.lstGroup = new System.Windows.Forms.ComboBox();
            this.lstType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdBrowseExec = new System.Windows.Forms.Button();
            this.cmdBrowseIcon = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Group:";
            // 
            // txtExec
            // 
            this.txtExec.Location = new System.Drawing.Point(86, 83);
            this.txtExec.Name = "txtExec";
            this.txtExec.Size = new System.Drawing.Size(267, 20);
            this.txtExec.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Executable:";
            // 
            // txtIcon
            // 
            this.txtIcon.Location = new System.Drawing.Point(86, 109);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(267, 20);
            this.txtIcon.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Icon:";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(86, 142);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(67, 20);
            this.txtOrder.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order:";
            // 
            // chkUseShellEx
            // 
            this.chkUseShellEx.AutoSize = true;
            this.chkUseShellEx.Location = new System.Drawing.Point(86, 180);
            this.chkUseShellEx.Name = "chkUseShellEx";
            this.chkUseShellEx.Size = new System.Drawing.Size(113, 17);
            this.chkUseShellEx.TabIndex = 8;
            this.chkUseShellEx.Text = "Use &Shell Execute";
            this.chkUseShellEx.UseVisualStyleBackColor = true;
            // 
            // lstGroup
            // 
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.Location = new System.Drawing.Point(86, 57);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(267, 21);
            this.lstGroup.TabIndex = 2;
            // 
            // lstType
            // 
            this.lstType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstType.FormattingEnabled = true;
            this.lstType.Location = new System.Drawing.Point(86, 213);
            this.lstType.Name = "lstType";
            this.lstType.Size = new System.Drawing.Size(267, 21);
            this.lstType.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Type:";
            // 
            // cmdBrowseExec
            // 
            this.cmdBrowseExec.Location = new System.Drawing.Point(359, 81);
            this.cmdBrowseExec.Name = "cmdBrowseExec";
            this.cmdBrowseExec.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseExec.TabIndex = 4;
            this.cmdBrowseExec.Text = "Browse";
            this.cmdBrowseExec.UseVisualStyleBackColor = true;
            this.cmdBrowseExec.Click += new System.EventHandler(this.cmdBrowseExec_Click);
            // 
            // cmdBrowseIcon
            // 
            this.cmdBrowseIcon.Location = new System.Drawing.Point(359, 107);
            this.cmdBrowseIcon.Name = "cmdBrowseIcon";
            this.cmdBrowseIcon.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseIcon.TabIndex = 6;
            this.cmdBrowseIcon.Text = "Browse";
            this.cmdBrowseIcon.UseVisualStyleBackColor = true;
            this.cmdBrowseIcon.Click += new System.EventHandler(this.cmdBrowseIcon_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(278, 249);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(359, 249);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(86, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(267, 20);
            this.txtID.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "ID:";
            // 
            // frmItemProperty
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(441, 284);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBrowseIcon);
            this.Controls.Add(this.cmdBrowseExec);
            this.Controls.Add(this.lstType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstGroup);
            this.Controls.Add(this.chkUseShellEx);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemProperty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ItemProperty";
            this.Load += new System.EventHandler(this.frmItemProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkUseShellEx;
        private System.Windows.Forms.ComboBox lstGroup;
        private System.Windows.Forms.ComboBox lstType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdBrowseExec;
        private System.Windows.Forms.Button cmdBrowseIcon;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
    }
}