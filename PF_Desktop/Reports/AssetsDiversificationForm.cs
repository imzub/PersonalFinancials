using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PersonalFinancials.DataAccess;
using System.Drawing;

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
                Series series = new Series("Assets")
                {
                    ChartType = SeriesChartType.Pie, // 🔹 Pie Chart
                    IsValueShownAsLabel = true        // 🔹 Show labels on chart
                };
                chartAssets.Series.Add(series);

                // 🔹 Calculate Total Asset Value
                decimal totalValue = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalValue"));

                // 🔹 Add data points to the chart
                foreach (DataRow row in dt.Rows)
                {
                    string assetName = row["AssetCategory"].ToString();
                    decimal assetValue = Convert.ToDecimal(row["TotalValue"]);
                    decimal percentage = (assetValue / totalValue) * 100;

                    DataPoint point = new DataPoint
                    {
                        YValues = new double[] { (double)assetValue }, // 🔹 Store actual value
                        AxisLabel = assetName, // 🔹 Show asset name on Pie Chart
                        Label = $"{assetName}\n{assetValue:C} ({percentage:F2}%)" // 🔹 Display value & percentage
                    };

                    series.Points.Add(point);
                }

                // 🔹 Update Chart Title
                chartAssets.Titles.Clear();
                chartAssets.Titles.Add("Assets Distribution (Value & Percentage)");

                // 🔹 Add Total Wealth Value as a Side Label
                string todayDate = DateTime.Now.ToString("dd-MMM-yyyy");
                Title totalWealthTitle = new Title($"Total Wealth: {totalValue:C} (As of {todayDate})")
                {
                    Docking = Docking.Bottom, // 🔹 Position the label below the chart
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Green
                };
                chartAssets.Titles.Add(totalWealthTitle);
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
    }
}
