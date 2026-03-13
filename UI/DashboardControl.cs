using DevExpress.Charts.Native;
using DevExpress.XtraCharts;
using DXBeauty.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class DashboardControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DashboardRepository _dashboardRepo;
        private HashSet<DateTime> _randevuluGunler = new HashSet<DateTime>();
        public DashboardControl()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dashboardRepo = new DashboardRepository(connectionString);
        }

        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            try
            {
                // ... Kasa Özeti (Label'lar) kodların aynen kalıyor ...

                // LİSTELER (Artık randevuları yüklerken bugünün tarihini yolluyoruz)
                gridTodayAppointments.DataSource = await _dashboardRepo.GetAppointmentsByDateAsync(DateTime.Today);
                gridAlerts.DataSource = await _dashboardRepo.GetCriticalAlertsAsync();


                gridViewAlerts.BestFitColumns();

                // RANDEVULU GÜNLERİ BELLEĞE ALMA (DateNavigator Bold İşlemi İçin)
                var dates = await _dashboardRepo.GetActiveAppointmentDatesAsync();
                _randevuluGunler = new HashSet<DateTime>(dates);

                // Takvimi güncel veriye göre yeniden çizmeye zorla
                dateNavDashboard.Refresh();

                // Verileri yüklerken UI donmasın diye asenkron çağırıyoruz
                await LoadDashboardDataAsync();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dashboard verileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                
                gridAlerts.DataSource = await _dashboardRepo.GetCriticalAlertsAsync();

                // Grid kolonlarını otomatik sığdır

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

            // Y EKSENİ PARA BİRİMİ AYARI
            // {V:N0} -> Sayıyı binlik ayracı ile yazar (Örn: 10.000)
            // Sonuna da " ₺" sembolünü ekliyoruz.
            ((XYDiagram)chartRevenue.Diagram).AxisY.Label.TextPattern = "{V:N0} ₺";

            // 1. Varsa eski başlıkları temizle (Metot tekrar çağrıldığında üst üste binmemesi için)
            chartRevenue.Titles.Clear();

            // 2. Yeni bir başlık nesnesi oluştur
            DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();

            // 3. Başlığın metnini ve (opsiyonel) fontunu belirle
            chartTitle.Text = "Son 30 Günlük Ciro Trendi";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Regular);

            // 4. Başlığı grafiğe ekle
            chartRevenue.Titles.Add(chartTitle);
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

            // 1. Varsa eski başlıkları temizle (Metot tekrar çağrıldığında üst üste binmemesi için)
            //chartRevenue.Titles.Clear();

            // 2. Yeni bir başlık nesnesi oluştur
            DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();

            // 3. Başlığın metnini ve (opsiyonel) fontunu belirle
            chartTitle.Text = "En Çok Satan 5 Paket";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Regular);

            // 4. Başlığı grafiğe ekle
            chartPackages.Titles.Add(chartTitle);

        }

        private async void dateNavigator1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // DateNavigator'da kullanıcının tıkladığı/seçtiği ilk tarihi alıyoruz
                DateTime seciliTarih = dateNavDashboard.DateTime;// İlk seçilen tarih (Eğer birden fazla tarih seçilirse, ilkini alır)

                // O tarihin randevularını veritabanından şimşek hızında çek ve Grid'e bağla!
                var randevular = await _dashboardRepo.GetAppointmentsByDateAsync(seciliTarih);
                gridTodayAppointments.DataSource = randevular;


            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Randevular getirilirken hata oluştu: " + ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void dateNavDashboard_CustomDrawDayNumberCell(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            // Çizilmekte olan gün, belleğe aldığımız randevulu günler listesinde var mı?
            if (_randevuluGunler.Contains(e.Date.Date))
            {
                // Günü Kalın (Bold) yap
                e.Style.Font = new System.Drawing.Font(e.Style.Font, System.Drawing.FontStyle.Bold);

                // Opsiyonel: Rengini de değiştirebilirsiniz (Örn: Lacivert)
                // e.Style.ForeColor = System.Drawing.Color.Navy; 
            }
        }
    }
}