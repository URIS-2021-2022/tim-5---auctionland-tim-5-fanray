using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Models
{
    public class KomisijaDto
    {
        public Guid KomisijaID { get; set; }

        public Guid ClanID { get; set; }

        public Guid PredsednikID { get; set; }
    }
}
