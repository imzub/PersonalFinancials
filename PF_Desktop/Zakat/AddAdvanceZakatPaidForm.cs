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

namespace PF_Desktop.Zakat
{
    public partial class AddAdvanceZakatPaidForm : Form
    {
        public AddAdvanceZakatPaidForm()
        {
            InitializeComponent();
            LoadAssetsIntoComboBox();
        }
        public AddAdvanceZakatPaidForm(long advanceZakatId)
        {
            InitializeComponent();
            LoadAssetsIntoComboBox(); // Load asset list into combobox

            if (advanceZakatId > 0) // Editing an existing record
            {
                LoadAdvanceZakatData(advanceZakatId);
            }
        }

        private void LoadAssetsIntoComboBox()
        {
            AssetDataAccess assetDataAccess = new AssetDataAccess();
            List<Asset> assets = assetDataAccess.GetAllAssetNameId();

            // Add "No Asset" option at the top
            assets.Insert(0, new Asset { AssetId = 0, AssetName = "No Asset" });

            adzpf_Asset.DataSource = assets;
            adzpf_Asset.DisplayMember = "AssetName";
            adzpf_Asset.ValueMember = "AssetId";
        }

        private void adzpf_btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Retrieve values from controls
                long advanceZakatId = long.TryParse(adzpf_AdvZakatId.Text, out long id) ? id : 0;
                decimal advZakatIn = decimal.TryParse(adzpf_AdvZakatIn.Text, out decimal zakatIn) ? zakatIn : 0m;
                decimal advZakatOut = decimal.TryParse(adzpf_AdvZakatOut.Text, out decimal zakatOut) ? zakatOut : 0m;
                decimal advZakatBalance = decimal.TryParse(adzpf_AdvZakatBalance.Text, out decimal balance) ? balance : 0m;
                long assetId = adzpf_Asset.SelectedValue != null ? Convert.ToInt64(adzpf_Asset.SelectedValue) : 0;
                string advZakatPaidTo = adzpf_AdvZakatPaidTo.Text.Trim();
                string comments = adzpf_AdvZakatComments.Text.Trim();
                DateTime advZakatPaidDate = adzpf_AdvZakatPaidDate.Value;
                bool isAdvZakatPaid = adzpf_IsAdvZakatPaid.Checked;
                bool isActive = adzpf_IsActive.Checked;

                // Step 2: Validate required fields
                if (advZakatIn < 0 || advZakatOut < 0 || advZakatBalance < 0 || string.IsNullOrEmpty(advZakatPaidTo))
                {
                    MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Step 3: Create AdvanceZakat object
                AdvanceZakat advanceZakat = new AdvanceZakat
                {
                    AdvZakatId = advanceZakatId,
                    AdvZakatIn = advZakatIn,
                    AdvZakatOut = advZakatOut,
                    AdvZakatBalance = advZakatBalance,
                    AssetId = assetId,
                    AdvZakatPaidTo = advZakatPaidTo,
                    AdvZakatPaidDate = advZakatPaidDate,
                    IsAdvZakatPaid = isAdvZakatPaid,
                    IsActive = isActive,
                    Comments = comments,
                    Timestamp = DateTime.Now // Automatically set timestamp
                };

                bool success;

                // Step 4: Check if it's an Update or Insert operation
                AdvanceZakatDataAccess dataAccess = new AdvanceZakatDataAccess();
                if (advanceZakatId > 0)
                {
                    success = dataAccess.UpdateAdvanceZakat(advanceZakat); // Update existing record
                }
                else
                {
                    success = dataAccess.InsertAdvanceZakat(advanceZakat); // Insert new record
                }

                // Step 5: Show result message
                if (success)
                {
                    MessageBox.Show(advanceZakatId > 0 ? "Advance Zakat updated successfully!" : "Advance Zakat saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadAdvanceZakatData(long advanceZakatId)
        {
            AdvanceZakatDataAccess dataAccess = new AdvanceZakatDataAccess();
            AdvanceZakat advanceZakat = dataAccess.GetAdvanceZakatById(advanceZakatId);

            if (advanceZakat != null)
            {
                adzpf_AdvZakatId.Text = advanceZakat.AdvZakatId.ToString();
                adzpf_AdvZakatIn.Text = advanceZakat.AdvZakatIn.ToString();
                adzpf_AdvZakatOut.Text = advanceZakat.AdvZakatOut.ToString();
                adzpf_AdvZakatBalance.Text = advanceZakat.AdvZakatBalance.ToString();
                adzpf_AdvZakatPaidTo.Text = advanceZakat.AdvZakatPaidTo;
                adzpf_AdvZakatComments.Text = advanceZakat.Comments;

                adzpf_AdvZakatPaidDate.Value = advanceZakat.AdvZakatPaidDate;
                adzpf_IsAdvZakatPaid.Checked = advanceZakat.IsAdvZakatPaid;
                adzpf_IsActive.Checked = advanceZakat.IsActive;

                // Set selected asset in combobox
                if (advanceZakat.AssetId.HasValue)
                {
                    adzpf_Asset.SelectedValue = advanceZakat.AssetId.Value;
                }
            }
        }
    }
}
