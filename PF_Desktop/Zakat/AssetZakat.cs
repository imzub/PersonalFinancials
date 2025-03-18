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

namespace PF_Desktop.Zakat
{
    public partial class AssetZakat : Form
    {
        private long _assetZakatFinYearId = 0;
        AssetZakatFinYearDataAccess _assetZakatFinYearDataAccess;
        public AssetZakat()
        {
            InitializeComponent();
            LoadAssetsIntoComboBox();
        }

        public AssetZakat(long assetZakatFinYearId = 0)
        {
            InitializeComponent();
            LoadAssetsIntoComboBox();
            _assetZakatFinYearId = assetZakatFinYearId;
            _assetZakatFinYearDataAccess = new AssetZakatFinYearDataAccess();

            if (_assetZakatFinYearId > 0)
            {
                LoadAssetZakatData();
            }
        }

        private void LoadAssetZakatData()
        {
            AssetZakatFinYear assetZakat = _assetZakatFinYearDataAccess.GetAssetZakatFinYearById(_assetZakatFinYearId);

            if (assetZakat != null)
            {
                lbl_AssetZakatFinYearId.Text = assetZakat.AssetZakatFinYearId.ToString();
                azcb_AssetId.SelectedValue = assetZakat.AssetId;
                azdtp_StartDate.Value = assetZakat.AssetZakatFinYearStartDate;
                azdtp_EndDate.Value = assetZakat.AssetZakatFinYearEndDate;
                azcb_IsActive.Checked = assetZakat.IsAssetZakatFinYearActive;
            }
        }

        private void LoadAssetsIntoComboBox()
        {
            AssetZakatFinYearDataAccess dataAccess = new AssetZakatFinYearDataAccess();
            var assetList = dataAccess.GetAssetListForComboBox();

            azcb_AssetId.DataSource = new BindingSource(assetList, null);
            azcb_AssetId.DisplayMember = "Value"; // Show Asset Name
            azcb_AssetId.ValueMember = "Key"; // Store Asset ID
        }

        private void azbtn_SaveUpdateAssetZakat_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Step 1: Retrieve values from controls
                long assetZakatFinYearId = long.TryParse(lbl_AssetZakatFinYearId.Text, out long id) ? id : 0;
                long assetId = azcb_AssetId.SelectedValue != null ? Convert.ToInt64(azcb_AssetId.SelectedValue) : 0;
                DateTime startDate = azdtp_StartDate.Value;
                DateTime endDate = azdtp_EndDate.Value;
                bool isActive = azcb_IsActive.Checked;

                // 🔹 Step 2: Validate required fields
                if (assetId == 0 || startDate == DateTime.MinValue || endDate == DateTime.MinValue)
                {
                    MessageBox.Show("Please select a valid asset and enter start & end dates.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Step 3: Create AssetZakatFinYear object
                AssetZakatFinYear assetZakatFinYear = new AssetZakatFinYear
                {
                    AssetZakatFinYearId = assetZakatFinYearId,
                    AssetId = assetId,
                    AssetZakatFinYearStartDate = startDate,
                    AssetZakatFinYearEndDate = endDate,
                    IsAssetZakatFinYearActive = isActive
                };

                AssetZakatFinYearDataAccess dataAccess = new AssetZakatFinYearDataAccess();
                bool isSuccess;

                // 🔹 Step 4: Insert or Update based on ID
                if (assetZakatFinYearId > 0)
                {
                    // Update existing record
                    isSuccess = dataAccess.UpdateAssetZakatFinYear(assetZakatFinYear);
                }
                else
                {
                    // Insert new record
                    isSuccess = dataAccess.InsertAssetZakatFinYear(assetZakatFinYear);
                }

                // 🔹 Step 5: Show Success or Error Message
                if (isSuccess)
                {
                    MessageBox.Show(assetZakatFinYearId > 0 ? "Asset Zakat updated successfully!" : "Asset Zakat saved successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Clear form after successful operation
                }
                else
                {
                    MessageBox.Show("Operation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            lbl_AssetZakatFinYearId.Text = "0"; // Reset ID for new entries
            azcb_AssetId.SelectedIndex = -1;
            azdtp_StartDate.Value = DateTime.Now;
            azdtp_EndDate.Value = DateTime.Now;
            azcb_IsActive.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
