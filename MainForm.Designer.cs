namespace acTelerikStylesRenaming
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBrowseOutputDirectory = new System.Windows.Forms.Button();
            this.txtBrowseOutputDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewSkinName = new System.Windows.Forms.TextBox();
            this.btnGenerateNewSkin = new System.Windows.Forms.Button();
            this.fbdOutputDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.errGenerateAssembly = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.ofdSettings = new System.Windows.Forms.OpenFileDialog();
            this.sfdSettings = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseTelerikSkinDirectory = new System.Windows.Forms.Button();
            this.txtBrowseTelerikSkinDirectory = new System.Windows.Forms.TextBox();
            this.fbdTelerikSkinDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearLogging = new System.Windows.Forms.Button();
            this.chkGenerateZipSkin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errGenerateAssembly)).BeginInit();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseOutputDirectory
            // 
            this.btnBrowseOutputDirectory.CausesValidation = false;
            this.btnBrowseOutputDirectory.Location = new System.Drawing.Point(798, 73);
            this.btnBrowseOutputDirectory.Name = "btnBrowseOutputDirectory";
            this.btnBrowseOutputDirectory.Size = new System.Drawing.Size(29, 23);
            this.btnBrowseOutputDirectory.TabIndex = 7;
            this.btnBrowseOutputDirectory.Text = "...";
            this.btnBrowseOutputDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseOutputDirectory.Click += new System.EventHandler(this.btnBrowseOutputDirectory_Click);
            // 
            // txtBrowseOutputDirectory
            // 
            this.txtBrowseOutputDirectory.Location = new System.Drawing.Point(116, 74);
            this.txtBrowseOutputDirectory.Name = "txtBrowseOutputDirectory";
            this.txtBrowseOutputDirectory.Size = new System.Drawing.Size(686, 20);
            this.txtBrowseOutputDirectory.TabIndex = 6;
            this.txtBrowseOutputDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrowseOutputDirectory_Validating);
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(15, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Output Directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Skin &Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewSkinName
            // 
            this.txtNewSkinName.Location = new System.Drawing.Point(116, 48);
            this.txtNewSkinName.Name = "txtNewSkinName";
            this.txtNewSkinName.Size = new System.Drawing.Size(294, 20);
            this.txtNewSkinName.TabIndex = 4;
            this.txtNewSkinName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewSkinName_Validating);
            // 
            // btnGenerateNewSkin
            // 
            this.btnGenerateNewSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateNewSkin.Location = new System.Drawing.Point(116, 133);
            this.btnGenerateNewSkin.Name = "btnGenerateNewSkin";
            this.btnGenerateNewSkin.Size = new System.Drawing.Size(138, 23);
            this.btnGenerateNewSkin.TabIndex = 8;
            this.btnGenerateNewSkin.Text = "&Generate New Skin";
            this.btnGenerateNewSkin.UseVisualStyleBackColor = true;
            this.btnGenerateNewSkin.Click += new System.EventHandler(this.btnGenerateNewSkin_Click);
            // 
            // errGenerateAssembly
            // 
            this.errGenerateAssembly.ContainerControl = this;
            // 
            // txtLogger
            // 
            this.txtLogger.CausesValidation = false;
            this.txtLogger.Location = new System.Drawing.Point(116, 162);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ReadOnly = true;
            this.txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogger.Size = new System.Drawing.Size(711, 127);
            this.txtLogger.TabIndex = 14;
            this.txtLogger.TabStop = false;
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 301);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(839, 22);
            this.stsMain.SizingGrip = false;
            this.stsMain.TabIndex = 15;
            // 
            // tslStatus
            // 
            this.tslStatus.AutoSize = false;
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(600, 17);
            this.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(13, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Logging:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(762, 133);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(65, 23);
            this.btnAbout.TabIndex = 12;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(549, 133);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSaveSettings.TabIndex = 10;
            this.btnSaveSettings.Text = "&Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadSettings.Location = new System.Drawing.Point(655, 133);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(101, 23);
            this.btnLoadSettings.TabIndex = 11;
            this.btnLoadSettings.Text = "&Load Settings";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // ofdSettings
            // 
            this.ofdSettings.FileName = "ApplicationSettings.xml";
            this.ofdSettings.Filter = "Settings Files|*.xml";
            // 
            // sfdSettings
            // 
            this.sfdSettings.Filter = "Settings Files|*.xml";
            // 
            // label6
            // 
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(15, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "&Skin Directory:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseTelerikSkinDirectory
            // 
            this.btnBrowseTelerikSkinDirectory.CausesValidation = false;
            this.btnBrowseTelerikSkinDirectory.Location = new System.Drawing.Point(798, 21);
            this.btnBrowseTelerikSkinDirectory.Name = "btnBrowseTelerikSkinDirectory";
            this.btnBrowseTelerikSkinDirectory.Size = new System.Drawing.Size(29, 23);
            this.btnBrowseTelerikSkinDirectory.TabIndex = 2;
            this.btnBrowseTelerikSkinDirectory.Text = "...";
            this.btnBrowseTelerikSkinDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseTelerikSkinDirectory.Click += new System.EventHandler(this.btnBrowseTelerikSkinDirectory_Click);
            // 
            // txtBrowseTelerikSkinDirectory
            // 
            this.txtBrowseTelerikSkinDirectory.Location = new System.Drawing.Point(116, 22);
            this.txtBrowseTelerikSkinDirectory.Name = "txtBrowseTelerikSkinDirectory";
            this.txtBrowseTelerikSkinDirectory.Size = new System.Drawing.Size(686, 20);
            this.txtBrowseTelerikSkinDirectory.TabIndex = 1;
            this.txtBrowseTelerikSkinDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrowseTelerikSkinDirectory_Validating);
            // 
            // btnClearLogging
            // 
            this.btnClearLogging.Location = new System.Drawing.Point(261, 133);
            this.btnClearLogging.Name = "btnClearLogging";
            this.btnClearLogging.Size = new System.Drawing.Size(91, 23);
            this.btnClearLogging.TabIndex = 9;
            this.btnClearLogging.Text = "Clear Logging";
            this.btnClearLogging.UseVisualStyleBackColor = true;
            this.btnClearLogging.Click += new System.EventHandler(this.btnClearLogging_Click);
            // 
            // chkGenerateZipSkin
            // 
            this.chkGenerateZipSkin.AutoSize = true;
            this.chkGenerateZipSkin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGenerateZipSkin.Location = new System.Drawing.Point(21, 100);
            this.chkGenerateZipSkin.Name = "chkGenerateZipSkin";
            this.chkGenerateZipSkin.Size = new System.Drawing.Size(109, 17);
            this.chkGenerateZipSkin.TabIndex = 16;
            this.chkGenerateZipSkin.Text = "New Skin &zipped:";
            this.chkGenerateZipSkin.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(839, 323);
            this.Controls.Add(this.chkGenerateZipSkin);
            this.Controls.Add(this.btnClearLogging);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBrowseTelerikSkinDirectory);
            this.Controls.Add(this.txtBrowseTelerikSkinDirectory);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.txtLogger);
            this.Controls.Add(this.btnGenerateNewSkin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewSkinName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowseOutputDirectory);
            this.Controls.Add(this.txtBrowseOutputDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.errGenerateAssembly)).EndInit();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseOutputDirectory;
        private System.Windows.Forms.TextBox txtBrowseOutputDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewSkinName;
        private System.Windows.Forms.Button btnGenerateNewSkin;
        private System.Windows.Forms.FolderBrowserDialog fbdOutputDirectory;
        private System.Windows.Forms.ErrorProvider errGenerateAssembly;
        private System.Windows.Forms.TextBox txtLogger;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.OpenFileDialog ofdSettings;
        private System.Windows.Forms.SaveFileDialog sfdSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowseTelerikSkinDirectory;
        private System.Windows.Forms.TextBox txtBrowseTelerikSkinDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdTelerikSkinDirectory;
        private System.Windows.Forms.Button btnClearLogging;
        private System.Windows.Forms.CheckBox chkGenerateZipSkin;

    }
}

