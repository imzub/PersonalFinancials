using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PF_Desktop.Zakat
{
    public partial class ViewZakatDueForm : Form
    {
        ZakatDueDataAccess _zakatDueDataAccess;
        public ViewZakatDueForm()
        {
            InitializeComponent();
            LoadZakatDueData();
        }

        //private void LoadZakatDueData()
        //{
        //    try
        //    {
        //        // 🔹 Initialize data access layer
        //        _zakatDueDataAccess = new ZakatDueDataAccess();

        //        // 🔹 Fetch all zakat due records
        //        List<ZakatDue> zakatDueList = _zakatDueDataAccess.GetAllZakatDues();

        //        // 🔹 Convert List to BindingList (to enable sorting)
        //        BindingList<ZakatDue> bindingList = new BindingList<ZakatDue>(zakatDueList);
        //        BindingSource source = new BindingSource(bindingList, null);

        //        // 🔹 Bind data to DataGridView
        //        zddgv_ZakatDue.DataSource = source;

        //        // 🔹 Enable sorting for all columns
        //        foreach (DataGridViewColumn column in zddgv_ZakatDue.Columns)
        //        {
        //            column.SortMode = DataGridViewColumnSortMode.Automatic;
        //        }

        //        // 🔹 Map and name columns properly
        //        zddgv_ZakatDue.Columns["ZakatDueId"].HeaderText = "Zakat Due ID";
        //        zddgv_ZakatDue.Columns["AssetId"].HeaderText = "Asset ID";
        //        zddgv_ZakatDue.Columns["AssetName"].HeaderText = "Asset Name";
        //        zddgv_ZakatDue.Columns["DueZakat"].HeaderText = "Zakat Amount Due";
        //        zddgv_ZakatDue.Columns["IsZakatDueActive"].HeaderText = "Active Status";

        //        // 🔹 Adjust column width for better visibility
        //        zddgv_ZakatDue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading Zakat Due data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadZakatDueData()
        {
            try
            {
                // 🔹 Initialize data access layer
                _zakatDueDataAccess = new ZakatDueDataAccess();

                // 🔹 Fetch all zakat due records
                List<ZakatDue> zakatDueList = _zakatDueDataAccess.SearchZakatDue();

                // 🔹 Convert List to BindingList (to enable sorting)
                BindingList<ZakatDue> bindingList = new BindingList<ZakatDue>(zakatDueList);
                BindingSource source = new BindingSource(bindingList, null);

                // 🔹 Bind data to DataGridView
                zddgv_ZakatDue.DataSource = source;

                // 🔹 Enable sorting for all columns
                foreach (DataGridViewColumn column in zddgv_ZakatDue.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                //// 🔹 Map and name columns properly
                //zddgv_ZakatDue.Columns["ZakatDueId"].HeaderText = "Zakat Due ID";
                //zddgv_ZakatDue.Columns["AssetId"].HeaderText = "Asset ID";
                //zddgv_ZakatDue.Columns["AssetName"].HeaderText = "Asset Name";
                //zddgv_ZakatDue.Columns["DueZakat"].HeaderText = "Zakat Amount Due";
                //zddgv_ZakatDue.Columns["IsZakatDueActive"].HeaderText = "Active Status";

                // 🔹 Adjust column width for better visibility
                zddgv_ZakatDue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Zakat Due data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zdbtn_Search_Click(object sender, EventArgs e)
        {
            //LoadZakatDueData();
            SearchZakatDue();
        }

        private void SearchZakatDue()
        {
            try
            {
                _zakatDueDataAccess = new ZakatDueDataAccess();

                // 🔹 Get search criteria from UI controls
                string username = zdcb_Username.Text.Trim();
                string assetName = zdcb_Assetname.Text.Trim();

                // 🔹 Get selected value from ComboBox
                bool? isZakatDueActive = null;
                isZakatDueActive = zdcb_IsZakatDueActive.Checked;

                // 🔹 Call DataAccess method to fetch filtered data
                List<ZakatDue> zakatDueList = _zakatDueDataAccess.SearchZakatDue(null, assetName, username, isZakatDueActive);

                // 🔹 Bind the results to the DataGridView
                zddgv_ZakatDue.DataSource = zakatDueList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching zakat due data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
