using Dapper;
using DevExpress.XtraEditors;
using DXBeauty.Data;
using DXBeauty.Dtos;
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
    public partial class GetPaymentsControl : DevExpress.XtraEditors.XtraUserControl
    {

        private string _connectionString;
        private int? _customerId;
        private int? _appointmentId;
        private int? _customerServiceId;
        public GetPaymentsControl()
        {
            InitializeComponent();
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        // Form ilk açıldığında çalışacak Kurucu Metot (Constructor)
        public GetPaymentsControl(int? customerId = null, int? appointmentId = null, int? customerServiceId = null)
        {
            InitializeComponent();
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // Parametreleri hafızaya alıyoruz
            _customerId = customerId;
            _appointmentId = appointmentId;
            _customerServiceId = customerServiceId;
        }

        private async void GetPaymentsControl_Load(object sender, EventArgs e)
        {
            // 1. Önce SearchLookUpEdit (Müşteri Seçici) nesnemize tüm müşterileri dolduruyoruz
            // (CustomerRepository'de müşterileri getiren metodun olduğunu varsayıyorum)
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            var allCustomers = customerRepo.GetAll();

            slueCustomer.Properties.DataSource = allCustomers;
            slueCustomer.Properties.DisplayMember = "FullName"; // Müşteri adının olduğu kolonun adı
            slueCustomer.Properties.ValueMember = "CustomerId";

            // 2. Akıllı Yönlendirme: TAKVİMDEN Mİ GELDİK, MENÜDEN Mİ?
            if (_customerId.HasValue)
            {
                // TAKVİMDEN GELDİK (Popup Modu)
                slueCustomer.EditValue = _customerId.Value; // Müşteriyi otomatik seç
                slueCustomer.ReadOnly = true;               // Değiştirmesini engelle! (Çünkü bu randevuya özel)

                await LoadCustomerDebts(_customerId.Value); // Borçları getir
            }
            else
            {
                // MENÜDEN GELDİK (Panel / Walk-in Modu)
                slueCustomer.EditValue = null; // Boş bırak
                slueCustomer.ReadOnly = false; // Görevli istediği müşteriyi arayıp seçebilsin
            }
            CalculateTotalSelectedAmount();

        }


        private async Task LoadCustomerDebts(int customerId)
        {
            PaymentRepository repo = new PaymentRepository(_connectionString);
            var unpaidDebts = await repo.GetUnpaidDebtsAsync(customerId);

            gridControl1.DataSource = unpaidDebts;

            // CheckBox seçimi vb. ayarlar
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            if (gridView1.Columns["PaymentPlanId"] != null) gridView1.Columns["PaymentPlanId"].Visible = false;
            if (gridView1.Columns["CustomerServiceId"] != null) gridView1.Columns["CustomerServiceId"].Visible = false;
            if (gridView1.Columns["AppointmentId"] != null) gridView1.Columns["AppointmentId"].Visible = false;


            // Eğer takvimden geldiysek ve belirli bir randevuyla açıldıysa onu otomatik seç
            if (_appointmentId.HasValue)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var rowAppointmentId = gridView1.GetRowCellValue(i, "AppointmentId");
                    if (rowAppointmentId != null && rowAppointmentId != DBNull.Value && Convert.ToInt32(rowAppointmentId) == _appointmentId.Value)
                    {
                        gridView1.SelectRow(i);
                        break;
                    }
                }
            }
        }

        private async Task LoadCustomerSummaryInfo(int customerId)
        {
            // Bu metod çalıştığında önce ekranı "Hesaplanıyor..." durumuna getirip temizleyelim
            txtKalanToplamBorc.Text = "...";
            txtVadesiGecmisBorc.Text = "...";
            txtMusteriKayitTarihi.Text = "...";
           

            // Npgsql bağlantınızı kullanarak çok hafif bir sorgu atıyoruz
            using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // 1. Müşterinin Kayıt Tarihini Çek (customers tablosundan)
                // Eğer tablonuzda 'created_at' diye bir kolon yoksa, kendi kayıt tarihi kolon adınızı yazın
                string kayitSql = "SELECT created_at FROM customers WHERE customer_id = @Id;";
                var kayitTarihi = await connection.ExecuteScalarAsync<DateTime?>(kayitSql, new { Id = customerId });

                txtMusteriKayitTarihi.Text = kayitTarihi.HasValue ? kayitTarihi.Value.ToString("dd.MM.yyyy") : "Bilinmiyor";

                // 2. Kalan Toplam Borcu Hesapla (customer_services tablosundan 'remaining_debt'leri topla)
                string toplamBorcSql = "SELECT COALESCE(SUM(remaining_debt), 0) FROM customer_services WHERE customer_id = @Id;";
                decimal toplamBorc = await connection.ExecuteScalarAsync<decimal>(toplamBorcSql, new { Id = customerId });

                txtKalanToplamBorc.Text = toplamBorc.ToString("C2"); // ₺ formatında yazdır

                // 3. Vadesi Geçmiş Borcu Hesapla (payment_plans tablosundan, bugünden önceki ödenmemişleri topla)
                string gecikmisBorcSql = @"
            SELECT COALESCE(SUM(pp.amount - COALESCE(pp.paid_amount, 0)), 0) 
            FROM payment_plans pp
            INNER JOIN customer_services cs ON pp.customer_service_id = cs.customer_service_id
            WHERE cs.customer_id = @Id 
            AND pp.is_paid = false 
            AND pp.due_date < CURRENT_DATE;";

                decimal gecikmisBorc = await connection.ExecuteScalarAsync<decimal>(gecikmisBorcSql, new { Id = customerId });

                txtVadesiGecmisBorc.Text = gecikmisBorc.ToString("C2");

                // Gecikmiş borç varsa dikkat çekmesi için rengini kırmızı yapalım
                if (gecikmisBorc > 0)
                {
                    txtVadesiGecmisBorc.ForeColor = Color.Red;
                    txtVadesiGecmisBorc.Font = new Font(txtVadesiGecmisBorc.Font, FontStyle.Bold);
                }
                else
                {
                    txtVadesiGecmisBorc.ForeColor = Color.Black; // Standart renk
                    txtVadesiGecmisBorc.Font = new Font(txtVadesiGecmisBorc.Font, FontStyle.Regular);
                }
            }
        }



        private void CalculateTotalSelectedAmount()
        {
            decimal totalAmount = 0;

            // 1. Grid üzerinde o an "Seçili" (Kutucuğu işaretli) olan tüm satırların numaralarını al
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            // 2. Seçili satırların içinde dön
            foreach (int rowHandle in selectedRowHandles)
            {
                // "Amount" (Tutar) sütunundaki değeri oku
                object value = gridView1.GetRowCellValue(rowHandle, "Amount");

                if (value != null && value != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(value);
                }
            }

            // 3. Çıkan toplamı sağ taraftaki CalcEdit (veya Label) kontrolüne yazdır
            // Not: calcAmount, senin forma eklediğin o DevExpress CalcEdit nesnesinin adı olmalı
            calcAmount.EditValue = totalAmount;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            CalculateTotalSelectedAmount();
        }

        private async void btnSavePayment_Click(object sender, EventArgs e)
        {
            // 1. Güvenlik Kontrolleri (Kullanıcı verileri doğru girmiş mi?)
            if (!_customerId.HasValue) 
            {
                XtraMessageBox.Show("Lütfen bir Müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbPaymentMethod.Text))
            {
                XtraMessageBox.Show("Lütfen bir ödeme yöntemi (Nakit/Kart vb.) seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Grid'den KUTUCUĞU İŞARETLİ olan satırları bul ve listeye çevir
            List<CustomerDebtDto> selectedDebts = new List<CustomerDebtDto>();
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            if (selectedRowHandles.Length == 0)
            {
                XtraMessageBox.Show("Lütfen tahsilat yapmak için tablodan en az bir işlem seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (int rowHandle in selectedRowHandles)
            {
                // Grid'deki o satırı, bizim kendi objemize (CustomerDebtDto) çeviriyoruz
                var rowData = gridView1.GetRow(rowHandle) as CustomerDebtDto;
                if (rowData != null)
                {
                    // Eğer tek seans (fiyatı 0 gelen) randevuysa, arayüzdeki CalcEdit'ten girdiği tutarı bu satıra yaz
                    // Not: İleri seviyede kısmi ödeme (partial payment) olursa burası geliştirilebilir.
                    if (rowData.Amount == 0)
                    {
                        rowData.Amount = Convert.ToDecimal(calcAmount.EditValue);
                    }
                    selectedDebts.Add(rowData);
                }
            }

            // 3. Dapper Repository'i çağır ve işlemi patlat!
            try
            {
                PaymentRepository repo = new PaymentRepository(_connectionString);
                decimal totalAmount = Convert.ToDecimal(calcAmount.EditValue);
                DateTime paymentDate = dtPaymentDate.DateTime != DateTime.MinValue ? dtPaymentDate.DateTime : DateTime.Now;

                bool success = await repo.ProcessPaymentsAsync(_customerId.Value, selectedDebts, totalAmount, cmbPaymentMethod.Text, paymentDate);

                if (success)
                {
                    XtraMessageBox.Show("Tahsilat başarıyla alındı ve borçlar kapatıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form parentForm = this.FindForm();

                    if (parentForm != null)
                    {
                        // ⚠️ 1. SENARYO: Eğer bu kontrol ayrı bir Pop-Up pencerede açılmışsa
                        if (parentForm.Modal)
                        {
                            parentForm.DialogResult = DialogResult.OK;
                            parentForm.Close(); // Kapanmayı kesin olarak zorla
                        }
                        else
                        {
                            // Sekmeyi kapatmak yerine ekranı sıfırla ve güncel durumu yükle

                            // 1. Kullanıcı giriş alanlarını temizle
                            calcAmount.EditValue = 0m;
                            txtDescription.Text = string.Empty;
                            cmbPaymentMethod.SelectedIndex = -1; // Ödeme yöntemini sıfırla
                            dtPaymentDate.DateTime = DateTime.Now; // Tarihi bugüne çek

                            // 2. Müşterinin güncel borçlarını ve sağ paneldeki özetini yeniden yükle
                            if (_customerId.HasValue)
                            {
                                // Grid'i güncel borçlarla doldur (Ödenenler listeden düşecektir)
                                await LoadCustomerDebts(_customerId.Value);

                                // Sağ taraftaki "Kalan Toplam Borç" vs. panosunu yeni duruma göre güncelle
                                await LoadCustomerSummaryInfo(_customerId.Value);

                                // Seçimler sıfırlandığı için toplam tutarı da 0'a çekecek metodu çağır
                                CalculateTotalSelectedAmount();
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void slueCustomer_EditValueChanged(object sender, EventArgs e)
        {
            // Eğer bir müşteri seçildiyse
            if (slueCustomer.EditValue != null && slueCustomer.EditValue != DBNull.Value)
            {
                int selectedCustomerId = Convert.ToInt32(slueCustomer.EditValue);

                // ÖNEMLİ: Global _customerId değişkenimizi de güncelliyoruz ki "Kaydet" butonu kime tahsilat yaptığını bilsin!
                _customerId = selectedCustomerId;

                // Ve o müşterinin borçlarını getiriyoruz
                await LoadCustomerDebts(selectedCustomerId);

                // ⚠️ YENİ KOD: Sağ taraftaki "Sadece Okunabilir" özet panosunu doldur!
                await LoadCustomerSummaryInfo(selectedCustomerId);
            }
            else
            {
                // Temizlendiyse grid'i boşalt
                gridControl1.DataSource = null;
                _customerId = null;
                txtKalanToplamBorc.Text = "";
                txtVadesiGecmisBorc.Text = "";
                txtMusteriKayitTarihi.Text = "";
            }
        }
    }
}
