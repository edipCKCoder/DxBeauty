using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class CustomerDebtDto
    {
        public string DebtType { get; set; } // "Paket Taksidi" veya "Tek Seans"
        public string Description { get; set; } // Örn: "Lazer Epilasyon - 1. Taksit"
        public DateTime DueDate { get; set; } // Son Ödeme Tarihi
        public decimal Amount { get; set; } // Tutar

        // Arka planda tutacağımız (Kullanıcının görmeyeceği) gizli ID'ler
        public int? PaymentPlanId { get; set; }
        public int? CustomerServiceId { get; set; }
        public int? AppointmentId { get; set; }
    }
}
