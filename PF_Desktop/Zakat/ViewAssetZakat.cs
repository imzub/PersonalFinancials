using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private BindingSource bindingSource = new BindingSource();
        private List<AssetZakatFinYear> allAssetsList = new List<AssetZakatFinYear>(); // Store original data

        private void LoadAssetZakatData()
        {
            try
            {
                // Fetch all asset zakat records
                AssetZakatFinYearDataAccess dataAccess = new AssetZakatFinYearDataAccess();
                allAssetsList = dataAccess.GetAllAssetZakatFinYears(); // Store full data list

                // Bind to DataGridView using BindingSource
                bindingSource.DataSource = new List<AssetZakatFinYear>(allAssetsList);
                vazdgv_ViewAssetZakat.DataSource = bindingSource;

                // Configure columns
                vazdgv_ViewAssetZakat.Columns["AssetZakatFinYearId"].Visible = false;
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

        private void aztb_SearchAssetZakat_TextChanged(object sender, EventArgs e)
        {
            string searchText = aztb_SearchAssetZakat.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // Restore full data when search is cleared
                bindingSource.DataSource = new List<AssetZakatFinYear>(allAssetsList);
            }
            else
            {
                // Search dynamically in all relevant fields
                bindingSource.DataSource = allAssetsList.FindAll(asset =>
                    asset.AssetName.ToLower().Contains(searchText) ||
                    asset.AssetId.ToString().Contains(searchText) ||
                    asset.AssetZakatFinYearStartDate.ToString("yyyy-MM-dd").Contains(searchText) ||
                    asset.AssetZakatFinYearEndDate.ToString("yyyy-MM-dd").Contains(searchText) ||
                    (asset.IsAssetZakatFinYearActive ? "active" : "inactive").Contains(searchText)
                );
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

        public static void ExportDataGridViewToPDF(DataGridView dgv, string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (PdfWriter writer = new PdfWriter(stream, new WriterProperties().SetCompressionLevel(CompressionConstants.NO_COMPRESSION)))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    // Create table with column count matching DataGridView
                    Table table = new Table(dgv.ColumnCount).UseAllAvailableWidth();

                    // Add column headers
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)
    .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD))));

                    }

                    // Add row data
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow) // Skip empty row
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string cellValue = cell.Value?.ToString() ?? "";
                                table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                            }
                        }
                    }

                    document.Add(table);
                }

                MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void PrintAssetZakatReport(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = "AssetZakatReport.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportDataGridViewToPDF(dgv, sfd.FileName);
                }
            }
        }

        private void azbtn_Print_Click(object sender, EventArgs e)
        {
            PrintAssetZakatReport(vazdgv_ViewAssetZakat);
        }       
    }
}
