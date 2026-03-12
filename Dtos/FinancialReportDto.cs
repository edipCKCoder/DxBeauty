using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class FinancialReportDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string PlanDescription { get; set; } // Örn: "3. Taksit - Lazer Epilasyon" veya "Açık Hesap - Cilt Bakım"
        public DateTime? DueDate { get; set; }      // Vade Tarihi
        public decimal TotalAmount { get; set; }    // Taksitin Toplam Tutarı
        public decimal PaidAmount { get; set; }     // Ne Kadarı Ödendi
        public decimal RemainingDebt { get; set; }  // Kalan Borç
        public bool IsPaid { get; set; }            // Ödendi Mi? (Durum İkonu için harika olur)

        // WhatsApp mesajında Paketin tam adını kullanmak istersek diye:
        public string PackageName { get; set; }
    }
}
