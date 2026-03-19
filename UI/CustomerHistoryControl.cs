using DevExpress.XtraEditors;
using DXBeauty.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class CustomerHistoryControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly string _connectionString;
        private CustomerRepository _customerRepo;
        
        public CustomerHistoryControl()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _customerRepo = new CustomerRepository(_connectionString);
          
        }

        private void CustomerHistoryControl_Load(object sender, EventArgs e)
        {
            // 1. Ekran açıldığında müşterileri doldur
            LoadCustomers();

            // 2. GridControl'ün Master-Detail Sihirli Ayarları

            // Eğer detayı yoksa (liste boşsa) [+] butonunu hiç gösterme!
            gridView1.OptionsDetail.AllowExpandEmptyDetails = false;

            // Satırda sadece 1 tane detay olacağı için "Randevu/Ödeme" gibi sekme (Tab) başlıklarını gizle, 
            // kullanıcı [+]'ya basınca direkt tablo açılsın! (Tam istediğin özellik)
            gridView1.OptionsDetail.ShowDetailTabs = false;

            // Ana satırları sadece okunabilir yap (Yanlışlıkla değiştirilmesin)
            gridView1.OptionsBehavior.Editable = false;
        }
        private void LoadCustomers()
        {
            slueCustomer.Properties.DataSource = _customerRepo.GetAll();
            slueCustomer.Properties.DisplayMember = "FullName";
            slueCustomer.Properties.ValueMember = "CustomerId";
        }

        private async void slueCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (slueCustomer.EditValue != null)
            {
                int customerId = Convert.ToInt32(slueCustomer.EditValue);
                await LoadCustomerHistory(customerId);
            }
        }

        private async Task LoadCustomerHistory(int customerId)
        {
            // Veritabanından o efsanevi Dapper metoduyla geçmişi çekiyoruz
            var repo = new CustomerHistoryRepository(_connectionString);
            var historyData = await repo.GetCustomerHistoryAsync(customerId);

            // Ve DevExpress'e bağlayıp şovu başlatıyoruz!
            gridControlHistory.DataSource = historyData;

            // Kolonları veriye göre otomatik sığdır
            gridView1.BestFitColumns();
        }
    }
}
/*
 

 
 
 */