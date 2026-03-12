using DevExpress.XtraCharts;
using DXBeauty.Data;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class DashboardControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DashboardRepository _dashboardRepo;

        public DashboardControl()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dashboardRepo = new DashboardRepository(connectionString);
        }

        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            // Verileri yüklerken UI donmasın diye asenkron çağırıyoruz
            await LoadDashboardDataAsync();
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // =========================================================
                // 1. GÜNLÜK KASA ÖZETİ (Label'ları Doldurma)
                // =========================================================
                var summary = await _dashboardRepo.GetDailySummaryAsync();

                lblTotalRevenue.Text = $"{summary.TotalRevenue:N2} ₺";
                lblPaymentDetails.Text = $"Nakit: {summary.CashTotal:N2} ₺ | Kart: {summary.CreditCardTotal:N2} ₺";
                lblExpected.Text = $"{summary.ExpectedInstallments:N2} ₺";
                lblAppCount.Text = $"{summary.TodayAppointmentCount} Kişi";

                // =========================================================
                // 2. LİSTELER (Bugünün Randevuları ve Alarmlar)
                // =========================================================
                gridTodayAppointments.DataSource = await _dashboardRepo.GetTodaysAppointmentsAsync();
                gridAlerts.DataSource = await _dashboardRepo.GetCriticalAlertsAsync();

                // Grid kolonlarını otomatik sığdır
                gridViewTodayAppointments.BestFitColumns();
                gridViewAlerts.BestFitColumns();

                // =========================================================
                // 3. GRAFİKLERİ DOLDURMA (ChartControl)
                // =========================================================
                await LoadRevenueChartAsync();
                await LoadPackagesChartAsync();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dashboard verileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Ciro Grafiği (Bar Chart) ---
        private async Task LoadRevenueChartAsync()
        {
            var revenueData = await _dashboardRepo.GetMonthlyRevenueTrendAsync();

            chartRevenue.Series.Clear(); // Önceki verileri temizle
            Series series = new Series("Günlük Ciro", ViewType.Bar);

            foreach (var item in revenueData)
            {
                // X ekseni Tarih (Örn: 12 Mart), Y ekseni Tutar (Örn: 5000)
                series.Points.Add(new SeriesPoint(item.Date.ToString("dd MMM"), item.DailyTotal));
            }

            chartRevenue.Series.Add(series);
            chartRevenue.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False; // Lejantı gizle, daha şık dursun

            // X eksenindeki yazıların üst üste binmemesi için hafif eğik yazdırabiliriz
            ((XYDiagram)chartRevenue.Diagram).AxisX.Label.Angle = -45;
        }

        // --- En Çok Satan Paketler Grafiği (Pie Chart) ---
        private async Task LoadPackagesChartAsync()
        {
            var packageData = await _dashboardRepo.GetTopSellingPackagesAsync();

            chartPackages.Series.Clear();
            Series series = new Series("Satışlar", ViewType.Pie);

            foreach (var item in packageData)
            {
                // X ekseni Paket Adı (Örn: Lazer), Y ekseni Satış Sayısı (Örn: 25)
                series.Points.Add(new SeriesPoint(item.PackageName, item.SalesCount));
            }

            chartPackages.Series.Add(series);

            // Pastanın üzerinde yüzdeleri göstermek için:
            series.Label.TextPattern = "{A}: {V} ({VP:P0})"; // A: İsim, V: Sayı, VP: Yüzde
            ((PieSeriesLabel)series.Label).Position = PieSeriesLabelPosition.TwoColumns;
        }
    }
}