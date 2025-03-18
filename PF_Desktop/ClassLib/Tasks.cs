using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.DataAccess;
using PF_ClassLibrary.Model;

namespace PF_ClassLibrary.Services
{
    public class Tasks
    {
        AssetZakatFinYearDataAccess _assetZakatFinYearDataAccess;
        ExceptionLogDataAccess logger;

        public Tasks()
        {
            _assetZakatFinYearDataAccess = new AssetZakatFinYearDataAccess();
        }

        public void UpdateAssetZakat()
        {
            try
            {
                // 🔹 Step 1: Get the list of assets that need to be added to Zakat with full details
                List<Asset> missingAssets = _assetZakatFinYearDataAccess.GetAssetsNotInZakatFinYearWithDetails();

                // 🔹 Step 2: If no assets are missing, show message and return
                if (missingAssets == null || missingAssets.Count == 0)
                {
                    MessageBox.Show("Asset Zakat updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔹 Step 3: Ask user for confirmation
                string message = $"There are {missingAssets.Count} assets missing from Zakat records.\nDo you want to proceed with the update?";
                DialogResult result = MessageBox.Show(message, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 🔹 Step 4: Insert missing assets into tbl_AssetZakatFinYear
                    foreach (var asset in missingAssets)
                    {
                        DateTime zakatApplicableDate = asset.ZakatApplicableFromDate.HasValue
                            ? asset.ZakatApplicableFromDate.Value
                            : DateTime.Today; // Fetching the correct bought date
                        DateTime zakatStartDate = zakatApplicableDate; // Zakat Start Date = Bought Date
                        DateTime zakatEndDate = zakatApplicableDate.AddDays(354); // Zakat End Date = Bought Date + 354 days

                        AssetZakatFinYear assetZakatFinYear = new AssetZakatFinYear
                        {
                            AssetId = asset.AssetId, // Asset ID
                            AssetZakatFinYearStartDate = zakatStartDate, // Bought Date as Start Date
                            AssetZakatFinYearEndDate = zakatEndDate, // Bought Date + 354 days as End Date
                            IsAssetZakatFinYearActive = true // Set active
                        };

                        _assetZakatFinYearDataAccess.InsertAssetZakatFinYear(assetZakatFinYear);
                    }

                    MessageBox.Show("Missing assets added to Zakat successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
                MessageBox.Show($"Error updating asset Zakat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
