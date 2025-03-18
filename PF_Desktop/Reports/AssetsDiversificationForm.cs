using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PersonalFinancials.DataAccess;

namespace PF_Desktop.Reports
{
    public partial class AssetsDiversificationForm : Form
    {
        AssetDataAccess _assetDataAccess;
        public AssetsDiversificationForm()
        {
            InitializeComponent();
            LoadAssetChart();
        }

        private void LoadAssetChart()
        {
            try
            {
                DataTable dt = GetAssetData(); // 🔹 Fetch asset data from DB
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No asset data available!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                chartAssets.Series.Clear();
                Series series = new Series("Assets");
                series.ChartType = SeriesChartType.Pie; // 🔹 Pie Chart
                series.IsValueShownAsLabel = true; // 🔹 Show values on chart
                chartAssets.Series.Add(series);

                decimal totalValue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalValue += Convert.ToDecimal(row["TotalValue"]);
                }

                foreach (DataRow row in dt.Rows)
                {
                    string assetName = row["AssetCategory"].ToString();
                    decimal assetValue = Convert.ToDecimal(row["TotalValue"]);
                    decimal percentage = (assetValue / totalValue) * 100;

                    // 🔹 Add data to chart
                    series.Points.AddXY(assetName, percentage);
                    series.Points[series.Points.Count - 1].Label = $"{assetName}: {percentage:F2}%"; // Label Format
                }

                chartAssets.Titles.Clear();
                chartAssets.Titles.Add("Assets Distribution in Percentage");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetAssetData()
        {
            _assetDataAccess = new AssetDataAccess();

            // Fetch data from stored procedure
            DataTable dts = _assetDataAccess.GetAssetCategorySum();

            // Create a new DataTable with required columns
            DataTable dt = new DataTable();
            dt.Columns.Add("AssetCategory", typeof(string));
            dt.Columns.Add("TotalValue", typeof(decimal));

            // Check if fetched data is not null and has rows
            if (dts != null && dts.Rows.Count > 0)
            {
                foreach (DataRow row in dts.Rows)
                {
                    dt.Rows.Add(row["AssetCategory"], row["TotalValue"]);
                }
            }

            return dt;
        }


        //private DataTable GetAssetData()
        //{
        //    try
        //    {
        //        _assetDataAccess = new AssetDataAccess(); // Initialize Data Access

        //        // Fetch asset category sums using stored procedure
        //        DataTable dt = _assetDataAccess.GetAssetCategorySum();

        //        // Validate if data is fetched
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("No asset data available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return new DataTable(); // Return empty DataTable if no data
        //        }

        //        return dt; // Return the fetched data
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error fetching asset data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new DataTable(); // Return empty DataTable in case of error
        //    }
        //}
    }
}
