namespace PF_Desktop.Common
{
    partial class Settings
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
            this.rb_devDB = new System.Windows.Forms.RadioButton();
            this.rb_prodDB = new System.Windows.Forms.RadioButton();
            this.settingsBtn_dbApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select DB:";
            // 
            // rb_devDB
            // 
            this.rb_devDB.AutoSize = true;
            this.rb_devDB.Location = new System.Drawing.Point(135, 30);
            this.rb_devDB.Name = "rb_devDB";
            this.rb_devDB.Size = new System.Drawing.Size(128, 24);
            this.rb_devDB.TabIndex = 1;
            this.rb_devDB.TabStop = true;
            this.rb_devDB.Text = "Development";
            this.rb_devDB.UseVisualStyleBackColor = true;
            // 
            // rb_prodDB
            // 
            this.rb_prodDB.AutoSize = true;
            this.rb_prodDB.Location = new System.Drawing.Point(284, 30);
            this.rb_prodDB.Name = "rb_prodDB";
            this.rb_prodDB.Size = new System.Drawing.Size(110, 24);
            this.rb_prodDB.TabIndex = 2;
            this.rb_prodDB.TabStop = true;
            this.rb_prodDB.Text = "Production";
            this.rb_prodDB.UseVisualStyleBackColor = true;
            // 
            // settingsBtn_dbApply
            // 
            this.settingsBtn_dbApply.Location = new System.Drawing.Point(419, 28);
            this.settingsBtn_dbApply.Name = "settingsBtn_dbApply";
            this.settingsBtn_dbApply.Size = new System.Drawing.Size(90, 29);
            this.settingsBtn_dbApply.TabIndex = 3;
            this.settingsBtn_dbApply.Text = "Apply";
            this.settingsBtn_dbApply.UseVisualStyleBackColor = true;
            this.settingsBtn_dbApply.Click += new System.EventHandler(this.settingsBtn_dbApply_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 399);
            this.Controls.Add(this.settingsBtn_dbApply);
            this.Controls.Add(this.rb_prodDB);
            this.Controls.Add(this.rb_devDB);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_devDB;
        private System.Windows.Forms.RadioButton rb_prodDB;
        private System.Windows.Forms.Button settingsBtn_dbApply;
    }
}