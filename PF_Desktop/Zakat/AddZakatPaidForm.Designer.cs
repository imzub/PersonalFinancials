namespace PF_Desktop.Zakat
{
    partial class AddZakatPaidForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.zptb_ZakatPaidId = new System.Windows.Forms.TextBox();
            this.zptb_ZakatPaidAmount = new System.Windows.Forms.TextBox();
            this.zptb_ZakatPaidTo = new System.Windows.Forms.TextBox();
            this.zpdtp_ZakatPaidDate = new System.Windows.Forms.DateTimePicker();
            this.zpcb_IsZakatDueUpdated = new System.Windows.Forms.CheckBox();
            this.zpbtn_SaveZakatPaid = new System.Windows.Forms.Button();
            this.zpcb_AssetId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zakat Paid ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zakat Paid Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Zakat Paid To:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Zakat Paid Date:";
            // 
            // zptb_ZakatPaidId
            // 
            this.zptb_ZakatPaidId.Location = new System.Drawing.Point(185, 25);
            this.zptb_ZakatPaidId.Name = "zptb_ZakatPaidId";
            this.zptb_ZakatPaidId.ReadOnly = true;
            this.zptb_ZakatPaidId.Size = new System.Drawing.Size(213, 26);
            this.zptb_ZakatPaidId.TabIndex = 6;
            // 
            // zptb_ZakatPaidAmount
            // 
            this.zptb_ZakatPaidAmount.Location = new System.Drawing.Point(185, 122);
            this.zptb_ZakatPaidAmount.Name = "zptb_ZakatPaidAmount";
            this.zptb_ZakatPaidAmount.Size = new System.Drawing.Size(213, 26);
            this.zptb_ZakatPaidAmount.TabIndex = 9;
            // 
            // zptb_ZakatPaidTo
            // 
            this.zptb_ZakatPaidTo.Location = new System.Drawing.Point(185, 89);
            this.zptb_ZakatPaidTo.Name = "zptb_ZakatPaidTo";
            this.zptb_ZakatPaidTo.Size = new System.Drawing.Size(213, 26);
            this.zptb_ZakatPaidTo.TabIndex = 8;
            // 
            // zpdtp_ZakatPaidDate
            // 
            this.zpdtp_ZakatPaidDate.Location = new System.Drawing.Point(185, 154);
            this.zpdtp_ZakatPaidDate.Name = "zpdtp_ZakatPaidDate";
            this.zpdtp_ZakatPaidDate.Size = new System.Drawing.Size(213, 26);
            this.zpdtp_ZakatPaidDate.TabIndex = 12;
            // 
            // zpcb_IsZakatDueUpdated
            // 
            this.zpcb_IsZakatDueUpdated.AutoSize = true;
            this.zpcb_IsZakatDueUpdated.Location = new System.Drawing.Point(185, 186);
            this.zpcb_IsZakatDueUpdated.Name = "zpcb_IsZakatDueUpdated";
            this.zpcb_IsZakatDueUpdated.Size = new System.Drawing.Size(181, 24);
            this.zpcb_IsZakatDueUpdated.TabIndex = 13;
            this.zpcb_IsZakatDueUpdated.Text = "IsZakatDueUpdated";
            this.zpcb_IsZakatDueUpdated.UseVisualStyleBackColor = true;
            // 
            // zpbtn_SaveZakatPaid
            // 
            this.zpbtn_SaveZakatPaid.Location = new System.Drawing.Point(297, 216);
            this.zpbtn_SaveZakatPaid.Name = "zpbtn_SaveZakatPaid";
            this.zpbtn_SaveZakatPaid.Size = new System.Drawing.Size(101, 40);
            this.zpbtn_SaveZakatPaid.TabIndex = 14;
            this.zpbtn_SaveZakatPaid.Text = "Save";
            this.zpbtn_SaveZakatPaid.UseVisualStyleBackColor = true;
            this.zpbtn_SaveZakatPaid.Click += new System.EventHandler(this.zpbtn_SaveZakatPaid_Click);
            // 
            // zpcb_AssetId
            // 
            this.zpcb_AssetId.FormattingEnabled = true;
            this.zpcb_AssetId.Location = new System.Drawing.Point(185, 58);
            this.zpcb_AssetId.Name = "zpcb_AssetId";
            this.zpcb_AssetId.Size = new System.Drawing.Size(213, 28);
            this.zpcb_AssetId.TabIndex = 15;
            // 
            // AddZakatPaidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 264);
            this.Controls.Add(this.zpcb_AssetId);
            this.Controls.Add(this.zpbtn_SaveZakatPaid);
            this.Controls.Add(this.zpcb_IsZakatDueUpdated);
            this.Controls.Add(this.zpdtp_ZakatPaidDate);
            this.Controls.Add(this.zptb_ZakatPaidAmount);
            this.Controls.Add(this.zptb_ZakatPaidTo);
            this.Controls.Add(this.zptb_ZakatPaidId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddZakatPaidForm";
            this.Text = "ZakatPaid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox zptb_ZakatPaidId;
        private System.Windows.Forms.TextBox zptb_ZakatPaidAmount;
        private System.Windows.Forms.TextBox zptb_ZakatPaidTo;
        private System.Windows.Forms.DateTimePicker zpdtp_ZakatPaidDate;
        private System.Windows.Forms.CheckBox zpcb_IsZakatDueUpdated;
        private System.Windows.Forms.Button zpbtn_SaveZakatPaid;
        private System.Windows.Forms.ComboBox zpcb_AssetId;
    }
}