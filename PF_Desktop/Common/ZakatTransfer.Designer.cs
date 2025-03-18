namespace PF_Desktop.Common
{
    partial class ZakatTransfer
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
            this.ztbtn_Transfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ztcb_FromAsset = new System.Windows.Forms.ComboBox();
            this.ztcb_ToAsset = new System.Windows.Forms.ComboBox();
            this.ztlbl_FromAssetAmount = new System.Windows.Forms.Label();
            this.ztlbl_ToAssetAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ztbtn_Transfer
            // 
            this.ztbtn_Transfer.Location = new System.Drawing.Point(146, 135);
            this.ztbtn_Transfer.Name = "ztbtn_Transfer";
            this.ztbtn_Transfer.Size = new System.Drawing.Size(126, 31);
            this.ztbtn_Transfer.TabIndex = 0;
            this.ztbtn_Transfer.Text = "Transfer";
            this.ztbtn_Transfer.UseVisualStyleBackColor = true;
            this.ztbtn_Transfer.Click += new System.EventHandler(this.ztbtn_Transfer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Asset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Asset";
            // 
            // ztcb_FromAsset
            // 
            this.ztcb_FromAsset.FormattingEnabled = true;
            this.ztcb_FromAsset.Location = new System.Drawing.Point(12, 51);
            this.ztcb_FromAsset.Name = "ztcb_FromAsset";
            this.ztcb_FromAsset.Size = new System.Drawing.Size(172, 28);
            this.ztcb_FromAsset.TabIndex = 3;
            this.ztcb_FromAsset.SelectedIndexChanged += new System.EventHandler(this.ztcb_FromAsset_SelectedIndexChanged);
            // 
            // ztcb_ToAsset
            // 
            this.ztcb_ToAsset.FormattingEnabled = true;
            this.ztcb_ToAsset.Location = new System.Drawing.Point(249, 51);
            this.ztcb_ToAsset.Name = "ztcb_ToAsset";
            this.ztcb_ToAsset.Size = new System.Drawing.Size(176, 28);
            this.ztcb_ToAsset.TabIndex = 4;
            this.ztcb_ToAsset.SelectedIndexChanged += new System.EventHandler(this.ztcb_ToAsset_SelectedIndexChanged);
            // 
            // ztlbl_FromAssetAmount
            // 
            this.ztlbl_FromAssetAmount.AutoSize = true;
            this.ztlbl_FromAssetAmount.Location = new System.Drawing.Point(12, 92);
            this.ztlbl_FromAssetAmount.Name = "ztlbl_FromAssetAmount";
            this.ztlbl_FromAssetAmount.Size = new System.Drawing.Size(18, 20);
            this.ztlbl_FromAssetAmount.TabIndex = 5;
            this.ztlbl_FromAssetAmount.Text = "$";
            // 
            // ztlbl_ToAssetAmount
            // 
            this.ztlbl_ToAssetAmount.AutoSize = true;
            this.ztlbl_ToAssetAmount.Location = new System.Drawing.Point(245, 92);
            this.ztlbl_ToAssetAmount.Name = "ztlbl_ToAssetAmount";
            this.ztlbl_ToAssetAmount.Size = new System.Drawing.Size(18, 20);
            this.ztlbl_ToAssetAmount.TabIndex = 6;
            this.ztlbl_ToAssetAmount.Text = "$";
            // 
            // ZakatTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 178);
            this.Controls.Add(this.ztlbl_ToAssetAmount);
            this.Controls.Add(this.ztlbl_FromAssetAmount);
            this.Controls.Add(this.ztcb_ToAsset);
            this.Controls.Add(this.ztcb_FromAsset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ztbtn_Transfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ZakatTransfer";
            this.Text = "ZakatTransfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ztbtn_Transfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ztcb_FromAsset;
        private System.Windows.Forms.ComboBox ztcb_ToAsset;
        private System.Windows.Forms.Label ztlbl_FromAssetAmount;
        private System.Windows.Forms.Label ztlbl_ToAssetAmount;
    }
}