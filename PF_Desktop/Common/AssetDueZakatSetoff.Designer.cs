namespace PF_Desktop.Common
{
    partial class AssetDueZakatSetoff
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
            this.adzs_CurrentAdvZakatBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.adzs_Asset = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adzs_AssetDueAmount = new System.Windows.Forms.Label();
            this.adzs_btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adzs_CurrentAdvZakatBalance
            // 
            this.adzs_CurrentAdvZakatBalance.AutoSize = true;
            this.adzs_CurrentAdvZakatBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adzs_CurrentAdvZakatBalance.ForeColor = System.Drawing.Color.IndianRed;
            this.adzs_CurrentAdvZakatBalance.Location = new System.Drawing.Point(92, 29);
            this.adzs_CurrentAdvZakatBalance.Name = "adzs_CurrentAdvZakatBalance";
            this.adzs_CurrentAdvZakatBalance.Size = new System.Drawing.Size(71, 20);
            this.adzs_CurrentAdvZakatBalance.TabIndex = 40;
            this.adzs_CurrentAdvZakatBalance.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Current Advance Zakat Balance";
            // 
            // adzs_Asset
            // 
            this.adzs_Asset.FormattingEnabled = true;
            this.adzs_Asset.Location = new System.Drawing.Point(63, 72);
            this.adzs_Asset.Name = "adzs_Asset";
            this.adzs_Asset.Size = new System.Drawing.Size(184, 28);
            this.adzs_Asset.TabIndex = 42;
            this.adzs_Asset.SelectedIndexChanged += new System.EventHandler(this.adzs_Asset_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Asset:";
            // 
            // adzs_AssetDueAmount
            // 
            this.adzs_AssetDueAmount.AutoSize = true;
            this.adzs_AssetDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adzs_AssetDueAmount.ForeColor = System.Drawing.Color.IndianRed;
            this.adzs_AssetDueAmount.Location = new System.Drawing.Point(92, 119);
            this.adzs_AssetDueAmount.Name = "adzs_AssetDueAmount";
            this.adzs_AssetDueAmount.Size = new System.Drawing.Size(109, 20);
            this.adzs_AssetDueAmount.TabIndex = 43;
            this.adzs_AssetDueAmount.Text = "Due Amount";
            this.adzs_AssetDueAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // adzs_btnSave
            // 
            this.adzs_btnSave.Location = new System.Drawing.Point(96, 154);
            this.adzs_btnSave.Name = "adzs_btnSave";
            this.adzs_btnSave.Size = new System.Drawing.Size(72, 35);
            this.adzs_btnSave.TabIndex = 44;
            this.adzs_btnSave.Text = "Setoff";
            this.adzs_btnSave.UseVisualStyleBackColor = true;
            this.adzs_btnSave.Click += new System.EventHandler(this.adzs_btnSave_Click);
            // 
            // AssetDueZakatSetoff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(280, 201);
            this.Controls.Add(this.adzs_btnSave);
            this.Controls.Add(this.adzs_AssetDueAmount);
            this.Controls.Add(this.adzs_Asset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.adzs_CurrentAdvZakatBalance);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetDueZakatSetoff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssetDueZakatSetoff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label adzs_CurrentAdvZakatBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox adzs_Asset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label adzs_AssetDueAmount;
        private System.Windows.Forms.Button adzs_btnSave;
    }
}