namespace PF_Desktop.Zakat
{
    partial class ViewZakatDueForm
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
            this.zddgv_ZakatDue = new System.Windows.Forms.DataGridView();
            this.zdbtn_Search = new System.Windows.Forms.Button();
            this.zdcb_Username = new System.Windows.Forms.TextBox();
            this.zdcb_Assetname = new System.Windows.Forms.TextBox();
            this.zdcb_IsZakatDueActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.zddgv_ZakatDue)).BeginInit();
            this.SuspendLayout();
            // 
            // zddgv_ZakatDue
            // 
            this.zddgv_ZakatDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zddgv_ZakatDue.Location = new System.Drawing.Point(12, 43);
            this.zddgv_ZakatDue.Name = "zddgv_ZakatDue";
            this.zddgv_ZakatDue.RowHeadersWidth = 62;
            this.zddgv_ZakatDue.RowTemplate.Height = 28;
            this.zddgv_ZakatDue.Size = new System.Drawing.Size(1059, 556);
            this.zddgv_ZakatDue.TabIndex = 0;
            // 
            // zdbtn_Search
            // 
            this.zdbtn_Search.Location = new System.Drawing.Point(968, 5);
            this.zdbtn_Search.Name = "zdbtn_Search";
            this.zdbtn_Search.Size = new System.Drawing.Size(103, 32);
            this.zdbtn_Search.TabIndex = 1;
            this.zdbtn_Search.Text = "Search";
            this.zdbtn_Search.UseVisualStyleBackColor = true;
            this.zdbtn_Search.Click += new System.EventHandler(this.zdbtn_Search_Click);
            // 
            // zdcb_Username
            // 
            this.zdcb_Username.Location = new System.Drawing.Point(377, 8);
            this.zdcb_Username.Name = "zdcb_Username";
            this.zdcb_Username.Size = new System.Drawing.Size(171, 26);
            this.zdcb_Username.TabIndex = 2;
            // 
            // zdcb_Assetname
            // 
            this.zdcb_Assetname.Location = new System.Drawing.Point(114, 8);
            this.zdcb_Assetname.Name = "zdcb_Assetname";
            this.zdcb_Assetname.Size = new System.Drawing.Size(162, 26);
            this.zdcb_Assetname.TabIndex = 3;
            // 
            // zdcb_IsZakatDueActive
            // 
            this.zdcb_IsZakatDueActive.AutoSize = true;
            this.zdcb_IsZakatDueActive.Location = new System.Drawing.Point(554, 8);
            this.zdcb_IsZakatDueActive.Name = "zdcb_IsZakatDueActive";
            this.zdcb_IsZakatDueActive.Size = new System.Drawing.Size(178, 24);
            this.zdcb_IsZakatDueActive.TabIndex = 4;
            this.zdcb_IsZakatDueActive.Text = "Is Zakat Due Active ";
            this.zdcb_IsZakatDueActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Asset Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // ViewZakatDueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1083, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zdcb_IsZakatDueActive);
            this.Controls.Add(this.zdcb_Assetname);
            this.Controls.Add(this.zdcb_Username);
            this.Controls.Add(this.zdbtn_Search);
            this.Controls.Add(this.zddgv_ZakatDue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewZakatDueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zakat Due";
            ((System.ComponentModel.ISupportInitialize)(this.zddgv_ZakatDue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView zddgv_ZakatDue;
        private System.Windows.Forms.Button zdbtn_Search;
        private System.Windows.Forms.TextBox zdcb_Username;
        private System.Windows.Forms.TextBox zdcb_Assetname;
        private System.Windows.Forms.CheckBox zdcb_IsZakatDueActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}