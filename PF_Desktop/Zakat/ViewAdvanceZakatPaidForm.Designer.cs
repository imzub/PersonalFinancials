namespace PF_Desktop.Zakat
{
    partial class ViewAdvanceZakatPaidForm
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
            this.vazpf_dgvAdvZakatPaid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vazpf_dgvAdvZakatPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // vazpf_dgvAdvZakatPaid
            // 
            this.vazpf_dgvAdvZakatPaid.AllowUserToResizeColumns = false;
            this.vazpf_dgvAdvZakatPaid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.vazpf_dgvAdvZakatPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vazpf_dgvAdvZakatPaid.Location = new System.Drawing.Point(0, 0);
            this.vazpf_dgvAdvZakatPaid.Name = "vazpf_dgvAdvZakatPaid";
            this.vazpf_dgvAdvZakatPaid.RowHeadersWidth = 62;
            this.vazpf_dgvAdvZakatPaid.RowTemplate.Height = 28;
            this.vazpf_dgvAdvZakatPaid.Size = new System.Drawing.Size(1375, 669);
            this.vazpf_dgvAdvZakatPaid.TabIndex = 0;
            this.vazpf_dgvAdvZakatPaid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vazpf_dgvAdvZakatPaid_CellContentDoubleClick);
            // 
            // ViewAdvanceZakatPaidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1375, 669);
            this.Controls.Add(this.vazpf_dgvAdvZakatPaid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAdvanceZakatPaidForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Advance Zakat (IN/OUT)";
            ((System.ComponentModel.ISupportInitialize)(this.vazpf_dgvAdvZakatPaid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vazpf_dgvAdvZakatPaid;
    }
}