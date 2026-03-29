using DevExpress.Charts.Native;
using DevExpress.XtraCharts;
using DXBeauty.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
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

                tileView1.HtmlImages = svgImageCollection1;

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

                tileItem1.Elements[0].Text = $"{summary.TotalRevenue:N2} ₺";
             
                tileItem3.Elements[3].Text = $"Nakit\n{summary.CashTotal:N2} ₺ ";

                tileItem3.Elements[1].Text = $"Kart\n{ summary.CreditCardTotal:N2} ₺";
                
                tileItem3.Elements[4].Text = $"Havale/EFT\n      { summary.EftTotal:N2} ₺";


                tileItem7.Elements[0].Text = $"{summary.ExpectedInstallments:N2} ₺";
                tileItem8.Elements[1].Text = $"{summary.TodayAppointmentCount}";

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

            // =========================================================================
            // ⚡️ 1. VERİ BAĞLAMA (Foreach yerine doğrudan ve güvenli bağlama)
            // =========================================================================
            chartRevenue.Series.Clear();
            Series series = new Series("Günlük Ciro", ViewType.Bar);
            chartRevenue.Series.Add(series);

            series.DataSource = revenueData;
            // DTO'daki property isimlerini buraya yazıyoruz
            series.ArgumentDataMember = "Date";
            series.ValueDataMembers.AddRange(new string[] { "DailyTotal" });

            // =========================================================================
            // 🎨 2. ÇUBUK (BAR) TASARIMI
            // =========================================================================
            BarSeriesView view = (BarSeriesView)series.View;
            view.Color = Color.FromArgb(23, 162, 184); // Kurumsal Turkuaz rengi
            view.Border.Visibility = DevExpress.Utils.DefaultBoolean.False; // Sert kenarlıkları sil
            view.BarWidth = 0.5; // Çubukları biraz incelt, daha zarif dursun

            // Üzerindeki sabit yazıları gizle (Kalabalığı önler)
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            // =========================================================================
            // 📐 3. EKSEN VE IZGARA (DIAGRAM) TEMİZLİĞİ
            // =========================================================================
            XYDiagram diagram = (XYDiagram)chartRevenue.Diagram;

            // -- Y EKSENİ (TUTAR) --
            diagram.AxisY.Label.TextPattern = "{V:N0} ₺";
            diagram.AxisY.GridLines.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash; // ❗️ Kesik çizgiler
            diagram.AxisY.GridLines.Color = Color.FromArgb(230, 230, 230); // ❗️ Çok açık ve kibar gri
            diagram.AxisY.Tickmarks.Visible = false; // Eksen çentiklerini sil

            // -- X EKSENİ (TARİH) --
            diagram.AxisX.Label.Angle = -45;
            // DTO'daki Date nesnesini doğrudan formatlıyoruz (Eski .ToString("dd MMM")'ye gerek kalmadı)
            diagram.AxisX.Label.TextPattern = "{A:dd MMM}";
            diagram.AxisX.GridLines.Visible = false; // ❗️ Dikey çizgileri tamamen sil
            diagram.AxisX.Tickmarks.Visible = false; // Eksen çentiklerini sil

            // =========================================================================
            // 🖱️ 4. ETKİLEŞİM VE BAŞLIK AYARLARI
            // =========================================================================
            chartRevenue.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False; // Lejantı gizle

            // ❗️ Fare (Mouse) ile çubuğun üzerine gelince çıkacak modern bilgi baloncuğu (Crosshair)
            chartRevenue.CrosshairOptions.ShowArgumentLine = true;
            chartRevenue.CrosshairOptions.ShowValueLabels = true;
            series.CrosshairLabelPattern = "{A:dd MMMM}: {V:N0} ₺"; // Örn: 24 Mart: 19.500 ₺

            // Başlık Ekleme
            chartRevenue.Titles.Clear();
            DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
            chartTitle.Text = "Son 30 Günlük Ciro Trendi";
            chartTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Modern Font
            chartTitle.TextColor = Color.FromArgb(73, 80, 87); // Koyu profesyonel gri
            chartRevenue.Titles.Add(chartTitle);
        }

        // --- En Çok Satan Paketler Grafiği (Pie Chart) ---
        private async Task LoadPackagesChartAsync()
        {
            // 1. Veritabanından veriyi çek
            var packageData = await _dashboardRepo.GetTopSellingPackagesAsync();

            // 🚨 DİKKAT: Series.Clear() veya foreach döngüsü YOK! 
            // Tasarımcıdaki Doughnut (Halka) serimizi bozmadan doğrudan veriyi basıyoruz:
            chartPackages.DataSource = packageData;

            // ⚡️ 2. Hangi verinin nereye gideceğini C# üzerinden kesin olarak belirt (Tasarımcıdaki olası hataları ezer geçer)
            chartPackages.Series[0].ArgumentDataMember = "PackageName"; // X Ekseni (İsimler)
            chartPackages.Series[0].ValueDataMembers.AddRange(new string[] { "SalesCount" }); // Y Ekseni (Sayılar)

            // ⚡️ 3. Etiket Formatını Zorla Uygula
            chartPackages.Series[0].Label.TextPattern = "{A}\n{V} Seans\n({VP:P0})";

            // 🎯 4. Merkeze Dinamik Toplam Sayıyı Yazdırma
            int toplamIslem = packageData.Sum(x => x.SalesCount);

            // =========================================================================
            // 🔥 5. BORDER'I VE GÖRSEL KARMAŞAYI C# İLE ZORLA TEMİZLEME
            // =========================================================================

            // ❗️ Grafiğin etrafındaki dış border'ı kaldırır (ÇOK KRİTİK)
            chartPackages.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // ❗️ Etiketlerin etrafındaki o bağlantı çizgilerini ve etiket çerçevelerini temizler
            DoughnutSeriesLabel label = (DoughnutSeriesLabel)chartPackages.Series[0].Label;
            label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False; // Etiket kutu çerçevesini siler
            //label.FillStyle.FillMode = FillMode.Empty; // Etiket arka planını transparan yapar (beyaz kutu gider)
            //label.Position = PieSeriesLabelPosition.Outside; // Etiketleri dışarıda tutmaya devam et

            // ❗️ Lejantı (sağdaki renk kutucuklarını) gizleyelim, veri tekrarı olmasın
            chartPackages.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // 🎯 5. DİNAMİK MERKEZLEME VE TOPLAM SAYIYI YAZDIRMA (KAYMAYI ÇÖZEN KISIM)
            // =========================================================================

            // =========================================================================
            // 🔥 KAYMAYI KÖKÜNDEN ÇÖZEN YENİ MİMARİ: TOTAL LABEL 🔥
            // =========================================================================

            // Serinin görünümünü (View) Doughnut (Halka) olarak yakalıyoruz
            DoughnutSeriesView view = chartPackages.Series[0].View as DoughnutSeriesView;
            if (view != null)
            {
                // ❗️ Merkezdeki etiketi görünür yap
                view.TotalLabel.Visible = true;

                // ❗️ {TV} komutu (Total Value), LINQ ile sum() yapmana gerek kalmadan 
                // tüm dilimlerin toplamını otomatik olarak hesaplar ve merkeze yazar!
                view.TotalLabel.TextPattern = "Toplam\n{TV} Seans";

                // İstersen yazının fontunu ve rengini de buradan şık bir hale getirebilirsin
                view.TotalLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                view.TotalLabel.TextColor = Color.FromArgb(73, 80, 87);
            }

            // =========================================================================
            // 📌 GRAFİK BAŞLIĞI (CHART TITLE) EKLEME
            // =========================================================================

            // Önce eski başlıkları temizle (Form her yüklendiğinde üst üste binmemesi için)
            chartPackages.Titles.Clear();

            // Yeni bir başlık nesnesi oluştur
            DevExpress.XtraCharts.ChartTitle baslik = new DevExpress.XtraCharts.ChartTitle();

            // ❗️ Başlık Metni
            baslik.Text = "En Çok Satılan 5 Paket";

            // ❗️ Görsel Ayarlar (Modern ve Okunaklı)
            baslik.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            baslik.TextColor = Color.FromArgb(73, 80, 87); // Koyu profesyonel gri
            baslik.Alignment = StringAlignment.Center;     // Tam ortaya hizala
            baslik.Dock = ChartTitleDockStyle.Top;         // Grafiğin en tepesine sabitle

            // Başlığı grafiğe dahil et
            chartPackages.Titles.Add(baslik);

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