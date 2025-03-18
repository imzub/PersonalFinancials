using PersonalFinancials.DataAccess;
using System;
using System.Windows.Forms;

namespace PF_Desktop.Assets
{
    public partial class ViewAssets : Form
    {
        AssetDataAccess _assetDataAccess;
        public ViewAssets()
        {
            InitializeComponent();
            LoadAssets();
        }

        private void LoadAssets()
        {
            _assetDataAccess = new AssetDataAccess();
            dataGridViewAssets.DataSource = _assetDataAccess.GetAllAssets();
        }

        private void dataGridViewAssets_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long assetId = Convert.ToInt64(dataGridViewAssets.Rows[e.RowIndex].Cells["ID"].Value);
                New_Asset editForm = new New_Asset(assetId);
                editForm.ShowDialog();
                LoadAssets();
            }
        }
    }
}
