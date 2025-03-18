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
    public partial class ViewAdvanceZakatPaidForm : Form
    {
        private AdvanceZakatDataAccess _advanceZakatDataAccess = new AdvanceZakatDataAccess();
        public ViewAdvanceZakatPaidForm()
        {
            InitializeComponent();
            LoadAdvanceZakatData();
        }

        private void LoadAdvanceZakatData()
        {
            try
            {
                List<AdvanceZakat> zakatList = _advanceZakatDataAccess.GetAllAdvanceZakat();
                vazpf_dgvAdvZakatPaid.DataSource = zakatList;

                // Optional: Adjust column headers for better readability
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatId"].HeaderText = "Zakat ID";
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatIn"].HeaderText = "Zakat In";
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatOut"].HeaderText = "Zakat Out";
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatBalance"].HeaderText = "Balance";
                vazpf_dgvAdvZakatPaid.Columns["AssetId"].HeaderText = "Asset ID";
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatPaidTo"].HeaderText = "Paid To";
                vazpf_dgvAdvZakatPaid.Columns["AdvZakatPaidDate"].HeaderText = "Paid Date";
                vazpf_dgvAdvZakatPaid.Columns["IsAdvZakatPaid"].HeaderText = "Zakat Paid?";
                vazpf_dgvAdvZakatPaid.Columns["IsActive"].HeaderText = "Active?";
                vazpf_dgvAdvZakatPaid.Columns["Comments"].HeaderText = "Comments";
                vazpf_dgvAdvZakatPaid.Columns["Timestamp"].HeaderText = "Timestamp";
                vazpf_dgvAdvZakatPaid.Columns["ZakatDueId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Advance Zakat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazpf_dgvAdvZakatPaid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure row is valid
            {
                // Extract advanceZakatId from the selected row
                long advanceZakatId = Convert.ToInt64(vazpf_dgvAdvZakatPaid.Rows[e.RowIndex].Cells["AdvZakatId"].Value);

                // Pass advanceZakatId to the constructor
                AddAdvanceZakatPaidForm addAdvanceZakatPaidForm = new AddAdvanceZakatPaidForm(advanceZakatId);
                addAdvanceZakatPaidForm.ShowDialog(); // Open form

                LoadAdvanceZakatData(); // Refresh DataGridView after edit
            }
        }
    }
}
