using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PF_ClassLibrary.Services;
using PF_ClassLibrary.Common;

namespace PF_Desktop.Common
{
    public partial class ApplicationTasks : Form
    {
        Tasks _tasks;
        ApplicationConfigurationDataAccess _applicationConfigurationDataAccess;
        ZakatDueDataAccess _zakatDueDataAccess;
        MetalServices metalService;
        MutualFundService mutualFundService;
        StockService stockService;
        public ApplicationTasks()
        {
            InitializeComponent();
            _zakatDueDataAccess = new ZakatDueDataAccess();
            _applicationConfigurationDataAccess = new ApplicationConfigurationDataAccess();
            _tasks = new Tasks();
            LoadTask();
        }

        private void btn_UpdateAssetZakat_Click(object sender, EventArgs e)
        {
            _tasks.UpdateAssetZakat();
            UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateAssetZakat);
        }



        private bool UpdateKeys(string appKey)
        {
            ApplicationConfiguration config = new ApplicationConfiguration
            {
                AppKey = appKey,
                AppKeyValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Format as needed
                AppConfigTimeStamp = DateTime.Now
            };

            return _applicationConfigurationDataAccess.UpdateConfiguration(config);
        }

        private void btn_UpdateZakatDue_Click(object sender, EventArgs e)
        {
            UpdateAllAssetTypeRates();
            UpdateZakatDue();
        }

        private void UpdateZakatDue()
        {
            bool success = _zakatDueDataAccess.ProcessAndSaveZakatDue();
            if (success)
                MessageBox.Show("ZakatDue Updated");
            else
                MessageBox.Show("Issue while updating ZakatDue");
            UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateZakatDues);
        }

        private void taskbtn_ZakatTransfer_Click(object sender, EventArgs e)
        {
            ZakatTransfer zakatTransfer = new ZakatTransfer();
            zakatTransfer.ShowDialog();
        }

        private void btn_UpdateZakatDueAssetZakat_Click(object sender, EventArgs e)
        {
            _tasks.UpdateAssetZakat();
            UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateAssetZakat);
            //_zakatDueDataAccess.ProcessAndSaveZakatDue();
            //UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateZakatDues);
            UpdateZakatDue();
        }

        private void UpdateKeyAndLableLastTimeUpdated(string appKey)
        {
            bool result = UpdateKeys(appKey);
            UpdateLastUpdatedLabel(appKey);
        }

        private void UpdateLastUpdatedLabel(string appKey)
        {
            // 🔹 Fetch configuration for the given key
            ApplicationConfiguration config = _applicationConfigurationDataAccess.GetConfigurationByKey(appKey);

            // 🔹 Determine which label to update
            string lastUpdatedText = (config != null && !string.IsNullOrEmpty(config.AppKeyValue))
                ? "Last updated on " + config.AppKeyValue
                : "Last updated on: Not Available";

            // 🔹 Use switch to update the correct label
            switch (appKey)
            {
                case AppKey.KeyUpdateAssetZakat:
                    tasksLbl_LastUpdatedOn.Text = lastUpdatedText;
                    break;

                case AppKey.KeyUpdateZakatDues:
                    tasksLbl_ZakatDueLastUpdatedOn.Text = lastUpdatedText;
                    break;

                case AppKey.KeyUpdateMetalRate:
                    tasksLbl_MetalRateLastUpdatedOn.Text = lastUpdatedText;
                    break;

                case AppKey.KeyUpdateStockRate:
                    tasksLbl_StocksRateLastUpdatedOn.Text = lastUpdatedText;
                    break;

                case AppKey.KeyUpdateMFRate:
                    tasksLbl_MFRateLastUpdatedOn.Text = lastUpdatedText;
                    break;

                default:
                    // Optional: Handle unknown keys (log warning, throw exception, etc.)
                    Console.WriteLine($"Warning: Unrecognized key '{appKey}' passed to UpdateLastUpdatedLabel.");
                    break;
            }
        }

        private async void taskbtn_UpdateMetalRate_Click(object sender, EventArgs e)
        {
            try
            {
                metalService = new MetalServices();
                await metalService.UpdateMetalRatesAsync();
                MessageBox.Show("Metal rates updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateMetalRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating metal rates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTask()
        {
            UpdateLastUpdatedLabel(AppKey.KeyUpdateAssetZakat);
            UpdateLastUpdatedLabel(AppKey.KeyUpdateZakatDues);
            UpdateLastUpdatedLabel(AppKey.KeyUpdateMetalRate);
            UpdateLastUpdatedLabel(AppKey.KeyUpdateStockRate);
            UpdateLastUpdatedLabel(AppKey.KeyUpdateMFRate);
        }

        private async void taskbtn_UpdateStocksRate_Click(object sender, EventArgs e)
        {
            try
            {
                StockService stockService = new StockService();
                await stockService.UpdateCIL();
                MessageBox.Show("Stocks rates updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateStockRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stocks rates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void taskbtn_UpdateMFRate_Click(object sender, EventArgs e)
        {
            try
            {
                mutualFundService = new MutualFundService();
                await mutualFundService.UpdateMFRates();
                MessageBox.Show("MF rates updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateKeyAndLableLastTimeUpdated(AppKey.KeyUpdateMFRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating MF's rates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateAllAssetTypeRates()
        {
            metalService = new MetalServices();
            await metalService.UpdateMetalRatesAsync();

            mutualFundService = new MutualFundService();
            await mutualFundService.UpdateMFRates();

            stockService = new StockService();
            await stockService.UpdateCIL();
        }
    }
}
