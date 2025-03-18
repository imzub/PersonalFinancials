namespace PF_Desktop.Zakat
{
    partial class ViewZakatPaidForm
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
            this.vzpfdgv_ViewZakatPaid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vzpfdgv_ViewZakatPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // vzpfdgv_ViewZakatPaid
            // 
            this.vzpfdgv_ViewZakatPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vzpfdgv_ViewZakatPaid.Location = new System.Drawing.Point(12, 48);
            this.vzpfdgv_ViewZakatPaid.Name = "vzpfdgv_ViewZakatPaid";
            this.vzpfdgv_ViewZakatPaid.RowHeadersWidth = 62;
            this.vzpfdgv_ViewZakatPaid.RowTemplate.Height = 28;
            this.vzpfdgv_ViewZakatPaid.Size = new System.Drawing.Size(1042, 609);
            this.vzpfdgv_ViewZakatPaid.TabIndex = 0;
            this.vzpfdgv_ViewZakatPaid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vzpfdgv_ViewZakatPaid_CellContentDoubleClick);
            // 
            // ViewZakatPaidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 668);
            this.Controls.Add(this.vzpfdgv_ViewZakatPaid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewZakatPaidForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewZakatPaidForm";
            ((System.ComponentModel.ISupportInitialize)(this.vzpfdgv_ViewZakatPaid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vzpfdgv_ViewZakatPaid;
    }
}