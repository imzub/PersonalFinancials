namespace PF_Desktop.Assets
{
    partial class AssetTypeForm
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
            this.assettypebtn_AssetTypeSave = new System.Windows.Forms.Button();
            this.assettypetb_AssetTypeId = new System.Windows.Forms.TextBox();
            this.assettypetb_AssetTypeName = new System.Windows.Forms.TextBox();
            this.assettypetb_AssetTypeDescription = new System.Windows.Forms.TextBox();
            this.assettypetb_AssetTypeValueUnit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Type ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Type Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Type Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Asset Type Current Value Per Unit in INR \t₹:";
            // 
            // assettypebtn_AssetTypeSave
            // 
            this.assettypebtn_AssetTypeSave.Location = new System.Drawing.Point(260, 267);
            this.assettypebtn_AssetTypeSave.Name = "assettypebtn_AssetTypeSave";
            this.assettypebtn_AssetTypeSave.Size = new System.Drawing.Size(91, 34);
            this.assettypebtn_AssetTypeSave.TabIndex = 4;
            this.assettypebtn_AssetTypeSave.Text = "Save";
            this.assettypebtn_AssetTypeSave.UseVisualStyleBackColor = true;
            this.assettypebtn_AssetTypeSave.Click += new System.EventHandler(this.assettypebtn_AssetTypeSave_Click);
            // 
            // assettypetb_AssetTypeId
            // 
            this.assettypetb_AssetTypeId.Location = new System.Drawing.Point(131, 6);
            this.assettypetb_AssetTypeId.Name = "assettypetb_AssetTypeId";
            this.assettypetb_AssetTypeId.ReadOnly = true;
            this.assettypetb_AssetTypeId.Size = new System.Drawing.Size(220, 26);
            this.assettypetb_AssetTypeId.TabIndex = 5;
            this.assettypetb_AssetTypeId.Text = "0";
            // 
            // assettypetb_AssetTypeName
            // 
            this.assettypetb_AssetTypeName.Location = new System.Drawing.Point(16, 69);
            this.assettypetb_AssetTypeName.Name = "assettypetb_AssetTypeName";
            this.assettypetb_AssetTypeName.Size = new System.Drawing.Size(335, 26);
            this.assettypetb_AssetTypeName.TabIndex = 6;
            // 
            // assettypetb_AssetTypeDescription
            // 
            this.assettypetb_AssetTypeDescription.Location = new System.Drawing.Point(16, 134);
            this.assettypetb_AssetTypeDescription.Multiline = true;
            this.assettypetb_AssetTypeDescription.Name = "assettypetb_AssetTypeDescription";
            this.assettypetb_AssetTypeDescription.Size = new System.Drawing.Size(335, 61);
            this.assettypetb_AssetTypeDescription.TabIndex = 7;
            // 
            // assettypetb_AssetTypeValueUnit
            // 
            this.assettypetb_AssetTypeValueUnit.ForeColor = System.Drawing.Color.Green;
            this.assettypetb_AssetTypeValueUnit.Location = new System.Drawing.Point(16, 235);
            this.assettypetb_AssetTypeValueUnit.Name = "assettypetb_AssetTypeValueUnit";
            this.assettypetb_AssetTypeValueUnit.Size = new System.Drawing.Size(335, 26);
            this.assettypetb_AssetTypeValueUnit.TabIndex = 8;
            this.assettypetb_AssetTypeValueUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.assettypetb_AssetTypeValueUnit_KeyPress);
            // 
            // AssetTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(365, 310);
            this.Controls.Add(this.assettypetb_AssetTypeId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assettypetb_AssetTypeValueUnit);
            this.Controls.Add(this.assettypetb_AssetTypeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.assettypetb_AssetTypeDescription);
            this.Controls.Add(this.assettypebtn_AssetTypeSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssetType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button assettypebtn_AssetTypeSave;
        private System.Windows.Forms.TextBox assettypetb_AssetTypeId;
        private System.Windows.Forms.TextBox assettypetb_AssetTypeName;
        private System.Windows.Forms.TextBox assettypetb_AssetTypeDescription;
        private System.Windows.Forms.TextBox assettypetb_AssetTypeValueUnit;
    }
}