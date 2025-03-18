using PersonalFinancials.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF_Desktop.Common
{
    public partial class ZakatTransfer : Form
    {
        private ZakatDueDataAccess _zakatDueDataAccess;
        public ZakatTransfer()
        {
            InitializeComponent();
            _zakatDueDataAccess = new ZakatDueDataAccess();
            BindAssetComboBoxes();
        }

        private void ztbtn_Transfer_Click(object sender, EventArgs e)
        {

        }
        // 🔹 Bind Asset ComboBoxes (From & To)
        private void BindAssetComboBoxes()
        {
            List<KeyValuePair<long, string>> assets = _zakatDueDataAccess.GetActiveZakatAssets();

            // 🔹 Insert 'Select' as the first item
            assets.Insert(0, new KeyValuePair<long, string>(0, "Select"));

            // 🔹 Bind Data to ComboBoxes
            ztcb_FromAsset.DataSource = new BindingSource(assets, null);
            ztcb_FromAsset.DisplayMember = "Value";
            ztcb_FromAsset.ValueMember = "Key";

            ztcb_ToAsset.DataSource = new BindingSource(assets, null);
            ztcb_ToAsset.DisplayMember = "Value";
            ztcb_ToAsset.ValueMember = "Key";

            // 🔹 Set Default Selection to 'Select'
            ztcb_FromAsset.SelectedIndex = 0;
            ztcb_ToAsset.SelectedIndex = 0;
        }

        // 🔹 Update Labels when Asset is Selected
        private void ztcb_FromAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ztcb_FromAsset.SelectedItem is KeyValuePair<long, string> selectedAsset)
            {
                long assetId = selectedAsset.Key;

                // Only update if a valid asset is selected (ignore 'Select' entry)
                if (assetId > 0)
                {
                    ztlbl_FromAssetAmount.Text = "Due Zakat: " + _zakatDueDataAccess.GetDueZakatAmount(assetId).ToString("C2");
                }
                else
                {
                    ztlbl_FromAssetAmount.Text = "Due Zakat: -";
                }
            }
        }

        private void ztcb_ToAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ztcb_ToAsset.SelectedItem is KeyValuePair<long, string> selectedAsset)
            {
                long assetId = selectedAsset.Key;

                // Only update if a valid asset is selected (ignore 'Select' entry)
                if (assetId > 0)
                {
                    ztlbl_ToAssetAmount.Text = "Due Zakat: " + _zakatDueDataAccess.GetDueZakatAmount(assetId).ToString("C2");
                }
                else
                {
                    ztlbl_ToAssetAmount.Text = "Due Zakat: -";
                }
            }
        }
    }
}
