using System;
using System.Windows.Forms;
using System.Configuration;

namespace PF_Desktop.Common
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadSelectedDatabase(); // Load saved selection on form load
        }

        private void settingsBtn_dbApply_Click(object sender, EventArgs e)
        {
            string selectedDB = rb_prodDB.Checked ? "PersonalFinancialsDBProd" : "PersonalFinancialsDB";

            // Update the configuration file with the selected database
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SelectedDatabase"].Value = selectedDB;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Database selection updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadSelectedDatabase()
        {
            string selectedDB = ConfigurationManager.AppSettings["SelectedDatabase"];

            if (selectedDB == "PersonalFinancialsDBProd")
                rb_prodDB.Checked = true;
            else
                rb_devDB.Checked = true;
        }
    }
}
