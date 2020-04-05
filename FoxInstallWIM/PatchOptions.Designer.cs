namespace FoxMultiWIM
{
    partial class frmPatchOptions
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkDisableOneDrive = new System.Windows.Forms.CheckBox();
            this.chkDisableCloudContent = new System.Windows.Forms.CheckBox();
            this.grpBranding = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.chkApplyBranding = new System.Windows.Forms.CheckBox();
            this.chkDisablePrivacy = new System.Windows.Forms.CheckBox();
            this.chkDisableFileRegVirtualization = new System.Windows.Forms.CheckBox();
            this.chkDisableTelemetry = new System.Windows.Forms.CheckBox();
            this.chkDisableMSAccount = new System.Windows.Forms.CheckBox();
            this.chkNoCortana = new System.Windows.Forms.CheckBox();
            this.chkUAC = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRegCompany = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegOwner = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInitialUsernameDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInitialUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstTimeZone = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstKeyboardFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRegionFormat = new System.Windows.Forms.ComboBox();
            this.chkConfigOOBE = new System.Windows.Forms.CheckBox();
            this.chkInstallSDC = new System.Windows.Forms.CheckBox();
            this.chkPatchMachineID = new System.Windows.Forms.CheckBox();
            this.chkApplyContract = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpBranding.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(475, 445);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(556, 445);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkApplyContract);
            this.tabPage1.Controls.Add(this.chkPatchMachineID);
            this.tabPage1.Controls.Add(this.chkInstallSDC);
            this.tabPage1.Controls.Add(this.chkDisableOneDrive);
            this.tabPage1.Controls.Add(this.chkDisableCloudContent);
            this.tabPage1.Controls.Add(this.grpBranding);
            this.tabPage1.Controls.Add(this.chkApplyBranding);
            this.tabPage1.Controls.Add(this.chkDisablePrivacy);
            this.tabPage1.Controls.Add(this.chkDisableFileRegVirtualization);
            this.tabPage1.Controls.Add(this.chkDisableTelemetry);
            this.tabPage1.Controls.Add(this.chkDisableMSAccount);
            this.tabPage1.Controls.Add(this.chkNoCortana);
            this.tabPage1.Controls.Add(this.chkUAC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkDisableOneDrive
            // 
            this.chkDisableOneDrive.AutoSize = true;
            this.chkDisableOneDrive.Location = new System.Drawing.Point(6, 167);
            this.chkDisableOneDrive.Name = "chkDisableOneDrive";
            this.chkDisableOneDrive.Size = new System.Drawing.Size(112, 17);
            this.chkDisableOneDrive.TabIndex = 7;
            this.chkDisableOneDrive.Text = "Disable One-Drive";
            this.chkDisableOneDrive.UseVisualStyleBackColor = true;
            // 
            // chkDisableCloudContent
            // 
            this.chkDisableCloudContent.AutoSize = true;
            this.chkDisableCloudContent.Location = new System.Drawing.Point(6, 144);
            this.chkDisableCloudContent.Name = "chkDisableCloudContent";
            this.chkDisableCloudContent.Size = new System.Drawing.Size(196, 17);
            this.chkDisableCloudContent.TabIndex = 6;
            this.chkDisableCloudContent.Text = "Disable Cloud Content (if applicable)";
            this.chkDisableCloudContent.UseVisualStyleBackColor = true;
            // 
            // grpBranding
            // 
            this.grpBranding.Controls.Add(this.label9);
            this.grpBranding.Controls.Add(this.txtSerialNumber);
            this.grpBranding.Controls.Add(this.label8);
            this.grpBranding.Controls.Add(this.txtModel);
            this.grpBranding.Location = new System.Drawing.Point(34, 223);
            this.grpBranding.Name = "grpBranding";
            this.grpBranding.Size = new System.Drawing.Size(498, 79);
            this.grpBranding.TabIndex = 9;
            this.grpBranding.TabStop = false;
            this.grpBranding.Text = "Computer Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Serialnumber:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(91, 45);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(401, 20);
            this.txtSerialNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(91, 19);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(401, 20);
            this.txtModel.TabIndex = 0;
            // 
            // chkApplyBranding
            // 
            this.chkApplyBranding.AutoSize = true;
            this.chkApplyBranding.Location = new System.Drawing.Point(34, 200);
            this.chkApplyBranding.Name = "chkApplyBranding";
            this.chkApplyBranding.Size = new System.Drawing.Size(97, 17);
            this.chkApplyBranding.TabIndex = 8;
            this.chkApplyBranding.Text = "Apply Branding";
            this.chkApplyBranding.UseVisualStyleBackColor = true;
            this.chkApplyBranding.CheckedChanged += new System.EventHandler(this.chkApplyBranding_CheckedChanged);
            // 
            // chkDisablePrivacy
            // 
            this.chkDisablePrivacy.AutoSize = true;
            this.chkDisablePrivacy.Location = new System.Drawing.Point(6, 121);
            this.chkDisablePrivacy.Name = "chkDisablePrivacy";
            this.chkDisablePrivacy.Size = new System.Drawing.Size(163, 17);
            this.chkDisablePrivacy.TabIndex = 5;
            this.chkDisablePrivacy.Text = "Disable Privacy ask in OOBE";
            this.chkDisablePrivacy.UseVisualStyleBackColor = true;
            // 
            // chkDisableFileRegVirtualization
            // 
            this.chkDisableFileRegVirtualization.AutoSize = true;
            this.chkDisableFileRegVirtualization.Location = new System.Drawing.Point(6, 29);
            this.chkDisableFileRegVirtualization.Name = "chkDisableFileRegVirtualization";
            this.chkDisableFileRegVirtualization.Size = new System.Drawing.Size(366, 17);
            this.chkDisableFileRegVirtualization.TabIndex = 1;
            this.chkDisableFileRegVirtualization.Text = "Disable File/Registry virtualisation (WARNING: old programs may crash!)";
            this.chkDisableFileRegVirtualization.UseVisualStyleBackColor = true;
            // 
            // chkDisableTelemetry
            // 
            this.chkDisableTelemetry.AutoSize = true;
            this.chkDisableTelemetry.Location = new System.Drawing.Point(6, 98);
            this.chkDisableTelemetry.Name = "chkDisableTelemetry";
            this.chkDisableTelemetry.Size = new System.Drawing.Size(175, 17);
            this.chkDisableTelemetry.TabIndex = 4;
            this.chkDisableTelemetry.Text = "Disable Telemetry (if applicable)";
            this.chkDisableTelemetry.UseVisualStyleBackColor = true;
            // 
            // chkDisableMSAccount
            // 
            this.chkDisableMSAccount.AutoSize = true;
            this.chkDisableMSAccount.Location = new System.Drawing.Point(6, 75);
            this.chkDisableMSAccount.Name = "chkDisableMSAccount";
            this.chkDisableMSAccount.Size = new System.Drawing.Size(150, 17);
            this.chkDisableMSAccount.TabIndex = 3;
            this.chkDisableMSAccount.Text = "Disable Microsoft Account";
            this.chkDisableMSAccount.UseVisualStyleBackColor = true;
            // 
            // chkNoCortana
            // 
            this.chkNoCortana.AutoSize = true;
            this.chkNoCortana.Location = new System.Drawing.Point(6, 52);
            this.chkNoCortana.Name = "chkNoCortana";
            this.chkNoCortana.Size = new System.Drawing.Size(101, 17);
            this.chkNoCortana.TabIndex = 2;
            this.chkNoCortana.Text = "Disable Cortana";
            this.chkNoCortana.UseVisualStyleBackColor = true;
            // 
            // chkUAC
            // 
            this.chkUAC.AutoSize = true;
            this.chkUAC.Location = new System.Drawing.Point(6, 6);
            this.chkUAC.Name = "chkUAC";
            this.chkUAC.Size = new System.Drawing.Size(125, 17);
            this.chkUAC.TabIndex = 0;
            this.chkUAC.Text = "Put UAC to maximum";
            this.chkUAC.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.chkConfigOOBE);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRegCompany);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRegOwner);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtInitialUsernameDesc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtInitialUsername);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lstTimeZone);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lstKeyboardFormat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstRegionFormat);
            this.panel1.Location = new System.Drawing.Point(6, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 350);
            this.panel1.TabIndex = 5;
            // 
            // txtRegCompany
            // 
            this.txtRegCompany.Location = new System.Drawing.Point(132, 176);
            this.txtRegCompany.Name = "txtRegCompany";
            this.txtRegCompany.Size = new System.Drawing.Size(365, 20);
            this.txtRegCompany.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Registred Company:";
            // 
            // txtRegOwner
            // 
            this.txtRegOwner.Location = new System.Drawing.Point(132, 150);
            this.txtRegOwner.Name = "txtRegOwner";
            this.txtRegOwner.Size = new System.Drawing.Size(365, 20);
            this.txtRegOwner.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Registred Owner:";
            // 
            // txtInitialUsernameDesc
            // 
            this.txtInitialUsernameDesc.Location = new System.Drawing.Point(132, 110);
            this.txtInitialUsernameDesc.Name = "txtInitialUsernameDesc";
            this.txtInitialUsernameDesc.Size = new System.Drawing.Size(365, 20);
            this.txtInitialUsernameDesc.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Username description:";
            // 
            // txtInitialUsername
            // 
            this.txtInitialUsername.Location = new System.Drawing.Point(132, 84);
            this.txtInitialUsername.Name = "txtInitialUsername";
            this.txtInitialUsername.Size = new System.Drawing.Size(365, 20);
            this.txtInitialUsername.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Initial username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Time zone:";
            // 
            // lstTimeZone
            // 
            this.lstTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTimeZone.FormattingEnabled = true;
            this.lstTimeZone.Location = new System.Drawing.Point(132, 57);
            this.lstTimeZone.Name = "lstTimeZone";
            this.lstTimeZone.Size = new System.Drawing.Size(365, 21);
            this.lstTimeZone.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Keyboard layout:";
            // 
            // lstKeyboardFormat
            // 
            this.lstKeyboardFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstKeyboardFormat.FormattingEnabled = true;
            this.lstKeyboardFormat.Location = new System.Drawing.Point(132, 30);
            this.lstKeyboardFormat.Name = "lstKeyboardFormat";
            this.lstKeyboardFormat.Size = new System.Drawing.Size(365, 21);
            this.lstKeyboardFormat.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Regional format:";
            // 
            // lstRegionFormat
            // 
            this.lstRegionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstRegionFormat.FormattingEnabled = true;
            this.lstRegionFormat.Location = new System.Drawing.Point(132, 3);
            this.lstRegionFormat.Name = "lstRegionFormat";
            this.lstRegionFormat.Size = new System.Drawing.Size(365, 21);
            this.lstRegionFormat.TabIndex = 4;
            // 
            // chkConfigOOBE
            // 
            this.chkConfigOOBE.AutoSize = true;
            this.chkConfigOOBE.Location = new System.Drawing.Point(6, 6);
            this.chkConfigOOBE.Name = "chkConfigOOBE";
            this.chkConfigOOBE.Size = new System.Drawing.Size(104, 17);
            this.chkConfigOOBE.TabIndex = 4;
            this.chkConfigOOBE.Text = "Configure OOBE";
            this.chkConfigOOBE.UseVisualStyleBackColor = true;
            this.chkConfigOOBE.CheckedChanged += new System.EventHandler(this.chkConfigOOBE_CheckedChanged);
            // 
            // chkInstallSDC
            // 
            this.chkInstallSDC.AutoSize = true;
            this.chkInstallSDC.Location = new System.Drawing.Point(34, 308);
            this.chkInstallSDC.Name = "chkInstallSDC";
            this.chkInstallSDC.Size = new System.Drawing.Size(78, 17);
            this.chkInstallSDC.TabIndex = 10;
            this.chkInstallSDC.Text = "Install SDC";
            this.chkInstallSDC.UseVisualStyleBackColor = true;
            // 
            // chkPatchMachineID
            // 
            this.chkPatchMachineID.AutoSize = true;
            this.chkPatchMachineID.Location = new System.Drawing.Point(63, 331);
            this.chkPatchMachineID.Name = "chkPatchMachineID";
            this.chkPatchMachineID.Size = new System.Drawing.Size(186, 17);
            this.chkPatchMachineID.TabIndex = 11;
            this.chkPatchMachineID.Text = "Apply MachineID from this MiniNT";
            this.chkPatchMachineID.UseVisualStyleBackColor = true;
            // 
            // chkApplyContract
            // 
            this.chkApplyContract.AutoSize = true;
            this.chkApplyContract.Location = new System.Drawing.Point(63, 354);
            this.chkApplyContract.Name = "chkApplyContract";
            this.chkApplyContract.Size = new System.Drawing.Size(405, 17);
            this.chkApplyContract.TabIndex = 12;
            this.chkApplyContract.Text = "Apply ContractID && URL from this MiniNT (may get overwritten from DNS Config!)";
            this.chkApplyContract.UseVisualStyleBackColor = true;
            // 
            // frmPatchOptions
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(647, 476);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatchOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patch Options";
            this.Load += new System.EventHandler(this.frmPatchOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpBranding.ResumeLayout(false);
            this.grpBranding.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkDisableMSAccount;
        private System.Windows.Forms.CheckBox chkNoCortana;
        private System.Windows.Forms.CheckBox chkUAC;
        private System.Windows.Forms.CheckBox chkConfigOOBE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lstKeyboardFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lstRegionFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstTimeZone;
        private System.Windows.Forms.TextBox txtInitialUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDisableTelemetry;
        private System.Windows.Forms.TextBox txtInitialUsernameDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegOwner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDisableFileRegVirtualization;
        private System.Windows.Forms.CheckBox chkDisablePrivacy;
        private System.Windows.Forms.GroupBox grpBranding;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.CheckBox chkApplyBranding;
        private System.Windows.Forms.CheckBox chkDisableCloudContent;
        private System.Windows.Forms.CheckBox chkDisableOneDrive;
        private System.Windows.Forms.CheckBox chkInstallSDC;
        private System.Windows.Forms.CheckBox chkApplyContract;
        private System.Windows.Forms.CheckBox chkPatchMachineID;
    }
}