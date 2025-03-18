namespace PF_Desktop.Zakat
{
    partial class AssetZakat
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.azbtn_SaveUpdateAssetZakat = new System.Windows.Forms.Button();
            this.lbl_AssetZakatFinYearId = new System.Windows.Forms.Label();
            this.azdtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.azdtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.azcb_IsActive = new System.Windows.Forms.CheckBox();
            this.azcb_AssetId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Zakat Fin Year ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(275, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Zakat Fin Year Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Asset Zakat Fin Year End Date:";
            // 
            // azbtn_SaveUpdateAssetZakat
            // 
            this.azbtn_SaveUpdateAssetZakat.Location = new System.Drawing.Point(442, 132);
            this.azbtn_SaveUpdateAssetZakat.Name = "azbtn_SaveUpdateAssetZakat";
            this.azbtn_SaveUpdateAssetZakat.Size = new System.Drawing.Size(78, 34);
            this.azbtn_SaveUpdateAssetZakat.TabIndex = 5;
            this.azbtn_SaveUpdateAssetZakat.Text = "Save";
            this.azbtn_SaveUpdateAssetZakat.UseVisualStyleBackColor = true;
            this.azbtn_SaveUpdateAssetZakat.Click += new System.EventHandler(this.azbtn_SaveUpdateAssetZakat_Click);
            // 
            // lbl_AssetZakatFinYearId
            // 
            this.lbl_AssetZakatFinYearId.AutoSize = true;
            this.lbl_AssetZakatFinYearId.Location = new System.Drawing.Point(196, 9);
            this.lbl_AssetZakatFinYearId.Name = "lbl_AssetZakatFinYearId";
            this.lbl_AssetZakatFinYearId.Size = new System.Drawing.Size(18, 20);
            this.lbl_AssetZakatFinYearId.TabIndex = 6;
            this.lbl_AssetZakatFinYearId.Text = "0";
            // 
            // azdtp_StartDate
            // 
            this.azdtp_StartDate.Location = new System.Drawing.Point(279, 39);
            this.azdtp_StartDate.Name = "azdtp_StartDate";
            this.azdtp_StartDate.Size = new System.Drawing.Size(241, 26);
            this.azdtp_StartDate.TabIndex = 8;
            // 
            // azdtp_EndDate
            // 
            this.azdtp_EndDate.Location = new System.Drawing.Point(279, 70);
            this.azdtp_EndDate.Name = "azdtp_EndDate";
            this.azdtp_EndDate.Size = new System.Drawing.Size(241, 26);
            this.azdtp_EndDate.TabIndex = 9;
            // 
            // azcb_IsActive
            // 
            this.azcb_IsActive.AutoSize = true;
            this.azcb_IsActive.Location = new System.Drawing.Point(279, 102);
            this.azcb_IsActive.Name = "azcb_IsActive";
            this.azcb_IsActive.Size = new System.Drawing.Size(249, 24);
            this.azcb_IsActive.TabIndex = 10;
            this.azcb_IsActive.Text = "Is Asset Zakat Fin Year Active";
            this.azcb_IsActive.UseVisualStyleBackColor = true;
            this.azcb_IsActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // azcb_AssetId
            // 
            this.azcb_AssetId.FormattingEnabled = true;
            this.azcb_AssetId.Location = new System.Drawing.Point(335, 5);
            this.azcb_AssetId.Name = "azcb_AssetId";
            this.azcb_AssetId.Size = new System.Drawing.Size(183, 28);
            this.azcb_AssetId.TabIndex = 11;
            // 
            // AssetZakat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(532, 169);
            this.Controls.Add(this.azcb_AssetId);
            this.Controls.Add(this.azcb_IsActive);
            this.Controls.Add(this.azdtp_EndDate);
            this.Controls.Add(this.azdtp_StartDate);
            this.Controls.Add(this.lbl_AssetZakatFinYearId);
            this.Controls.Add(this.azbtn_SaveUpdateAssetZakat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetZakat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssetZakat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button azbtn_SaveUpdateAssetZakat;
        private System.Windows.Forms.Label lbl_AssetZakatFinYearId;
        private System.Windows.Forms.DateTimePicker azdtp_StartDate;
        private System.Windows.Forms.DateTimePicker azdtp_EndDate;
        private System.Windows.Forms.CheckBox azcb_IsActive;
        private System.Windows.Forms.ComboBox azcb_AssetId;
    }
}