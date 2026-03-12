using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class CustomerServiceLookupDto
    {
        public int CustomerServiceId { get; set; }
        public string PackageName { get; set; }
        public int RemainingSessions { get; set; } // Veritabanındaki gerçek kalan hak
        public int AvailableSessions { get; set; } // Planlanabilir (Boşta olan) hak

        // ComboBox'ta veznedarın göreceği o harika dinamik metin!
        public string DisplayText => $"{PackageName} (Kalan: {RemainingSessions} | Boşta: {AvailableSessions})";
    }
}
