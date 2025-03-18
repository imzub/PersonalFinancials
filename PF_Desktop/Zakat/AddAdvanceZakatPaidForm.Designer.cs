namespace PF_Desktop.Zakat
{
    partial class AddAdvanceZakatPaidForm
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
            this.adzpf_btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.adzpf_AdvZakatId = new System.Windows.Forms.TextBox();
            this.adzpf_AdvZakatIn = new System.Windows.Forms.TextBox();
            this.adzpf_AdvZakatOut = new System.Windows.Forms.TextBox();
            this.adzpf_IsActive = new System.Windows.Forms.CheckBox();
            this.adzpf_IsAdvZakatPaid = new System.Windows.Forms.CheckBox();
            this.adzpf_AdvZakatPaidDate = new System.Windows.Forms.DateTimePicker();
            this.adzpf_AdvZakatBalance = new System.Windows.Forms.TextBox();
            this.adzpf_AdvZakatPaidTo = new System.Windows.Forms.TextBox();
            this.adzpf_AdvZakatComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.adzpf_Asset = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // adzpf_btnSave
            // 
            this.adzpf_btnSave.Location = new System.Drawing.Point(289, 314);
            this.adzpf_btnSave.Name = "adzpf_btnSave";
            this.adzpf_btnSave.Size = new System.Drawing.Size(115, 36);
            this.adzpf_btnSave.TabIndex = 0;
            this.adzpf_btnSave.Text = "Save";
            this.adzpf_btnSave.UseVisualStyleBackColor = true;
            this.adzpf_btnSave.Click += new System.EventHandler(this.adzpf_btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adv Zakat ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adv Zakat In:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Adv Zakat Out:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Adv Zakat Balance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Adv Zakat Paid To:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Asset:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Adv Zakat Date:";
            // 
            // adzpf_AdvZakatId
            // 
            this.adzpf_AdvZakatId.Enabled = false;
            this.adzpf_AdvZakatId.Location = new System.Drawing.Point(160, 6);
            this.adzpf_AdvZakatId.Name = "adzpf_AdvZakatId";
            this.adzpf_AdvZakatId.ReadOnly = true;
            this.adzpf_AdvZakatId.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatId.TabIndex = 8;
            // 
            // adzpf_AdvZakatIn
            // 
            this.adzpf_AdvZakatIn.Enabled = false;
            this.adzpf_AdvZakatIn.Location = new System.Drawing.Point(160, 38);
            this.adzpf_AdvZakatIn.Name = "adzpf_AdvZakatIn";
            this.adzpf_AdvZakatIn.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatIn.TabIndex = 9;
            // 
            // adzpf_AdvZakatOut
            // 
            this.adzpf_AdvZakatOut.Enabled = false;
            this.adzpf_AdvZakatOut.Location = new System.Drawing.Point(160, 70);
            this.adzpf_AdvZakatOut.Name = "adzpf_AdvZakatOut";
            this.adzpf_AdvZakatOut.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatOut.TabIndex = 10;
            // 
            // adzpf_IsActive
            // 
            this.adzpf_IsActive.AutoSize = true;
            this.adzpf_IsActive.Enabled = false;
            this.adzpf_IsActive.Location = new System.Drawing.Point(160, 243);
            this.adzpf_IsActive.Name = "adzpf_IsActive";
            this.adzpf_IsActive.Size = new System.Drawing.Size(91, 24);
            this.adzpf_IsActive.TabIndex = 11;
            this.adzpf_IsActive.Text = "IsActive";
            this.adzpf_IsActive.UseVisualStyleBackColor = true;
            // 
            // adzpf_IsAdvZakatPaid
            // 
            this.adzpf_IsAdvZakatPaid.AutoSize = true;
            this.adzpf_IsAdvZakatPaid.Enabled = false;
            this.adzpf_IsAdvZakatPaid.Location = new System.Drawing.Point(257, 243);
            this.adzpf_IsAdvZakatPaid.Name = "adzpf_IsAdvZakatPaid";
            this.adzpf_IsAdvZakatPaid.Size = new System.Drawing.Size(147, 24);
            this.adzpf_IsAdvZakatPaid.TabIndex = 12;
            this.adzpf_IsAdvZakatPaid.Text = "IsAdvZakatPaid";
            this.adzpf_IsAdvZakatPaid.UseVisualStyleBackColor = true;
            // 
            // adzpf_AdvZakatPaidDate
            // 
            this.adzpf_AdvZakatPaidDate.Location = new System.Drawing.Point(160, 200);
            this.adzpf_AdvZakatPaidDate.Name = "adzpf_AdvZakatPaidDate";
            this.adzpf_AdvZakatPaidDate.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatPaidDate.TabIndex = 13;
            // 
            // adzpf_AdvZakatBalance
            // 
            this.adzpf_AdvZakatBalance.Enabled = false;
            this.adzpf_AdvZakatBalance.Location = new System.Drawing.Point(160, 102);
            this.adzpf_AdvZakatBalance.Name = "adzpf_AdvZakatBalance";
            this.adzpf_AdvZakatBalance.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatBalance.TabIndex = 14;
            // 
            // adzpf_AdvZakatPaidTo
            // 
            this.adzpf_AdvZakatPaidTo.Location = new System.Drawing.Point(160, 134);
            this.adzpf_AdvZakatPaidTo.Name = "adzpf_AdvZakatPaidTo";
            this.adzpf_AdvZakatPaidTo.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatPaidTo.TabIndex = 15;
            // 
            // adzpf_AdvZakatComments
            // 
            this.adzpf_AdvZakatComments.Location = new System.Drawing.Point(160, 168);
            this.adzpf_AdvZakatComments.Name = "adzpf_AdvZakatComments";
            this.adzpf_AdvZakatComments.Size = new System.Drawing.Size(244, 26);
            this.adzpf_AdvZakatComments.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Comments:";
            // 
            // adzpf_Asset
            // 
            this.adzpf_Asset.Enabled = false;
            this.adzpf_Asset.FormattingEnabled = true;
            this.adzpf_Asset.Location = new System.Drawing.Point(160, 280);
            this.adzpf_Asset.Name = "adzpf_Asset";
            this.adzpf_Asset.Size = new System.Drawing.Size(244, 28);
            this.adzpf_Asset.TabIndex = 18;
            // 
            // AddAdvanceZakatPaidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(416, 362);
            this.Controls.Add(this.adzpf_Asset);
            this.Controls.Add(this.adzpf_AdvZakatComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.adzpf_AdvZakatPaidTo);
            this.Controls.Add(this.adzpf_AdvZakatBalance);
            this.Controls.Add(this.adzpf_AdvZakatPaidDate);
            this.Controls.Add(this.adzpf_IsAdvZakatPaid);
            this.Controls.Add(this.adzpf_IsActive);
            this.Controls.Add(this.adzpf_AdvZakatOut);
            this.Controls.Add(this.adzpf_AdvZakatIn);
            this.Controls.Add(this.adzpf_AdvZakatId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adzpf_btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAdvanceZakatPaidForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Advance Zakat Paid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adzpf_btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox adzpf_AdvZakatId;
        private System.Windows.Forms.TextBox adzpf_AdvZakatIn;
        private System.Windows.Forms.TextBox adzpf_AdvZakatOut;
        private System.Windows.Forms.CheckBox adzpf_IsActive;
        private System.Windows.Forms.CheckBox adzpf_IsAdvZakatPaid;
        private System.Windows.Forms.DateTimePicker adzpf_AdvZakatPaidDate;
        private System.Windows.Forms.TextBox adzpf_AdvZakatBalance;
        private System.Windows.Forms.TextBox adzpf_AdvZakatPaidTo;
        private System.Windows.Forms.TextBox adzpf_AdvZakatComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox adzpf_Asset;
    }
}