using PersonalFinancials.DataAccess;
using PF_ClassLibrary.DataAccess;
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
using PF_Desktop.ClassLib;

namespace PF_Desktop.Zakat
{
    public partial class PayAdvanceZakat : Form
    {
        AdvanceZakatDataAccess _advanceZakatDataAccess;
        decimal advZakatBal;
        public PayAdvanceZakat()
        {
            InitializeComponent();
            GetAdvanceZakatBalance();
            LoadAssetsIntoComboBox();
            FormLoad();
        }

        private void paz_btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Retrieve values from controls
                decimal advZakatIn = decimal.TryParse(paz_AdvZakatIn.Text.Trim(), out decimal zakatIn) ? zakatIn : 0m;
                long assetId = paz_Asset.SelectedValue != null ? Convert.ToInt64(paz_Asset.SelectedValue) : 0;
                string advZakatPaidTo = paz_AdvZakatPaidTo.Text.Trim();
                string comments = paz_AdvZakatComments.Text.Trim().Trim();
                DateTime advZakatPaidDate = paz_AdvZakatPaidDate.Value;

                // Step 2: Validate required fields
                if (advZakatIn < 0 || string.IsNullOrEmpty(advZakatPaidTo))
                {
                    MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Step 3: Create AdvanceZakat object
                AdvanceZakat advanceZakat = new AdvanceZakat
                {
                    AdvZakatIn = advZakatIn,
                    AssetId = assetId,
                    AdvZakatPaidTo = advZakatPaidTo,
                    AdvZakatPaidDate = advZakatPaidDate,
                    Comments = comments
                };

                _advanceZakatDataAccess = new AdvanceZakatDataAccess();
                bool success = _advanceZakatDataAccess.PayAdvanceZakat(advanceZakat);

                // Step 5: Show result message
                if (success)
                {

                    MessageBox.Show("Advance Zakat saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PFHome.Instance?.LoadZakatSummery();
                    this.Close(); // Close form after success
                }
                else
                {
                    MessageBox.Show("Failed to save Advance Zakat. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Advance Zakat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAdvanceZakatBalance()
        {
            try
            {
                _advanceZakatDataAccess = new AdvanceZakatDataAccess();
                advZakatBal = _advanceZakatDataAccess.GetAdvanceZakatBalance();
                paz_CurrentAdvZakatBalance.Text = Convert.ToString(Math.Round(advZakatBal, 2));
            }
            catch (Exception ex) { throw ex; }
        }

        private void LoadAssetsIntoComboBox()
        {
            AssetDataAccess assetDataAccess = new AssetDataAccess();
            List<Asset> assetList = assetDataAccess.GetAllAssetNameId();
            assetList.Insert(0, new Asset { AssetId = 0, AssetName = "--Select--" });
            paz_Asset.DataSource = assetList;
            paz_Asset.DisplayMember = "AssetName";  // Show asset name
            paz_Asset.ValueMember = "AssetId";      // Store asset ID
        }

        private void FormLoad()
        {
            paz_AdvZakatIn.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
        }
    }
}
