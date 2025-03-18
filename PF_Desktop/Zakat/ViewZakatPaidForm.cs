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
    public partial class ViewZakatPaidForm : Form
    {
        private ZakatPaidDataAccess _zakatPaidDataAccess;

        public ViewZakatPaidForm()
        {
            InitializeComponent();            
            LoadZakatPaidData();
        }

        private void LoadZakatPaidData()
        {
            try
            {
                _zakatPaidDataAccess = new ZakatPaidDataAccess();
                DataTable dt = _zakatPaidDataAccess.GetAllZakatPaidRecords();
                vzpfdgv_ViewZakatPaid.DataSource = dt;

                // Format DataGridView Columns (Optional)
                vzpfdgv_ViewZakatPaid.Columns["zakatPaidId"].HeaderText = "Zakat Paid ID";
                vzpfdgv_ViewZakatPaid.Columns["assetId"].HeaderText = "Asset ID";
                vzpfdgv_ViewZakatPaid.Columns["assetName"].HeaderText = "Asset Name";
                vzpfdgv_ViewZakatPaid.Columns["zakatPaidTo"].HeaderText = "Paid To";
                vzpfdgv_ViewZakatPaid.Columns["zakatPaidAmount"].HeaderText = "Amount";
                vzpfdgv_ViewZakatPaid.Columns["zakatPaidDate"].HeaderText = "Date";
                vzpfdgv_ViewZakatPaid.Columns["isZakatDueUpdated"].HeaderText = "Zakat Due Updated";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Zakat Paid records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vzpfdgv_ViewZakatPaid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 🔹 Ensure row index is valid
                if (e.RowIndex >= 0)
                {
                    // Get selected ZakatPaidId
                    long zakatPaidId = Convert.ToInt64(vzpfdgv_ViewZakatPaid.Rows[e.RowIndex].Cells["zakatPaidId"].Value);

                    // Fetch full record from database
                    ZakatPaidDataAccess dataAccess = new ZakatPaidDataAccess();
                    ZakatPaid zakatPaidObj = dataAccess.GetZakatPaidById(zakatPaidId);

                    if (zakatPaidObj != null)
                    {
                        // Open AddZakatPaidForm in edit mode
                        AddZakatPaidForm editForm = new AddZakatPaidForm(zakatPaidObj);
                        editForm.ShowDialog(); // Open as modal
                        LoadZakatPaidData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to load Zakat Paid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Zakat Paid for editing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
