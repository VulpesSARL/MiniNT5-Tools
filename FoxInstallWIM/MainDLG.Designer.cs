namespace FoxMultiWIM
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
            this.chkNoApplySec = new System.Windows.Forms.CheckBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdSelectEdition = new System.Windows.Forms.Button();
            this.lblEdition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBrowseTarget = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowseSourceWIM = new System.Windows.Forms.Button();
            this.txtSourceWIMFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdPatchOptions = new System.Windows.Forms.Button();
            this.chkPrePatch = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstDestination = new System.Windows.Forms.ComboBox();
            this.grpDestDisk = new System.Windows.Forms.GroupBox();
            this.chkInstallBootLoader = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lstDiskSchema = new System.Windows.Forms.ComboBox();
            this.lstDisks = new System.Windows.Forms.ComboBox();
            this.grpDestFolder = new System.Windows.Forms.GroupBox();
            this.cmdBrowseInstallTempDir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInstallTempDir = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdBrowseCaptureTempDir = new System.Windows.Forms.Button();
            this.txtCaptureTempDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstCompression = new System.Windows.Forms.ComboBox();
            this.cmdListExcludeFiles = new System.Windows.Forms.Button();
            this.chkExcludeFiles = new System.Windows.Forms.CheckBox();
            this.cmdStartCapture = new System.Windows.Forms.Button();
            this.cmdBrowseSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdBrowseDestWIM = new System.Windows.Forms.Button();
            this.txtDestWIM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkInstallBootLoaderPLAIN = new System.Windows.Forms.CheckBox();
            this.chkAutoReboot = new System.Windows.Forms.CheckBox();
            this.grpStatus.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpDestDisk.SuspendLayout();
            this.grpDestFolder.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkNoApplySec
            // 
            this.chkNoApplySec.AutoSize = true;
            this.chkNoApplySec.Location = new System.Drawing.Point(81, 338);
            this.chkNoApplySec.Name = "chkNoApplySec";
            this.chkNoApplySec.Size = new System.Drawing.Size(177, 17);
            this.chkNoApplySec.TabIndex = 10;
            this.chkNoApplySec.Text = "Don\'t apply security informations";
            this.chkNoApplySec.UseVisualStyleBackColor = true;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(528, 323);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 11;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdSelectEdition
            // 
            this.cmdSelectEdition.Location = new System.Drawing.Point(528, 39);
            this.cmdSelectEdition.Name = "cmdSelectEdition";
            this.cmdSelectEdition.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectEdition.TabIndex = 3;
            this.cmdSelectEdition.Text = "Select";
            this.cmdSelectEdition.UseVisualStyleBackColor = true;
            this.cmdSelectEdition.Click += new System.EventHandler(this.cmdSelectEdition_Click);
            // 
            // lblEdition
            // 
            this.lblEdition.AutoEllipsis = true;
            this.lblEdition.Location = new System.Drawing.Point(78, 44);
            this.lblEdition.Name = "lblEdition";
            this.lblEdition.Size = new System.Drawing.Size(444, 13);
            this.lblEdition.TabIndex = 2;
            this.lblEdition.Text = "------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Edition:";
            // 
            // cmdBrowseTarget
            // 
            this.cmdBrowseTarget.Location = new System.Drawing.Point(525, 17);
            this.cmdBrowseTarget.Name = "cmdBrowseTarget";
            this.cmdBrowseTarget.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseTarget.TabIndex = 1;
            this.cmdBrowseTarget.Text = "Browse";
            this.cmdBrowseTarget.UseVisualStyleBackColor = true;
            this.cmdBrowseTarget.Click += new System.EventHandler(this.cmdBrowseTarget_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(78, 19);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(441, 20);
            this.txtTarget.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target:";
            // 
            // cmdBrowseSourceWIM
            // 
            this.cmdBrowseSourceWIM.Location = new System.Drawing.Point(528, 10);
            this.cmdBrowseSourceWIM.Name = "cmdBrowseSourceWIM";
            this.cmdBrowseSourceWIM.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseSourceWIM.TabIndex = 1;
            this.cmdBrowseSourceWIM.Text = "Browse";
            this.cmdBrowseSourceWIM.UseVisualStyleBackColor = true;
            this.cmdBrowseSourceWIM.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtSourceWIMFile
            // 
            this.txtSourceWIMFile.Location = new System.Drawing.Point(81, 12);
            this.txtSourceWIMFile.Name = "txtSourceWIMFile";
            this.txtSourceWIMFile.Size = new System.Drawing.Size(441, 20);
            this.txtSourceWIMFile.TabIndex = 0;
            this.txtSourceWIMFile.TextChanged += new System.EventHandler(this.txtWIMFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIM File:";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.cmdCancel);
            this.grpStatus.Controls.Add(this.progressBar);
            this.grpStatus.Controls.Add(this.lblFileStatus);
            this.grpStatus.Controls.Add(this.label4);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpStatus.Location = new System.Drawing.Point(0, 390);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(623, 83);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(534, 38);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(87, 41);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(441, 17);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.AutoEllipsis = true;
            this.lblFileStatus.Location = new System.Drawing.Point(84, 25);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.Size = new System.Drawing.Size(444, 13);
            this.lblFileStatus.TabIndex = 3;
            this.lblFileStatus.Text = "------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "File:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAutoReboot);
            this.tabPage1.Controls.Add(this.cmdPatchOptions);
            this.tabPage1.Controls.Add(this.chkPrePatch);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lstDestination);
            this.tabPage1.Controls.Add(this.grpDestDisk);
            this.tabPage1.Controls.Add(this.grpDestFolder);
            this.tabPage1.Controls.Add(this.chkNoApplySec);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmdStart);
            this.tabPage1.Controls.Add(this.txtSourceWIMFile);
            this.tabPage1.Controls.Add(this.cmdSelectEdition);
            this.tabPage1.Controls.Add(this.cmdBrowseSourceWIM);
            this.tabPage1.Controls.Add(this.lblEdition);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Install from local source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdPatchOptions
            // 
            this.cmdPatchOptions.Location = new System.Drawing.Point(528, 288);
            this.cmdPatchOptions.Name = "cmdPatchOptions";
            this.cmdPatchOptions.Size = new System.Drawing.Size(75, 23);
            this.cmdPatchOptions.TabIndex = 8;
            this.cmdPatchOptions.Text = "Options";
            this.cmdPatchOptions.UseVisualStyleBackColor = true;
            this.cmdPatchOptions.Click += new System.EventHandler(this.cmdPatchOptions_Click);
            // 
            // chkPrePatch
            // 
            this.chkPrePatch.AutoSize = true;
            this.chkPrePatch.Location = new System.Drawing.Point(81, 292);
            this.chkPrePatch.Name = "chkPrePatch";
            this.chkPrePatch.Size = new System.Drawing.Size(173, 17);
            this.chkPrePatch.TabIndex = 7;
            this.chkPrePatch.Text = "Pre-Patch Windows Installation";
            this.chkPrePatch.UseVisualStyleBackColor = true;
            this.chkPrePatch.CheckedChanged += new System.EventHandler(this.chkPrePatch_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Destination:";
            // 
            // lstDestination
            // 
            this.lstDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDestination.FormattingEnabled = true;
            this.lstDestination.Location = new System.Drawing.Point(81, 68);
            this.lstDestination.Name = "lstDestination";
            this.lstDestination.Size = new System.Drawing.Size(216, 21);
            this.lstDestination.TabIndex = 4;
            this.lstDestination.SelectedIndexChanged += new System.EventHandler(this.lstDestination_SelectedIndexChanged);
            // 
            // grpDestDisk
            // 
            this.grpDestDisk.Controls.Add(this.chkInstallBootLoaderPLAIN);
            this.grpDestDisk.Controls.Add(this.chkInstallBootLoader);
            this.grpDestDisk.Controls.Add(this.label12);
            this.grpDestDisk.Controls.Add(this.label11);
            this.grpDestDisk.Controls.Add(this.lstDiskSchema);
            this.grpDestDisk.Controls.Add(this.lstDisks);
            this.grpDestDisk.Location = new System.Drawing.Point(3, 95);
            this.grpDestDisk.Name = "grpDestDisk";
            this.grpDestDisk.Size = new System.Drawing.Size(609, 98);
            this.grpDestDisk.TabIndex = 5;
            this.grpDestDisk.TabStop = false;
            this.grpDestDisk.Text = "To disk";
            // 
            // chkInstallBootLoader
            // 
            this.chkInstallBootLoader.AutoSize = true;
            this.chkInstallBootLoader.Location = new System.Drawing.Point(78, 73);
            this.chkInstallBootLoader.Name = "chkInstallBootLoader";
            this.chkInstallBootLoader.Size = new System.Drawing.Size(107, 17);
            this.chkInstallBootLoader.TabIndex = 2;
            this.chkInstallBootLoader.Text = "Install Bootloader";
            this.chkInstallBootLoader.UseVisualStyleBackColor = true;
            this.chkInstallBootLoader.CheckedChanged += new System.EventHandler(this.chkInstallBootLoader_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Schema:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Disk:";
            // 
            // lstDiskSchema
            // 
            this.lstDiskSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDiskSchema.FormattingEnabled = true;
            this.lstDiskSchema.Location = new System.Drawing.Point(78, 46);
            this.lstDiskSchema.Name = "lstDiskSchema";
            this.lstDiskSchema.Size = new System.Drawing.Size(216, 21);
            this.lstDiskSchema.TabIndex = 1;
            // 
            // lstDisks
            // 
            this.lstDisks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstDisks.FormattingEnabled = true;
            this.lstDisks.Location = new System.Drawing.Point(78, 19);
            this.lstDisks.Name = "lstDisks";
            this.lstDisks.Size = new System.Drawing.Size(441, 21);
            this.lstDisks.TabIndex = 0;
            // 
            // grpDestFolder
            // 
            this.grpDestFolder.Controls.Add(this.txtTarget);
            this.grpDestFolder.Controls.Add(this.cmdBrowseInstallTempDir);
            this.grpDestFolder.Controls.Add(this.cmdBrowseTarget);
            this.grpDestFolder.Controls.Add(this.label5);
            this.grpDestFolder.Controls.Add(this.label2);
            this.grpDestFolder.Controls.Add(this.txtInstallTempDir);
            this.grpDestFolder.Location = new System.Drawing.Point(3, 199);
            this.grpDestFolder.Name = "grpDestFolder";
            this.grpDestFolder.Size = new System.Drawing.Size(609, 76);
            this.grpDestFolder.TabIndex = 6;
            this.grpDestFolder.TabStop = false;
            this.grpDestFolder.Text = "To folder";
            // 
            // cmdBrowseInstallTempDir
            // 
            this.cmdBrowseInstallTempDir.Location = new System.Drawing.Point(525, 46);
            this.cmdBrowseInstallTempDir.Name = "cmdBrowseInstallTempDir";
            this.cmdBrowseInstallTempDir.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseInstallTempDir.TabIndex = 3;
            this.cmdBrowseInstallTempDir.Text = "Browse";
            this.cmdBrowseInstallTempDir.UseVisualStyleBackColor = true;
            this.cmdBrowseInstallTempDir.Click += new System.EventHandler(this.cmdBrowseTempDir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Temp:";
            // 
            // txtInstallTempDir
            // 
            this.txtInstallTempDir.Location = new System.Drawing.Point(78, 48);
            this.txtInstallTempDir.Name = "txtInstallTempDir";
            this.txtInstallTempDir.Size = new System.Drawing.Size(441, 20);
            this.txtInstallTempDir.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cmdBrowseCaptureTempDir);
            this.tabPage2.Controls.Add(this.txtCaptureTempDir);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lstCompression);
            this.tabPage2.Controls.Add(this.cmdListExcludeFiles);
            this.tabPage2.Controls.Add(this.chkExcludeFiles);
            this.tabPage2.Controls.Add(this.cmdStartCapture);
            this.tabPage2.Controls.Add(this.cmdBrowseSource);
            this.tabPage2.Controls.Add(this.txtSource);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmdBrowseDestWIM);
            this.tabPage2.Controls.Add(this.txtDestWIM);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Capture to local destination";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Temp:";
            // 
            // cmdBrowseCaptureTempDir
            // 
            this.cmdBrowseCaptureTempDir.Location = new System.Drawing.Point(530, 117);
            this.cmdBrowseCaptureTempDir.Name = "cmdBrowseCaptureTempDir";
            this.cmdBrowseCaptureTempDir.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseCaptureTempDir.TabIndex = 8;
            this.cmdBrowseCaptureTempDir.Text = "Browse";
            this.cmdBrowseCaptureTempDir.UseVisualStyleBackColor = true;
            this.cmdBrowseCaptureTempDir.Click += new System.EventHandler(this.cmdBrowseCaptureTempDir_Click);
            // 
            // txtCaptureTempDir
            // 
            this.txtCaptureTempDir.Location = new System.Drawing.Point(83, 119);
            this.txtCaptureTempDir.Name = "txtCaptureTempDir";
            this.txtCaptureTempDir.Size = new System.Drawing.Size(441, 20);
            this.txtCaptureTempDir.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Compression:";
            // 
            // lstCompression
            // 
            this.lstCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstCompression.FormattingEnabled = true;
            this.lstCompression.Location = new System.Drawing.Point(83, 92);
            this.lstCompression.Name = "lstCompression";
            this.lstCompression.Size = new System.Drawing.Size(121, 21);
            this.lstCompression.TabIndex = 6;
            // 
            // cmdListExcludeFiles
            // 
            this.cmdListExcludeFiles.Location = new System.Drawing.Point(530, 65);
            this.cmdListExcludeFiles.Name = "cmdListExcludeFiles";
            this.cmdListExcludeFiles.Size = new System.Drawing.Size(75, 23);
            this.cmdListExcludeFiles.TabIndex = 5;
            this.cmdListExcludeFiles.Text = "List";
            this.cmdListExcludeFiles.UseVisualStyleBackColor = true;
            this.cmdListExcludeFiles.Click += new System.EventHandler(this.cmdListExcludeFiles_Click);
            // 
            // chkExcludeFiles
            // 
            this.chkExcludeFiles.AutoSize = true;
            this.chkExcludeFiles.Location = new System.Drawing.Point(83, 69);
            this.chkExcludeFiles.Name = "chkExcludeFiles";
            this.chkExcludeFiles.Size = new System.Drawing.Size(196, 17);
            this.chkExcludeFiles.TabIndex = 4;
            this.chkExcludeFiles.Text = "Exclude specific directories and files";
            this.chkExcludeFiles.UseVisualStyleBackColor = true;
            this.chkExcludeFiles.CheckedChanged += new System.EventHandler(this.chkExcludeFiles_CheckedChanged);
            // 
            // cmdStartCapture
            // 
            this.cmdStartCapture.Location = new System.Drawing.Point(530, 162);
            this.cmdStartCapture.Name = "cmdStartCapture";
            this.cmdStartCapture.Size = new System.Drawing.Size(75, 23);
            this.cmdStartCapture.TabIndex = 9;
            this.cmdStartCapture.Text = "Start";
            this.cmdStartCapture.UseVisualStyleBackColor = true;
            this.cmdStartCapture.Click += new System.EventHandler(this.cmdStartCapture_Click);
            // 
            // cmdBrowseSource
            // 
            this.cmdBrowseSource.Location = new System.Drawing.Point(530, 10);
            this.cmdBrowseSource.Name = "cmdBrowseSource";
            this.cmdBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseSource.TabIndex = 1;
            this.cmdBrowseSource.Text = "Browse";
            this.cmdBrowseSource.UseVisualStyleBackColor = true;
            this.cmdBrowseSource.Click += new System.EventHandler(this.cmdBrowseSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(83, 13);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(441, 20);
            this.txtSource.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Source:";
            // 
            // cmdBrowseDestWIM
            // 
            this.cmdBrowseDestWIM.Location = new System.Drawing.Point(530, 36);
            this.cmdBrowseDestWIM.Name = "cmdBrowseDestWIM";
            this.cmdBrowseDestWIM.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseDestWIM.TabIndex = 3;
            this.cmdBrowseDestWIM.Text = "Browse";
            this.cmdBrowseDestWIM.UseVisualStyleBackColor = true;
            this.cmdBrowseDestWIM.Click += new System.EventHandler(this.cmdBrowseDestWIM_Click);
            // 
            // txtDestWIM
            // 
            this.txtDestWIM.Location = new System.Drawing.Point(83, 38);
            this.txtDestWIM.Name = "txtDestWIM";
            this.txtDestWIM.Size = new System.Drawing.Size(441, 20);
            this.txtDestWIM.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "WIM File:";
            // 
            // chkInstallBootLoaderPLAIN
            // 
            this.chkInstallBootLoaderPLAIN.AutoSize = true;
            this.chkInstallBootLoaderPLAIN.Location = new System.Drawing.Point(191, 73);
            this.chkInstallBootLoaderPLAIN.Name = "chkInstallBootLoaderPLAIN";
            this.chkInstallBootLoaderPLAIN.Size = new System.Drawing.Size(126, 17);
            this.chkInstallBootLoaderPLAIN.TabIndex = 3;
            this.chkInstallBootLoaderPLAIN.Text = "Plain BCDBOOT only";
            this.chkInstallBootLoaderPLAIN.UseVisualStyleBackColor = true;
            // 
            // chkAutoReboot
            // 
            this.chkAutoReboot.AutoSize = true;
            this.chkAutoReboot.Location = new System.Drawing.Point(81, 315);
            this.chkAutoReboot.Name = "chkAutoReboot";
            this.chkAutoReboot.Size = new System.Drawing.Size(177, 17);
            this.chkAutoReboot.TabIndex = 9;
            this.chkAutoReboot.Text = "Automatically reboot when done";
            this.chkAutoReboot.UseVisualStyleBackColor = true;
            // 
            // MainDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fox - Multi WIM File Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDLG_FormClosing);
            this.Load += new System.EventHandler(this.MainDLG_Load);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpDestDisk.ResumeLayout(false);
            this.grpDestDisk.PerformLayout();
            this.grpDestFolder.ResumeLayout(false);
            this.grpDestFolder.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdBrowseTarget;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowseSourceWIM;
        private System.Windows.Forms.TextBox txtSourceWIMFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelectEdition;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.CheckBox chkNoApplySec;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdBrowseInstallTempDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInstallTempDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lstCompression;
        private System.Windows.Forms.Button cmdListExcludeFiles;
        private System.Windows.Forms.CheckBox chkExcludeFiles;
        private System.Windows.Forms.Button cmdStartCapture;
        private System.Windows.Forms.Button cmdBrowseSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdBrowseDestWIM;
        private System.Windows.Forms.TextBox txtDestWIM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdBrowseCaptureTempDir;
        private System.Windows.Forms.TextBox txtCaptureTempDir;
        private System.Windows.Forms.GroupBox grpDestFolder;
        private System.Windows.Forms.GroupBox grpDestDisk;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lstDestination;
        private System.Windows.Forms.ComboBox lstDisks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox lstDiskSchema;
        private System.Windows.Forms.CheckBox chkInstallBootLoader;
        private System.Windows.Forms.Button cmdPatchOptions;
        private System.Windows.Forms.CheckBox chkPrePatch;
        private System.Windows.Forms.CheckBox chkInstallBootLoaderPLAIN;
        private System.Windows.Forms.CheckBox chkAutoReboot;
    }
}

