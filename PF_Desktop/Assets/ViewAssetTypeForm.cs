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

namespace PF_Desktop.Assets
{
    public partial class ViewAssetTypeForm : Form
    {
        private readonly AssetTypeDataAccess _assetTypeDataAccess = new AssetTypeDataAccess();

        public ViewAssetTypeForm()
        {
            InitializeComponent();
            LoadAssetTypes(); // Load asset types when form opens
        }

        // 🔹 Format DataGridView to look better
        private void FormatDataGridView()
        {
            vatfdgv_ViewAssetType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vatfdgv_ViewAssetType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vatfdgv_ViewAssetType.MultiSelect = false;
            vatfdgv_ViewAssetType.ReadOnly = true;
            vatfdgv_ViewAssetType.AllowUserToAddRows = false;
            vatfdgv_ViewAssetType.AllowUserToDeleteRows = false;

            vatfdgv_ViewAssetType.Columns["assetTypeId"].HeaderText = "ID";
            vatfdgv_ViewAssetType.Columns["assetTypeName"].HeaderText = "Name";
            vatfdgv_ViewAssetType.Columns["assetTypeDesc"].HeaderText = "Description";
            vatfdgv_ViewAssetType.Columns["assetTypeCurrentValuePerUnit"].HeaderText = "Value Per Unit";
        }

        // 🔹 Load Asset Types into DataGridView
        private void LoadAssetTypes()
        {
            try
            {
                List<AssetType> assetTypes = _assetTypeDataAccess.GetAllAssetTypes();
                DataTable assetTypesTable = ConvertToDataTable(assetTypes);

                vatfdgv_ViewAssetType.DataSource = assetTypesTable;
                //FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading asset types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Convert List<AssetType> to DataTable
        private DataTable ConvertToDataTable(List<AssetType> assetTypes)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(long));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Value Per Unit", typeof(decimal));

            foreach (var asset in assetTypes)
            {
                table.Rows.Add(asset.AssetTypeId, asset.AssetTypeName, asset.AssetTypeDesc, asset.AssetTypeCurrentValuePerUnit);
            }

            return table;
        }

        private void vatfdgv_ViewAssetType_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long assetTypeId = Convert.ToInt64(vatfdgv_ViewAssetType.Rows[e.RowIndex].Cells["ID"].Value);

                // 🔹 Use 'using' to ensure proper disposal after closing the form
                using (AssetTypeForm assetTypeForm = new AssetTypeForm(assetTypeId))
                {
                    assetTypeForm.ShowDialog();
                }

                // Optionally, refresh the DataGridView after closing the form
                LoadAssetTypes();
            }
        }
    }
}
