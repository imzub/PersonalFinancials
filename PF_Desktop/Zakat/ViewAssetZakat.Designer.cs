namespace PF_Desktop.Zakat
{
    partial class ViewAssetZakat
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
            this.vazdgv_ViewAssetZakat = new System.Windows.Forms.DataGridView();
            this.azbtn_Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vazdgv_ViewAssetZakat)).BeginInit();
            this.SuspendLayout();
            // 
            // vazdgv_ViewAssetZakat
            // 
            this.vazdgv_ViewAssetZakat.AllowUserToAddRows = false;
            this.vazdgv_ViewAssetZakat.AllowUserToDeleteRows = false;
            this.vazdgv_ViewAssetZakat.AllowUserToResizeColumns = false;
            this.vazdgv_ViewAssetZakat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vazdgv_ViewAssetZakat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vazdgv_ViewAssetZakat.Location = new System.Drawing.Point(15, 69);
            this.vazdgv_ViewAssetZakat.MultiSelect = false;
            this.vazdgv_ViewAssetZakat.Name = "vazdgv_ViewAssetZakat";
            this.vazdgv_ViewAssetZakat.RowHeadersVisible = false;
            this.vazdgv_ViewAssetZakat.RowHeadersWidth = 62;
            this.vazdgv_ViewAssetZakat.RowTemplate.Height = 28;
            this.vazdgv_ViewAssetZakat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vazdgv_ViewAssetZakat.Size = new System.Drawing.Size(1300, 560);
            this.vazdgv_ViewAssetZakat.TabIndex = 0;
            this.vazdgv_ViewAssetZakat.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vazdgv_ViewAssetZakat_CellDoubleClick);
            // 
            // azbtn_Print
            // 
            this.azbtn_Print.Location = new System.Drawing.Point(998, 12);
            this.azbtn_Print.Name = "azbtn_Print";
            this.azbtn_Print.Size = new System.Drawing.Size(114, 41);
            this.azbtn_Print.TabIndex = 1;
            this.azbtn_Print.Text = "Print";
            this.azbtn_Print.UseVisualStyleBackColor = true;
            this.azbtn_Print.Click += new System.EventHandler(this.azbtn_Print_Click);
            // 
            // ViewAssetZakat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1327, 653);
            this.Controls.Add(this.azbtn_Print);
            this.Controls.Add(this.vazdgv_ViewAssetZakat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAssetZakat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Zakat";
            ((System.ComponentModel.ISupportInitialize)(this.vazdgv_ViewAssetZakat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vazdgv_ViewAssetZakat;
        private System.Windows.Forms.Button azbtn_Print;
    }
}