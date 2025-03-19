using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PF_ClassLibrary.Model;
using PF_ClassLibrary.Services;
using PF_Desktop.Assets;
using PF_Desktop.Common;
using PF_Desktop.Reports;
using PF_Desktop.Zakat;
using PersonalFinancials.DataAccess;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PF_Desktop
{
    public partial class PFHome : Form
    {
        public static PFHome Instance { get; private set; }

        Calculations _calculations;
        EventLogDataAccess eventLogDataAccess = new EventLogDataAccess();
        ExceptionLogDataAccess exceptionLogDataAccess = new ExceptionLogDataAccess();

        public PFHome()
        {
            InitializeComponent();
            Instance = this; // Store reference to the instance
            InitializeDateTimeTimer();
            LoadHome();
        }

        private void btnViewAssets_Click(object sender, EventArgs e)
        {
            var viewAssetForm = new ViewAssets();
            viewAssetForm.ShowDialog();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            var addAssetForm = new New_Asset();
            addAssetForm.ShowDialog();
        }

        private void btnAddAssetZakat_Click(object sender, EventArgs e)
        {
            var addAssetZakat = new AssetZakat();
            addAssetZakat.ShowDialog();
        }

        private void viewAssetZakat_Click(object sender, EventArgs e)
        {
            var viewAssetZakat = new ViewAssetZakat();
            viewAssetZakat.ShowDialog();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            var viewTasks = new ApplicationTasks();
            viewTasks.ShowDialog();
        }

        private void home_statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private Timer dateTimeTimer;

        private void InitializeDateTimeTimer()
        {
            dateTimeTimer = new Timer();
            dateTimeTimer.Interval = 1000; // 1 second
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            home_statusStrip_lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt");
        }

        private void LoadHome()
        {
            try
            {
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.Size = new Size(workingArea.Width, workingArea.Height);
                this.Location = new Point(workingArea.Left, workingArea.Top);

                //Load ZakatSummery
                LoadZakatSummery();

                eventLogDataAccess.LogEvent(new EventLogModel
                {
                    EventType = "Load",
                    EventMessage = "Home loaded successfully.",
                    EventSource = "PFHome",
                    UserName = "System"
                });
            }
            catch (Exception ex)
            {
                exceptionLogDataAccess.LogException(ex);
                MessageBox.Show("An error occurred while loading the home screen. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void LoadZakatSummery()
        {
            ZakatSummary zakatSummary = new ZakatSummary();
            _calculations = new Calculations();
            zakatSummary = _calculations.GetZakatSummary();
            tssl_totalDueZakat.Text = "| Outstanding Zakat: " + Convert.ToString(zakatSummary.TotalActiveDueZakat);
            tssl_totalAdvZakatBal.Text = "| Adv Zakat Balance: " + Convert.ToString(zakatSummary.BalanceZakat);
            tssl_deficitZakat.Text = "| Zakat Deficit: " + Convert.ToString(zakatSummary.BalanceZakat - zakatSummary.TotalActiveDueZakat);
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void btnAddAssetType_Click(object sender, EventArgs e)
        {
            AssetTypeForm assetTypeForm = new AssetTypeForm();
            assetTypeForm.ShowDialog();
        }

        private void btnViewAssetType_Click(object sender, EventArgs e)
        {
            ViewAssetTypeForm assetTypeForm = new ViewAssetTypeForm();
            assetTypeForm.ShowDialog();
        }

        private void btnViewZakatPaid_Click(object sender, EventArgs e)
        {
            ViewZakatPaidForm viewZakatPaidForm = new ViewZakatPaidForm();
            viewZakatPaidForm.ShowDialog();
        }

        private void btnAddUpdateZakatPaid_Click(object sender, EventArgs e)
        {
            AddZakatPaidForm addZakatPaid = new AddZakatPaidForm();
            addZakatPaid.ShowDialog();
        }

        private void btn_ViewZakatDue_Click(object sender, EventArgs e)
        {
            ViewZakatDueForm viewZakatDueForm = new ViewZakatDueForm();
            viewZakatDueForm.ShowDialog();
        }

        private void btn_AddZakatDue_Click(object sender, EventArgs e)
        {
            AddZakatDueForm addZakatDueForm = new AddZakatDueForm();
            addZakatDueForm.ShowDialog();
        }

        private void btnTransferZakat_Click(object sender, EventArgs e)
        {
            ZakatTransfer zakatTransfer = new ZakatTransfer();
            zakatTransfer.ShowDialog();
        }

        private void btnViewAdvanceZakat_Click(object sender, EventArgs e)
        {
            ViewAdvanceZakatPaidForm viewAdvanceZakatPaidForm = new ViewAdvanceZakatPaidForm();
            viewAdvanceZakatPaidForm.ShowDialog();
        }

        private void btnAddAdvanceZakat_Click(object sender, EventArgs e)
        {
            PayAdvanceZakat advanceZakat = new PayAdvanceZakat();
            advanceZakat.ShowDialog();
        }

        private void btn_AssetDueZakatSetoff_Click(object sender, EventArgs e)
        {
            AssetDueZakatSetoff assetDueZakatSetoff = new AssetDueZakatSetoff();
            assetDueZakatSetoff.ShowDialog();
        }

        private void btn_ExportImport_Click(object sender, EventArgs e)
        {
            SettingExportImportForm settingExportImportForm = new SettingExportImportForm();
            settingExportImportForm.ShowDialog();
        }

        private void btn_assetDiversifyReport_Click(object sender, EventArgs e)
        {
            AssetsDiversificationForm assetsDiversificationForm = new AssetsDiversificationForm();
            assetsDiversificationForm.ShowDialog();
        }
    }
}
