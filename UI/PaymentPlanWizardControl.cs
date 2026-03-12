using Dapper;
using DevExpress.XtraEditors;
using DXBeauty.Entities;
using DXBeauty.Enums;
using Microsoft.VisualBasic;
using Npgsql;
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
    public partial class PaymentPlanWizardControl : DevExpress.XtraEditors.XtraUserControl
    {

        // Grid'de göstereceğimiz geçici model
        public class InstallmentGridModel
        {
            public int Sira { get; set; }
            public decimal Tutar { get; set; }
            public DateTime Tarih { get; set; }
        }

        // Dışarıdan gelecek paket ve müşteri bilgileri
        private int _customerId;
        private ServicePackage _selectedPackage;
        private string _connectionString;

        // İşlem bittiğinde arka plandaki listeyi yenilemek için fırlatacağımız olay (Event)
        public event Action PlanSavedSuccessfully;

        public PaymentPlanWizardControl(int customerId, ServicePackage selectedPackage)
        {
            InitializeComponent();
            _customerId = customerId;
            _selectedPackage = selectedPackage;
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        public PaymentPlanWizardControl()
        {
            InitializeComponent();
        }

        private void PaymentPlanWizardControl_Load(object sender, EventArgs e)
        {
            // Ekran açıldığında ilk değerleri doldur
            lblPackageName.Text = $"{_selectedPackage.Name.ToUpper()} - ({_selectedPackage.SessionCount} Seans)";
            calcTotalPrice.Value = _selectedPackage.TotalPrice;

            calcRemainingDebt.Value = _selectedPackage.TotalPrice - calcDownPayment.Value;

            rgPaymentType.SelectedIndex = 2; // Varsayılan olarak "Açık Hesap" seçili gelsin
            cmbIntervalType.SelectedIndex = 0; // Varsayılan "Ay"
            spinIntervalValue.Value = 1; // Varsayılan 1
                                         // Peşinat girildikçe kalan borcu otomatik hesapla

            UpdateUIBasedOnPaymentType();
        }

        private void UpdateUIBasedOnPaymentType()
        {
            int selectedType = rgPaymentType.SelectedIndex;

            // 0: Peşin, 1: Taksitli, 2: Açık Hesap
            if (selectedType == 1) // Sadece Taksitli seçilirse Grid ve Planlama araçları görünür
            {
                cmbIntervalTypeLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                spinInstallmentCountLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                spinIntervalValueLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                gridInstallmentsLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btnGeneratePlanLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else // Peşin veya Açık Hesap'ta planlama alanı gizlenir!
            {
                spinInstallmentCountLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                spinIntervalValueLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                gridInstallmentsLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnGeneratePlanLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                cmbIntervalTypeLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void rgPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIBasedOnPaymentType();
        }

        private void calcDownPayment_EditValueChanged(object sender, EventArgs e)
        {
            // Peşinat girildikçe kalan borcu otomatik hesapla
            decimal total = calcTotalPrice.Value;
            decimal downPayment = calcDownPayment.Value;
            calcRemainingDebt.Value = total - downPayment;
        }

        private void btnGeneratePlan_Click(object sender, EventArgs e)
        {
            int taksitSayisi = Convert.ToInt32(spinInstallmentCount.Value);
            decimal kalanBorc = calcRemainingDebt.Value;
            int aralikDegeri = Convert.ToInt32(spinIntervalValue.Value);
            string aralikTuru = cmbIntervalType.Text;

            if (taksitSayisi <= 0)
            {
                XtraMessageBox.Show("Lütfen geçerli bir taksit sayısı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kalanBorc <= 0)
            {
                XtraMessageBox.Show("Kalan borç 0 olduğu için plan oluşturulamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal aylikTutar = Math.Round(kalanBorc / taksitSayisi, 2);
            List<InstallmentGridModel> plan = new List<InstallmentGridModel>();

            for (int i = 1; i <= taksitSayisi; i++)
            {
                DateTime vadeTarihi = DateTime.Now;

                switch (aralikTuru)
                {
                    case "Ay": vadeTarihi = vadeTarihi.AddMonths(i * aralikDegeri); break;
                    case "Hafta": vadeTarihi = vadeTarihi.AddDays(i * aralikDegeri * 7); break;
                    case "Gün": vadeTarihi = vadeTarihi.AddDays(i * aralikDegeri); break;
                }

                if (i == taksitSayisi) // Son taksitte kuruşları toparla
                {
                    aylikTutar = kalanBorc - plan.Sum(x => x.Tutar);
                }

                plan.Add(new InstallmentGridModel { Sira = i, Tutar = aylikTutar, Tarih = vadeTarihi });
            }

            gridInstallments.DataSource = plan;
            gridView1.PopulateColumns(); // Kolonları otomatik oluştur
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int paymentType = rgPaymentType.SelectedIndex; // 0: Peşin, 1: Taksitli, 2: Açık Hesap
            decimal downPayment = calcDownPayment.Value;
            decimal remainingDebt = calcRemainingDebt.Value;

            // --- 1. STATÜYÜ C# TARAFINDA (KAYDETMEDEN ÖNCE) BELİRLE ---
            int initialStatus = 1; // Varsayılan: NoPayment (1)

            if (calcRemainingDebt.Value <= 0)
            {
                // Kalan borç sıfırsa, müşteri her şeyi o an peşin ödemiştir
                initialStatus = 3; // NoDebt (3)
            }
            else if (calcDownPayment.Value > 0)
            {
                // Kalan borç var ama adam masaya peşinat da koydu
                initialStatus = 2; // PartialPayment (2)
            }
            else
            {
                // Masaya hiç para koymadı, her şeyi taksite veya açık hesaba yazdırdı
                initialStatus = 1; // NoPayment (1)
            }




            if (paymentType == 1 && (gridInstallments.DataSource as List<InstallmentGridModel>)?.Count == 0)
            {
                XtraMessageBox.Show("Lütfen önce 'Planı Oluştur' butonuna basınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. ANA PAKETİ SATIŞ OLARAK KAYDET (customer_services)
                        string insertCsSql = @"
                    INSERT INTO customer_services (customer_id, service_package_id, start_date, remaining_sessions, total_price, remaining_debt, paid_amount, status)
                    VALUES (@CustomerId, @ServicePackageId, @StartDate, @RemainingSessions, @TotalPrice, @RemainingDebt, @PaidAmount, @Status)
                    RETURNING customer_service_id;";

                        int newCustomerServiceId = await connection.ExecuteScalarAsync<int>(insertCsSql, new
                        {
                            CustomerId = _customerId,
                            ServicePackageId = _selectedPackage.ServicePackageId,
                            StartDate = DateTime.Now,
                            RemainingSessions = _selectedPackage.SessionCount,
                            TotalPrice = _selectedPackage.TotalPrice,
                            RemainingDebt = calcRemainingDebt.Value,
                            PaidAmount = calcDownPayment.Value,
                            Status = initialStatus

                        }, transaction);

                        // YENİ ÖDEME PLANI SQL SORGUMUZ
                        string insertPlanSql = @"
                    INSERT INTO payment_plans (customer_service_id, sequence_number, amount, due_date, is_paid,paid_at, paid_amount, plan_type) 
                    VALUES (@CsId, @SeqNo, @Amount, @DueDate, (@PaidAmount >= @Amount),@PaidAt, @PaidAmount, @PlanType);";

                        int currentSequence = 1; // Sıra numarasını takip edeceğimiz sayaç

                        // 2. PEŞİNAT VARSA (Sisteme Tip 1 olarak kaydedilir)  //peşinat varsa tarihi kaydet
                        if (downPayment > 0)
                        {
                            await connection.ExecuteAsync(insertPlanSql, new
                            {
                                CsId = newCustomerServiceId,
                                SeqNo = currentSequence,
                                Amount = downPayment,
                                DueDate = (DateTimeOffset?)null, // Peşinat tipinde vade tarihi yok
                                PaidAt = DateTime.Now.Date, //anında ödendiği için bugünün tarihi
                                PaidAmount = downPayment,
                                PlanType = (int)PaymentPlanType.DownPayment // 1
                            }, transaction);

                            currentSequence++; // Peşinat 1. sırayı kaptı, sonrakiler 2'den başlayacak
                        }

                        // 3. KALAN BORÇ İÇİN ÖDEME PLANI
                        if (paymentType == 0) // PEŞİN ÖDEME (Kalanı da bugün istiyoruz - Tip: Taksit/Tek Çekim)
                        {
                            if (remainingDebt > 0)
                                await connection.ExecuteAsync(insertPlanSql, new
                                {
                                    CsId = newCustomerServiceId,
                                    SeqNo = currentSequence,
                                    Amount = remainingDebt,
                                    PaidAmount = 0m,
                                    DueDate = DateTime.Now.Date,
                                    PaidAt = (DateTimeOffset?)null, // Henüz ödenmediği için null
                                    PlanType = (int)PaymentPlanType.Installment // 2
                                }, transaction);
                        }
                        else if (paymentType == 2) // AÇIK HESAP (Tip: 3)
                        {
                            if (remainingDebt > 0)
                                await connection.ExecuteAsync(insertPlanSql, new
                                {
                                    CsId = newCustomerServiceId,
                                    SeqNo = currentSequence,
                                    Amount = remainingDebt,
                                    PaidAmount = 0m, 
                                    DueDate = DateTime.Now.AddYears(1).Date, // Sembolik ileri tarih
                                    PaidAt = (DateTimeOffset?)null, // Henüz ödenmediği için null
                                    PlanType = (int)PaymentPlanType.OpenAccount // 3
                                }, transaction);
                        }
                        else if (paymentType == 1) // TAKSİTLİ (Grid'deki listeyi Tip 2 olarak aktar)
                        {
                            var plan = gridInstallments.DataSource as List<InstallmentGridModel>;

                            foreach (var item in plan)
                            {
                                await connection.ExecuteAsync(insertPlanSql, new
                                {
                                    CsId = newCustomerServiceId,
                                    SeqNo = currentSequence,
                                    Amount = item.Tutar,
                                    PaidAmount = 0m,
                                    DueDate = item.Tarih,
                                    PaidAt = (DateTimeOffset?)null, // Henüz ödenmediği için null
                                    PlanType = (int)PaymentPlanType.Installment // 2
                                }, transaction);

                                currentSequence++; // Taksit numaraları sırayla artar (Örn: 2, 3, 4...)
                            }
                        }

                        transaction.Commit();

                        XtraMessageBox.Show("Satış işlemi ve ödeme planı başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PlanSavedSuccessfully?.Invoke();
                        this.FindForm()?.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        XtraMessageBox.Show("İşlem sırasında bir hata oluştu: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ... (Diğer metotlar buraya gelecek)




    }
}
