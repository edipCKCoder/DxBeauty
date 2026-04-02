using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DXBeauty.Data;
using DXBeauty.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class FinancialReportControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        PaymentPlanRepository _paymentPlanRepository;
        public FinancialReportControl()
        {
            InitializeComponent();
            _paymentPlanRepository = new PaymentPlanRepository(_connectionString);

            repositoryItemButtonEdit1.ButtonClick += RepositoryItemButtonEdit1_ButtonClick;
        }

        private void RepositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var seciliSatir = gridViewFinancialReport.GetRow(gridViewFinancialReport.FocusedRowHandle) as FinancialReportDto;

            if (seciliSatir == null) return;

            // EĞER BU SATIRIN BORCU VARSA WHATSAPP BUTONUNU EKLE!
            if (seciliSatir.RemainingDebt > 0 && !seciliSatir.IsPaid)
            {
                // Popup menüyü oluştur
                DevExpress.Utils.Menu.DXPopupMenu anaMenu = new DevExpress.Utils.Menu.DXPopupMenu();

                // Alt menüyü oluştur
                DevExpress.Utils.Menu.DXMenuItem btnWhatsapp = new DevExpress.Utils.Menu.DXMenuItem("WhatsApp Borç Hatırlatması Gönder");
                btnWhatsapp.ImageOptions.SvgImage = Properties.Resources.accounting;
                btnWhatsapp.BeginGroup = true;

                // Butona Tıklandığında Çalışacak Kod
                btnWhatsapp.Click += async (s, args) =>
                {
                    await SendDebtReminderAsync(seciliSatir);
                };
                anaMenu.Items.Add(btnWhatsapp);

                anaMenu.ShowPopup(gridFinancialReport, gridFinancialReport.PointToClient(Control.MousePosition));
            }
            else { 
                DevExpress.XtraEditors.XtraMessageBox.Show("Borcu Yok!", "Uyarı", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning); 
            }
        }

        private async void FinancialReportControl_Load(object sender, EventArgs e)
        {
            var reportList = (await _paymentPlanRepository.GetFinancialReportAsync()).ToList();
            gridFinancialReport.DataSource = reportList;
           
            gridViewFinancialReport.Columns["FullName"].Group();
        }


        

        private async Task SendDebtReminderAsync(FinancialReportDto veri)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString)) // Kendi bağlantını yaz
                {
                    if (string.IsNullOrWhiteSpace(veri.Phone))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Müşterinin telefon numarası yok!", "Uyarı", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        return;
                    }

                    // 1. Veritabanından 'DEBT' kodlu şablonu çek
                    string sablonSql = "SELECT template_content FROM message_templates WHERE template_code = 'DEBT' AND is_active = true LIMIT 1";
                    string sablonIcerik = await connection.QuerySingleOrDefaultAsync<string>(sablonSql);

                    if (string.IsNullOrWhiteSpace(sablonIcerik))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Borç hatırlatma şablonu (DEBT) bulunamadı!", "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Mesajı Dinamik Olarak Doldur
                    DXBeauty.Services.WhatsAppService waService = new DXBeauty.Services.WhatsAppService(_connectionString);

                    // Kendi yazdığımız şablondaki {MusteriAdi}, {PaketAdi} ve {Tutar} alanlarını dolduruyoruz
                    string hazirMesaj = waService.GenerateMessageFromTemplate(
                        templateContent: sablonIcerik,
                        customerName: veri.FullName,
                        date: null,
                        serviceName: null,
                        amount: veri.RemainingDebt, // Kalan borcu tutar olarak gönderiyoruz
                        packageName: veri.PlanDescription + " (" + veri.PackageName + ")" // Örn: "3. Taksit (Lazer Epilasyon)"
                    );

                    // Alt satır düzeltmesi (Bir önceki adımda konuştuğumuz \n sorunu için)
                    hazirMesaj = hazirMesaj.Replace("\\n", "\n");

                    // 3. Mesajı Gönder (Loglama tipi 2: Borç Hatırlatma)
                    await waService.SendMessageAsync(veri.CustomerId, null, veri.Phone, hazirMesaj, 2);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("WhatsApp yönlendirmesi sırasında hata oluştu: " + ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


    }
}
