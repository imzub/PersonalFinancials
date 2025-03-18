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
    public partial class AddZakatPaidForm : Form
    {
        ZakatPaidDataAccess _zakatPaidDataAccess;
        AssetDataAccess _assetDataAccess;
        private ZakatPaid _zakatPaidObj = null;
        public AddZakatPaidForm()
        {
            InitializeComponent();
            LoadAssetsIntoComboBox();
        }

        public AddZakatPaidForm(ZakatPaid zakatPaidObj)
        {
            InitializeComponent();
            _zakatPaidObj = zakatPaidObj;

            LoadAssetsIntoComboBox();
            LoadZakatPaidData(); // Load data into fields

        }

        private void zpbtn_SaveZakatPaid_Click(object sender, EventArgs e)
        {
            try
            {
                long zakatPaidId = long.TryParse(zptb_ZakatPaidId.Text, out long id) ? id : 0;
                long assetId = (zpcb_AssetId.SelectedValue != null) ? Convert.ToInt64(zpcb_AssetId.SelectedValue) : 0;
                string zakatPaidTo = zptb_ZakatPaidTo.Text.Trim();
                decimal zakatPaidAmount = decimal.TryParse(zptb_ZakatPaidAmount.Text, out decimal amount) ? amount : 0m;
                DateTime zakatPaidDate = zpdtp_ZakatPaidDate.Value;
                bool isZakatDueUpdated = zpcb_IsZakatDueUpdated.Checked;

                if (assetId == 0 || zakatPaidAmount <= 0)
                {
                    MessageBox.Show("Please select a valid asset and enter a valid zakat amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ZakatPaid zakatPaid = new ZakatPaid
                {
                    ZakatPaidId = zakatPaidId,
                    AssetId = assetId,
                    ZakatPaidTo = zakatPaidTo,
                    ZakatPaidAmount = zakatPaidAmount,
                    ZakatPaidDate = zakatPaidDate,
                    IsZakatDueUpdated = isZakatDueUpdated
                };

                ZakatPaidDataAccess dataAccess = new ZakatPaidDataAccess();
                bool success = dataAccess.InsertOrUpdateZakatPaid(zakatPaid);

                if (success)
                {
                    MessageBox.Show(zakatPaidId > 0 ? "Zakat Paid updated successfully!" : "Zakat Paid saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close form after saving
                }
                else
                {
                    MessageBox.Show("Failed to save zakat paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving zakat paid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadZakatPaidData()
        {
            if (_zakatPaidObj != null)
            {
                zptb_ZakatPaidId.Text = _zakatPaidObj.ZakatPaidId.ToString();
                zpcb_AssetId.SelectedValue = _zakatPaidObj.AssetId; // Set AssetId in ComboBox
                zptb_ZakatPaidTo.Text = _zakatPaidObj.ZakatPaidTo;
                zptb_ZakatPaidAmount.Text = _zakatPaidObj.ZakatPaidAmount.ToString();
                zpdtp_ZakatPaidDate.Value = _zakatPaidObj.ZakatPaidDate;
                zpcb_IsZakatDueUpdated.Checked = _zakatPaidObj.IsZakatDueUpdated;
            }
        }

        private void LoadAssetsIntoComboBox()
        {
            try
            {
                _assetDataAccess = new AssetDataAccess();
                List<Asset> assets = _assetDataAccess.GetAllAssetNameId();

                // Bind asset list to ComboBox
                zpcb_AssetId.DataSource = assets;
                zpcb_AssetId.DisplayMember = "AssetName"; // Show Asset Name
                zpcb_AssetId.ValueMember = "AssetId";     // Store Asset ID
                zpcb_AssetId.SelectedIndex = -1;          // Default to no selection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
