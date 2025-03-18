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
using PF_Desktop.ClassLib;

namespace PF_Desktop.Assets
{
    public partial class AssetTypeForm : Form
    {
        private AssetTypeDataAccess _assetTypeDataAccess;

        public AssetTypeForm()
        {
            InitializeComponent();
            FormLoad();
        }

        public AssetTypeForm(long assetTypeId)
        {
            InitializeComponent();
            LoadAssetType(assetTypeId);
        }

        private void LoadAssetType(long assetTypeId)
        {
            AssetType assetType = new AssetType();
            _assetTypeDataAccess = new AssetTypeDataAccess();
            assetType = _assetTypeDataAccess.GetAssetTypeById(assetTypeId);
            assettypetb_AssetTypeId.Text = assetType.AssetTypeId.ToString();
            assettypetb_AssetTypeName.Text = assetType.AssetTypeName.ToString();
            assettypetb_AssetTypeDescription.Text = assetType.AssetTypeDesc.ToString();
            assettypetb_AssetTypeValueUnit.Text = assetType.AssetTypeCurrentValuePerUnit.ToString();
        }

        private void assettypebtn_AssetTypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Step 1: Validate Input
                if (string.IsNullOrWhiteSpace(assettypetb_AssetTypeName.Text) ||
                    string.IsNullOrWhiteSpace(assettypetb_AssetTypeValueUnit.Text))
                {
                    MessageBox.Show("Please enter all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(assettypetb_AssetTypeValueUnit.Text.Trim(), out decimal assetValuePerUnit))
                {
                    MessageBox.Show("Please enter a valid numeric value for Asset Value per Unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Step 2: Create AssetType Object
                AssetType assetType = new AssetType
                {
                    AssetTypeName = assettypetb_AssetTypeName.Text.Trim(),
                    AssetTypeDesc = assettypetb_AssetTypeDescription.Text.Trim(),
                    AssetTypeCurrentValuePerUnit = assetValuePerUnit
                };

                bool operationSuccess = false;
                _assetTypeDataAccess = new AssetTypeDataAccess();
                // 🔹 Step 3: Check if it's an Insert or Update
                if (!string.IsNullOrWhiteSpace(assettypetb_AssetTypeId.Text) && long.TryParse(assettypetb_AssetTypeId.Text, out long assetTypeId) && assetTypeId > 0)
                {
                    // Update existing AssetType
                    assetType.AssetTypeId = assetTypeId;
                    operationSuccess = _assetTypeDataAccess.UpdateAssetType(assetType);
                }
                else
                {
                    // Insert new AssetType
                    operationSuccess = _assetTypeDataAccess.AddAssetType(assetType);
                }

                // 🔹 Step 4: Show Success or Error Messages
                if (operationSuccess)
                {
                    MessageBox.Show("Asset Type saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // Clear form fields after saving
                }
                else
                {
                    MessageBox.Show("Failed to save Asset Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            assettypetb_AssetTypeName.Clear();
            assettypetb_AssetTypeDescription.Clear();
            assettypetb_AssetTypeValueUnit.Clear();
        }

        private void FormLoad()
        {
            assettypetb_AssetTypeValueUnit.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
        }

        #region Events
        private void assettypetb_AssetTypeValueUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Allow control keys (Backspace, Delete, Left, Right Arrows)
            //if (char.IsControl(e.KeyChar))
            //    return;

            //// Allow digits (0-9)
            //if (char.IsDigit(e.KeyChar))
            //    return;

            //// Allow only one decimal point (.)
            //if (e.KeyChar == '.' && !assettypetb_AssetTypeValueUnit.Text.Contains("."))
            //    return;

            //// Block all other characters
            //e.Handled = true;

            // assettypetb_AssetTypeValueUnit.KeyPress += AssetControlsEvents.DecimalTextBox_KeyPress;
        }
        #endregion       
    }
}
