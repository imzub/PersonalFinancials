namespace PF_Desktop.Assets
{
    partial class ViewAssets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAssets = new System.Windows.Forms.DataGridView();
            this.assetsbtn_Search = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssets
            // 
            this.dataGridViewAssets.AllowUserToAddRows = false;
            this.dataGridViewAssets.AllowUserToDeleteRows = false;
            this.dataGridViewAssets.AllowUserToResizeColumns = false;
            this.dataGridViewAssets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssets.Location = new System.Drawing.Point(12, 43);
            this.dataGridViewAssets.MultiSelect = false;
            this.dataGridViewAssets.Name = "dataGridViewAssets";
            this.dataGridViewAssets.RowHeadersVisible = false;
            this.dataGridViewAssets.RowHeadersWidth = 62;
            this.dataGridViewAssets.RowTemplate.Height = 28;
            this.dataGridViewAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAssets.Size = new System.Drawing.Size(912, 578);
            this.dataGridViewAssets.TabIndex = 0;
            this.dataGridViewAssets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAssets_CellDoubleClick_1);
            // 
            // assetsbtn_Search
            // 
            this.assetsbtn_Search.Location = new System.Drawing.Point(783, 7);
            this.assetsbtn_Search.Name = "assetsbtn_Search";
            this.assetsbtn_Search.Size = new System.Drawing.Size(141, 30);
            this.assetsbtn_Search.TabIndex = 1;
            this.assetsbtn_Search.Text = "Search";
            this.assetsbtn_Search.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(626, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(469, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 28);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(312, 7);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(151, 28);
            this.comboBox3.TabIndex = 4;
            // 
            // ViewAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(936, 633);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.assetsbtn_Search);
            this.Controls.Add(this.dataGridViewAssets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAssets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assets";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssets;
        private System.Windows.Forms.Button assetsbtn_Search;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}