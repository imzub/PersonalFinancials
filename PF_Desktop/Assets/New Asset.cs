using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.DataAccess;
using PF_ClassLibrary.Model;
using PersonalFinancials.Models;
using PF_Desktop.ClassLib;

namespace PF_Desktop.Assets
{
    public partial class New_Asset : Form
    {
        private long _assetId;
        private readonly UserDataAccess _userDataAccess;
        private AssetDataAccess _assetDataAccess;
        private AssetHistoryDataAccess _assetHistoryDataAccess;
        private EventLogDataAccess eventLogger = new EventLogDataAccess();

        public New_Asset()
        {
            InitializeComponent();
            LoadAssetTypes();
            _userDataAccess = new UserDataAccess();  // ✅ Creating an instance of UserDataAccess
            LoadUsers();
            FormLoad();
            _assetDataAccess = new AssetDataAccess();
            this.Text = "Add New Asset";
        }

        public New_Asset(long assetId)
        {
            InitializeComponent();
            LoadAssetTypes();
            _userDataAccess = new UserDataAccess();
            LoadUsers();
            _assetId = assetId;
            _assetDataAccess = new AssetDataAccess();
            LoadAssetDetails();
            this.Text = "Update Asset";
        }

        private void LoadAssetDetails()
        {
            Asset asset = _assetDataAccess.GetAssetById(_assetId);
            if (asset != null)
            {
                lbl_AssetId.Text = Convert.ToString(_assetId);
                // Bind values to controls
                nacb_AssetType.SelectedValue = asset.AssetTypeId;
                nacb_Users.SelectedValue = asset.UserId;
                natb_AssetName.Text = asset.AssetName;
                natb_AssetDesciption.Text = asset.AssetDesc;
                natb_AssetUnits.Text = asset.AssetUnits.ToString();
                nadtp_AssetBoughtDate.Value = asset.AssetBoughtDate;
                natb_AssetBoughtPrice.Text = asset.AssetBoughtPrice.ToString();
                if (asset.ZakatApplicableFromDate < nadtp_ZakatApplicableFromDate.MinDate || asset.ZakatApplicableFromDate is null)
                {
                    nadtp_ZakatApplicableFromDate.Value = nadtp_ZakatApplicableFromDate.MinDate;
                }
                else
                {
                    nadtp_ZakatApplicableFromDate.Value = asset.ZakatApplicableFromDate ?? DateTime.MinValue; ;
                }
                nacb_AssetIsActive.Checked = asset.IsAssetActive;
                nacb_IsZakatApplicable.Checked = asset.IsAssetZakatApplicable;

            }
        }

        private void LoadAssetTypes()
        {
            try
            {
                AssetTypeDataAccess assetTypeDataAccess = new AssetTypeDataAccess();
                List<AssetType> assetTypes = assetTypeDataAccess.GetAllAssetTypes();

                // 🔹 Bind ComboBox
                nacb_AssetType.DataSource = assetTypes;
                nacb_AssetType.DisplayMember = "AssetTypeName";  // What user sees
                nacb_AssetType.ValueMember = "AssetTypeId";      // Actual ID
                nacb_AssetType.SelectedIndex = -1;              // No selection initially
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Asset Types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                // ✅ Calling method using the instance of UserDataAccess
                List<User> users = _userDataAccess.GetAllUsers();

                // 🔹 Bind ComboBox
                nacb_Users.DataSource = users;
                nacb_Users.DisplayMember = "UserName";   // What user sees
                nacb_Users.ValueMember = "UserId";       // Actual ID
                nacb_Users.SelectedIndex = -1;           // No selection initially
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nabtn_SaveAsset_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Step 1: Retrieve values from controls
                long assetId = long.TryParse(lbl_AssetId.Text, out long id) ? id : 0;
                long assetTypeId = nacb_AssetType.SelectedValue != null ? Convert.ToInt64(nacb_AssetType.SelectedValue) : 0;
                long userId = nacb_Users.SelectedValue != null ? Convert.ToInt64(nacb_Users.SelectedValue) : 0;
                string assetName = natb_AssetName.Text.Trim();
                string assetDescription = natb_AssetDesciption.Text.Trim();
                decimal assetUnits = decimal.TryParse(natb_AssetUnits.Text, out decimal units) ? units : 0m;
                bool isZakatApplicable = nacb_IsZakatApplicable.Checked;
                decimal assetBoughtPrice = decimal.TryParse(natb_AssetBoughtPrice.Text, out decimal price) ? price : 0;
                bool isAssetActive = nacb_AssetIsActive.Checked;
                DateTime assetBoughtDate = nadtp_AssetBoughtDate.Value;
                DateTime assetZakatApplicableFromDate = nadtp_ZakatApplicableFromDate.Value;

                // 🔹 Step 2: Validate required fields
                if (userId == 0 || string.IsNullOrEmpty(assetName) || assetUnits < 0 || assetBoughtPrice < 0)
                {
                    MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Step 3: Create Asset object
                Asset asset = new Asset
                {
                    AssetId = assetId,
                    AssetTypeId = assetTypeId,
                    UserId = userId,
                    AssetName = assetName,
                    AssetDesc = assetDescription,
                    AssetUnits = assetUnits,
                    IsAssetZakatApplicable = isZakatApplicable,
                    AssetBoughtDate = assetBoughtDate,
                    AssetBoughtPrice = assetBoughtPrice,
                    IsAssetActive = isAssetActive,
                    AssetTimeStamp = DateTime.Now,
                    ZakatApplicableFromDate = assetZakatApplicableFromDate
                };

                bool success;
                Asset oldAsset = new Asset();
                _assetDataAccess = new AssetDataAccess();
                oldAsset = _assetDataAccess.GetAssetById(assetId);

                // 🔹 Step 4: Check if it's an Update or Insert operation
                if (assetId > 0)
                {
                    success = _assetDataAccess.UpdateAsset(asset); // Update existing asset
                }
                else
                {
                    success = _assetDataAccess.InsertAsset(asset); // Insert new asset
                }

                // 🔹 Step 5: Log the change in Asset History
                if (success)
                {
                    _assetHistoryDataAccess = new AssetHistoryDataAccess();
                    bool logSuccess = _assetHistoryDataAccess.LogInsertOrUpdateAssetHistory(asset, oldAsset);
                    if (!logSuccess)
                    {
                        MessageBox.Show("Warning: Asset history logging failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // 🔹 Step 6: Show success message
                    MessageBox.Show(assetId > 0 ? "Asset updated successfully!" : "Asset saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Clear form after successful operation

                    // Log event
                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = assetId > 0 ? "Update" : "Insert",
                        EventMessage = assetId > 0 ? "Asset updated successfully." : "Asset inserted successfully.",
                        EventSource = "New_Asset",
                        UserName = "System"
                    });
                }
                else
                {
                    MessageBox.Show("Failed to save asset. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving asset: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            nacb_AssetType.SelectedIndex = -1;
            nacb_Users.SelectedIndex = -1;
            natb_AssetName.Clear();
            natb_AssetDesciption.Clear();
            natb_AssetUnits.Clear();
            nacb_IsZakatApplicable.Checked = false;
            natb_AssetBoughtPrice.Clear();
            nacb_AssetIsActive.Checked = true;
            nadtp_AssetBoughtDate.Value = DateTime.Now;
            nadtp_ZakatApplicableFromDate.Value = DateTime.Now;
        }

        private void FormLoad()
        {
            natb_AssetUnits.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
            natb_AssetBoughtPrice.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
        }
    }
}
