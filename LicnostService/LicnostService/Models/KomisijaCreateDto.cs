using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Models
{
    public class KomisijaCreateDto
    {
        public Guid ClanID { get; set; }

        public Guid PredsednikID { get; set; }
    }
}
