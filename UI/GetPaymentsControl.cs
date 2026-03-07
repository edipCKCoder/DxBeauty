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

            if (gridView1.Columns["InstallmentId"] != null) gridView1.Columns["InstallmentId"].Visible = false;
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
            if (!_customerId.HasValue) return;
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

                    // İşlem bittikten sonra taşıyıcı formu (Dialog'u) kapat
                    var parentForm = this.FindForm();
                    if (parentForm != null) parentForm.DialogResult = DialogResult.OK;
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
            }
            else
            {
                // Temizlendiyse grid'i boşalt
                gridControl1.DataSource = null;
                _customerId = null;
            }
        }
    }
}
