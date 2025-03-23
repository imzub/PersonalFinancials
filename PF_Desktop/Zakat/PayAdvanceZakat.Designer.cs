namespace PF_Desktop.Zakat
{
    partial class PayAdvanceZakat
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
            this.paz_Asset = new System.Windows.Forms.ComboBox();
            this.paz_AdvZakatComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.paz_AdvZakatPaidTo = new System.Windows.Forms.TextBox();
            this.paz_AdvZakatPaidDate = new System.Windows.Forms.DateTimePicker();
            this.paz_AdvZakatIn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paz_btnSave = new System.Windows.Forms.Button();
            this.paz_CurrentAdvZakatBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paz_Asset
            // 
            this.paz_Asset.Enabled = false;
            this.paz_Asset.FormattingEnabled = true;
            this.paz_Asset.Location = new System.Drawing.Point(105, 102);
            this.paz_Asset.Name = "paz_Asset";
            this.paz_Asset.Size = new System.Drawing.Size(274, 28);
            this.paz_Asset.TabIndex = 37;
            // 
            // paz_AdvZakatComments
            // 
            this.paz_AdvZakatComments.Location = new System.Drawing.Point(105, 136);
            this.paz_AdvZakatComments.Name = "paz_AdvZakatComments";
            this.paz_AdvZakatComments.Size = new System.Drawing.Size(274, 26);
            this.paz_AdvZakatComments.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Comments:";
            // 
            // paz_AdvZakatPaidTo
            // 
            this.paz_AdvZakatPaidTo.Location = new System.Drawing.Point(105, 38);
            this.paz_AdvZakatPaidTo.Name = "paz_AdvZakatPaidTo";
            this.paz_AdvZakatPaidTo.Size = new System.Drawing.Size(274, 26);
            this.paz_AdvZakatPaidTo.TabIndex = 34;
            // 
            // paz_AdvZakatPaidDate
            // 
            this.paz_AdvZakatPaidDate.Location = new System.Drawing.Point(105, 70);
            this.paz_AdvZakatPaidDate.Name = "paz_AdvZakatPaidDate";
            this.paz_AdvZakatPaidDate.Size = new System.Drawing.Size(274, 26);
            this.paz_AdvZakatPaidDate.TabIndex = 32;
            // 
            // paz_AdvZakatIn
            // 
            this.paz_AdvZakatIn.ForeColor = System.Drawing.Color.Green;
            this.paz_AdvZakatIn.Location = new System.Drawing.Point(105, 6);
            this.paz_AdvZakatIn.Name = "paz_AdvZakatIn";
            this.paz_AdvZakatIn.Size = new System.Drawing.Size(274, 26);
            this.paz_AdvZakatIn.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Asset:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Current Advance Zakat Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Amount:";
            // 
            // paz_btnSave
            // 
            this.paz_btnSave.Location = new System.Drawing.Point(307, 168);
            this.paz_btnSave.Name = "paz_btnSave";
            this.paz_btnSave.Size = new System.Drawing.Size(72, 35);
            this.paz_btnSave.TabIndex = 19;
            this.paz_btnSave.Text = "Save";
            this.paz_btnSave.UseVisualStyleBackColor = true;
            this.paz_btnSave.Click += new System.EventHandler(this.paz_btnSave_Click);
            // 
            // paz_CurrentAdvZakatBalance
            // 
            this.paz_CurrentAdvZakatBalance.AutoSize = true;
            this.paz_CurrentAdvZakatBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paz_CurrentAdvZakatBalance.ForeColor = System.Drawing.Color.IndianRed;
            this.paz_CurrentAdvZakatBalance.Location = new System.Drawing.Point(152, 247);
            this.paz_CurrentAdvZakatBalance.Name = "paz_CurrentAdvZakatBalance";
            this.paz_CurrentAdvZakatBalance.Size = new System.Drawing.Size(71, 20);
            this.paz_CurrentAdvZakatBalance.TabIndex = 38;
            this.paz_CurrentAdvZakatBalance.Text = "Amount";
            // 
            // PayAdvanceZakat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(395, 275);
            this.Controls.Add(this.paz_CurrentAdvZakatBalance);
            this.Controls.Add(this.paz_Asset);
            this.Controls.Add(this.paz_AdvZakatComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paz_AdvZakatPaidTo);
            this.Controls.Add(this.paz_AdvZakatPaidDate);
            this.Controls.Add(this.paz_AdvZakatIn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paz_btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayAdvanceZakat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Advance Zakat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox paz_Asset;
        private System.Windows.Forms.TextBox paz_AdvZakatComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox paz_AdvZakatPaidTo;
        private System.Windows.Forms.DateTimePicker paz_AdvZakatPaidDate;
        private System.Windows.Forms.TextBox paz_AdvZakatIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button paz_btnSave;
        private System.Windows.Forms.Label paz_CurrentAdvZakatBalance;
    }
}