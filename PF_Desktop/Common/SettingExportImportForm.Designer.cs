namespace PF_Desktop.Common
{
    partial class SettingExportImportForm
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
            this.FBD_ImportFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.FBD_ExportFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.txtExportLocation = new System.Windows.Forms.TextBox();
            this.txtImportLocation = new System.Windows.Forms.TextBox();
            this.btnBrowseImport = new System.Windows.Forms.Button();
            this.btnBrowseExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seifcb_ImportFileFormat = new System.Windows.Forms.ComboBox();
            this.seif_ImportAllData = new System.Windows.Forms.Button();
            this.seifcb_ExportFileFormat = new System.Windows.Forms.ComboBox();
            this.seifbtn_SaveLocation = new System.Windows.Forms.Button();
            this.seif_ExportAllData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExportLocation
            // 
            this.txtExportLocation.Location = new System.Drawing.Point(6, 71);
            this.txtExportLocation.Name = "txtExportLocation";
            this.txtExportLocation.Size = new System.Drawing.Size(850, 26);
            this.txtExportLocation.TabIndex = 0;
            // 
            // txtImportLocation
            // 
            this.txtImportLocation.Location = new System.Drawing.Point(6, 25);
            this.txtImportLocation.Name = "txtImportLocation";
            this.txtImportLocation.Size = new System.Drawing.Size(850, 26);
            this.txtImportLocation.TabIndex = 1;
            // 
            // btnBrowseImport
            // 
            this.btnBrowseImport.Location = new System.Drawing.Point(862, 24);
            this.btnBrowseImport.Name = "btnBrowseImport";
            this.btnBrowseImport.Size = new System.Drawing.Size(193, 32);
            this.btnBrowseImport.TabIndex = 2;
            this.btnBrowseImport.Text = "Select Import Location";
            this.btnBrowseImport.UseVisualStyleBackColor = true;
            this.btnBrowseImport.Click += new System.EventHandler(this.btnBrowseImport_Click);
            // 
            // btnBrowseExport
            // 
            this.btnBrowseExport.Location = new System.Drawing.Point(862, 68);
            this.btnBrowseExport.Name = "btnBrowseExport";
            this.btnBrowseExport.Size = new System.Drawing.Size(193, 32);
            this.btnBrowseExport.TabIndex = 3;
            this.btnBrowseExport.Text = "Select Export Location";
            this.btnBrowseExport.UseVisualStyleBackColor = true;
            this.btnBrowseExport.Click += new System.EventHandler(this.btnBrowseExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seifcb_ImportFileFormat);
            this.groupBox1.Controls.Add(this.seif_ImportAllData);
            this.groupBox1.Controls.Add(this.seifcb_ExportFileFormat);
            this.groupBox1.Controls.Add(this.seifbtn_SaveLocation);
            this.groupBox1.Controls.Add(this.seif_ExportAllData);
            this.groupBox1.Controls.Add(this.txtImportLocation);
            this.groupBox1.Controls.Add(this.btnBrowseExport);
            this.groupBox1.Controls.Add(this.txtExportLocation);
            this.groupBox1.Controls.Add(this.btnBrowseImport);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 206);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import And Export";
            // 
            // seifcb_ImportFileFormat
            // 
            this.seifcb_ImportFileFormat.FormattingEnabled = true;
            this.seifcb_ImportFileFormat.Location = new System.Drawing.Point(273, 167);
            this.seifcb_ImportFileFormat.Name = "seifcb_ImportFileFormat";
            this.seifcb_ImportFileFormat.Size = new System.Drawing.Size(100, 28);
            this.seifcb_ImportFileFormat.TabIndex = 8;
            // 
            // seif_ImportAllData
            // 
            this.seif_ImportAllData.Location = new System.Drawing.Point(6, 164);
            this.seif_ImportAllData.Name = "seif_ImportAllData";
            this.seif_ImportAllData.Size = new System.Drawing.Size(261, 32);
            this.seif_ImportAllData.TabIndex = 7;
            this.seif_ImportAllData.Text = "Import Data";
            this.seif_ImportAllData.UseVisualStyleBackColor = true;
            this.seif_ImportAllData.Click += new System.EventHandler(this.seif_ImportAllData_Click);
            // 
            // seifcb_ExportFileFormat
            // 
            this.seifcb_ExportFileFormat.FormattingEnabled = true;
            this.seifcb_ExportFileFormat.Location = new System.Drawing.Point(273, 129);
            this.seifcb_ExportFileFormat.Name = "seifcb_ExportFileFormat";
            this.seifcb_ExportFileFormat.Size = new System.Drawing.Size(100, 28);
            this.seifcb_ExportFileFormat.TabIndex = 6;
            // 
            // seifbtn_SaveLocation
            // 
            this.seifbtn_SaveLocation.Location = new System.Drawing.Point(862, 106);
            this.seifbtn_SaveLocation.Name = "seifbtn_SaveLocation";
            this.seifbtn_SaveLocation.Size = new System.Drawing.Size(193, 32);
            this.seifbtn_SaveLocation.TabIndex = 4;
            this.seifbtn_SaveLocation.Text = "Save Locations";
            this.seifbtn_SaveLocation.UseVisualStyleBackColor = true;
            this.seifbtn_SaveLocation.Click += new System.EventHandler(this.seifbtn_SaveLocation_Click);
            // 
            // seif_ExportAllData
            // 
            this.seif_ExportAllData.Location = new System.Drawing.Point(6, 126);
            this.seif_ExportAllData.Name = "seif_ExportAllData";
            this.seif_ExportAllData.Size = new System.Drawing.Size(261, 32);
            this.seif_ExportAllData.TabIndex = 5;
            this.seif_ExportAllData.Text = "Export All Data";
            this.seif_ExportAllData.UseVisualStyleBackColor = true;
            this.seif_ExportAllData.Click += new System.EventHandler(this.seif_ExportAllData_Click);
            // 
            // SettingExportImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1090, 226);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingExportImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingExportImportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FBD_ImportFolder;
        private System.Windows.Forms.FolderBrowserDialog FBD_ExportFolder;
        private System.Windows.Forms.TextBox txtExportLocation;
        private System.Windows.Forms.TextBox txtImportLocation;
        private System.Windows.Forms.Button btnBrowseImport;
        private System.Windows.Forms.Button btnBrowseExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button seifbtn_SaveLocation;
        private System.Windows.Forms.Button seif_ExportAllData;
        private System.Windows.Forms.ComboBox seifcb_ExportFileFormat;
        private System.Windows.Forms.ComboBox seifcb_ImportFileFormat;
        private System.Windows.Forms.Button seif_ImportAllData;
    }
}