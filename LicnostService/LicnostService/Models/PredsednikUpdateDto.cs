using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Models
{
    public class PredsednikUpdateDto
    {
        public Guid PredsednikID { get; set; }
        public Guid LicnostID { get; set; }
    }
}
