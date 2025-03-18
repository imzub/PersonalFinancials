namespace PF_Desktop.Assets
{
    partial class ViewAssetTypeForm
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
            this.vatfdgv_ViewAssetType = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vatfdgv_ViewAssetType)).BeginInit();
            this.SuspendLayout();
            // 
            // vatfdgv_ViewAssetType
            // 
            this.vatfdgv_ViewAssetType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vatfdgv_ViewAssetType.Location = new System.Drawing.Point(12, 52);
            this.vatfdgv_ViewAssetType.Name = "vatfdgv_ViewAssetType";
            this.vatfdgv_ViewAssetType.RowHeadersWidth = 62;
            this.vatfdgv_ViewAssetType.RowTemplate.Height = 28;
            this.vatfdgv_ViewAssetType.Size = new System.Drawing.Size(733, 567);
            this.vatfdgv_ViewAssetType.TabIndex = 0;
            this.vatfdgv_ViewAssetType.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vatfdgv_ViewAssetType_CellContentDoubleClick);
            // 
            // ViewAssetTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(756, 623);
            this.Controls.Add(this.vatfdgv_ViewAssetType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAssetTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewAssetTypeForm";
            ((System.ComponentModel.ISupportInitialize)(this.vatfdgv_ViewAssetType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vatfdgv_ViewAssetType;
    }
}