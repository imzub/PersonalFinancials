using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PF_ClassLibrary.Common;

namespace PF_Desktop.Common
{
    public partial class SettingExportImportForm : Form
    {
        private readonly string exportPath;
        private readonly string importPath;
        DatabaseExportImport _databaseExportImport;

        public SettingExportImportForm()
        {
            InitializeComponent();

            // Initialize readonly fields in constructor
            exportPath = ConfigHelper.GetExportLocation();
            importPath = ConfigHelper.GetImportLocation();

            // Load existing paths from App.config
            txtImportLocation.Text = ConfigHelper.GetImportLocation();
            txtExportLocation.Text = ConfigHelper.GetExportLocation();

            seifcb_ImportFileFormat.DataSource = seifcb_ExportFileFormat.DataSource = Enum.GetValues(typeof(EnumAndKeys.ExportFileFormat));
        }

        //public bool UpdateImportExportLocation(string importLocation, string exportLocation)
        //{
        //    try
        //    {
        //        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //        // Update or Add Key
        //        config.AppSettings.Settings["ImportLocation"].Value = importLocation;
        //        config.AppSettings.Settings["ExportLocation"].Value = exportLocation;

        //        // Save the changes to the config file
        //        config.Save(ConfigurationSaveMode.Modified);

        //        // Refresh the section to apply changes
        //        ConfigurationManager.RefreshSection("appSettings");

        //        return true; // Successfully updated
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error updating config: " + ex.Message);
        //        return false; // Update failed
        //    }
        //}

        public bool UpdateImportExportLocation(string importLocation, string exportLocation)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = config.AppSettings.Settings;

                // Add or update ImportLocation
                if (settings["ImportLocation"] == null)
                    settings.Add("ImportLocation", importLocation);
                else
                    settings["ImportLocation"].Value = importLocation;

                // Add or update ExportLocation
                if (settings["ExportLocation"] == null)
                    settings.Add("ExportLocation", exportLocation);
                else
                    settings["ExportLocation"].Value = exportLocation;

                // Save and refresh
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating config: " + ex.Message);
                return false;
            }
        }

        private void UpdateOrCreateKey(XmlNode appSettingsNode, string key, string value)
        {
            XmlNode keyNode = appSettingsNode.SelectSingleNode($"add[@key='{key}']");

            if (keyNode != null)
            {
                keyNode.Attributes["value"].Value = value; // Update existing key
            }
            else
            {
                XmlElement newElement = appSettingsNode.OwnerDocument.CreateElement("add");
                newElement.SetAttribute("key", key);
                newElement.SetAttribute("value", value);
                appSettingsNode.AppendChild(newElement); // Add new key
            }
        }

        private void btnBrowseImport_Click(object sender, EventArgs e)
        {
            string folderPath = BrowseFolder();
            if (!string.IsNullOrEmpty(folderPath))
            {
                txtImportLocation.Text = folderPath;
            }
        }

        private void btnBrowseExport_Click(object sender, EventArgs e)
        {
            string folderPath = BrowseFolder();
            if (!string.IsNullOrEmpty(folderPath))
            {
                txtExportLocation.Text = folderPath;
            }
        }

        private string BrowseFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
            }
            return string.Empty;
        }

        private void seifbtn_SaveLocation_Click(object sender, EventArgs e)
        {
            string importPath = txtImportLocation.Text.Trim();
            string exportPath = txtExportLocation.Text.Trim();

            if (UpdateImportExportLocation(importPath, exportPath))
            {
                MessageBox.Show("Import/Export locations updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update locations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seif_ExportAllData_Click(object sender, EventArgs e)
        {
            try
            {
                string exportPath = ConfigHelper.GetExportLocation();
                if (string.IsNullOrWhiteSpace(exportPath))
                {
                    MessageBox.Show("Please set the export location in settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate selected export format
                if (seifcb_ExportFileFormat.SelectedItem is EnumAndKeys.ExportFileFormat selectedFormat && selectedFormat != EnumAndKeys.ExportFileFormat.Select)
                {
                    _databaseExportImport = new DatabaseExportImport();
                    _databaseExportImport.ExportAllTables(exportPath, selectedFormat);

                    MessageBox.Show($"All tables exported successfully in {selectedFormat} format!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a valid file format for export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seif_ImportAllData_Click(object sender, EventArgs e)
        {
            //string importPath = ConfigHelper.GetExportLocation();
            _databaseExportImport = new DatabaseExportImport();
            //_databaseExportImport.ImportFromCsv("tbl_AssetZakatFinYear", "C:/Users/zubai/Downloads/tbl_AssetZakatFinYear.csv");
            //_databaseExportImport.ImportFromCsv("tbl_ZakatDue", "C:/Users/zubai/Downloads/tbl_ZakatDue.csv");
            //_databaseExportImport.ImportAssetZakatFinYear("C:/Users/zubai/Downloads/tbl_AssetZakatFinYear.csv");
            _databaseExportImport.ImportFromJson("tbl_ZakatDue", "C:/Users/zubai/Downloads/tbl_ZakatDue.json");
        }
    }
}
