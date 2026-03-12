using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class MessageTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateContent { get; set; }
        public string TemplateCode { get; set; } // REMINDER, NO_SHOW, DEBT, CUSTOM
        public bool IsSystem { get; set; }       // True ise korumalıdır
        public bool IsActive { get; set; }       // Silinmiş mi (Soft Delete için)
    }
}
