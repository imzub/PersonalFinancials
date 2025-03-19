using PF_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.DataAccess;
using PersonalFinancials.Models;

namespace PF_Desktop.Common
{
    public partial class AssetDueZakatSetoff : Form
    {
        ZakatDueDataAccess _zakatDueDataAccess;
        AdvanceZakatDataAccess _advanceZakatDataAccess;
        decimal advZakatBal;
        EventLogDataAccess eventLogger = new EventLogDataAccess();

        public AssetDueZakatSetoff()
        {
            InitializeComponent();
            GetAdvanceZakatBalance();
            LoadAssetsIntoComboBox();
        }

        private void GetAdvanceZakatBalance()
        {
            try
            {
                _advanceZakatDataAccess = new AdvanceZakatDataAccess();
                advZakatBal = _advanceZakatDataAccess.GetAdvanceZakatBalance();
                adzs_CurrentAdvZakatBalance.Text = Convert.ToString(Math.Round(advZakatBal, 2));
            }
            catch (Exception ex) { }
        }

        private void adzs_Asset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adzs_Asset.SelectedItem is ZakatDue selectedZakatDue)
            {
                // Set the Zakat Due Amount in the textbox
                adzs_AssetDueAmount.Text = selectedZakatDue.DueZakat.ToString("N2");
            }
        }

        private void LoadAssetsIntoComboBox()
        {
            _zakatDueDataAccess = new ZakatDueDataAccess();
            var zakatDueAssets = _zakatDueDataAccess.GetActiveZakatDueAssets();
            zakatDueAssets.Insert(0, new ZakatDue { AssetId = 0, AssetName = "--Select--" });
            // Insert "No Asset" option at the top
            //zakatDueAssets.Insert(0, new ZakatDue { AssetId = 0, AssetName = "No Asset" });

            adzs_Asset.DataSource = zakatDueAssets;
            adzs_Asset.DisplayMember = "AssetName"; // Show Asset Name in dropdown
            adzs_Asset.ValueMember = "AssetId";     // Store Asset ID as selected value
        }

        private void adzs_btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (adzs_Asset.SelectedValue == null || adzs_Asset.SelectedValue.ToString() == "0" || adzs_Asset.Text == "--Select--")
                {
                    MessageBox.Show("Please select a valid asset.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long assetId = Convert.ToInt64(adzs_Asset.SelectedValue);
                decimal assetZakatDueAmount;

                if (!decimal.TryParse(adzs_AssetDueAmount.Text.Trim(), out assetZakatDueAmount))
                {
                    MessageBox.Show("Invalid Zakat due amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call DataAccess method to update balance & deactivate zakat due
                AdvanceZakatDataAccess zakatDataAccess = new AdvanceZakatDataAccess();
                AdvanceZakat advanceZakat = new AdvanceZakat();
                advanceZakat.AssetId = assetId;
                advanceZakat.AdvZakatIn = 0m;
                advanceZakat.AdvZakatOut = assetZakatDueAmount;
                advZakatBal = _advanceZakatDataAccess.GetAdvanceZakatBalance();
                advanceZakat.AdvZakatBalance = advZakatBal - assetZakatDueAmount;
                advanceZakat.AdvZakatPaidDate = DateTime.Now;
                advanceZakat.IsAdvZakatPaid = false;
                advanceZakat.IsActive = true;

                if (adzs_Asset.SelectedItem is ZakatDue selectedZakatDue)
                {
                    advanceZakat.ZakatDueId = selectedZakatDue.ZakatDueId;
                }

                bool success = zakatDataAccess.SetoffAdvanceZakat(advanceZakat);

                if (success)
                {
                    MessageBox.Show("Zakat payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssetsIntoComboBox();
                    adzs_AssetDueAmount.Text = string.Empty;
                    GetAdvanceZakatBalance();                    
                    PFHome.Instance?.LoadZakatSummery();

                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = "Setoff",
                        EventMessage = "Zakat payment processed successfully.",
                        EventSource = "AssetDueZakatSetoff",
                        UserName = "System"
                    });
                }
                else
                {
                    MessageBox.Show("Failed to update Zakat balance. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogDataAccess logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
