using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using PF_Desktop.Assets;
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
    public partial class ViewAssetZakat : Form
    {
        public ViewAssetZakat()
        {
            InitializeComponent();
            LoadAssetZakatData();
        }

        private void LoadAssetZakatData()
        {
            try
            {
                // Initialize Data Access
                AssetZakatFinYearDataAccess dataAccess = new AssetZakatFinYearDataAccess();

                // Fetch all asset zakat records
                List<AssetZakatFinYear> assetZakatFinYears = dataAccess.GetAllAssetZakatFinYears();

                // Bind to DataGridView
                vazdgv_ViewAssetZakat.DataSource = assetZakatFinYears;
                vazdgv_ViewAssetZakat.Columns["AssetZakatFinYearId"].Visible = true; // Show/Hide ID column
                vazdgv_ViewAssetZakat.Columns["AssetId"].HeaderText = "Asset ID";
                vazdgv_ViewAssetZakat.Columns["AssetName"].HeaderText = "Asset Name";
                vazdgv_ViewAssetZakat.Columns["AssetZakatFinYearStartDate"].HeaderText = "Start Date";
                vazdgv_ViewAssetZakat.Columns["AssetZakatFinYearEndDate"].HeaderText = "End Date";
                vazdgv_ViewAssetZakat.Columns["IsAssetZakatFinYearActive"].HeaderText = "Active";
                vazdgv_ViewAssetZakat.Columns["Asset"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Asset Zakat Financial Years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazdgv_ViewAssetZakat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long assetZakatFinYearId = Convert.ToInt64(vazdgv_ViewAssetZakat.Rows[e.RowIndex].Cells["AssetZakatFinYearId"].Value);
                AssetZakat assetZakatForm = new AssetZakat(assetZakatFinYearId);
                assetZakatForm.ShowDialog();  // Open as modal form
                LoadAssetZakatData(); // Reload assets after closing the edit form
            }
        }
    }
}
