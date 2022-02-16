using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Models
{
    public class ClanUpdateDto
    {
        public Guid ClanID { get; set; }
        public Guid LicnostID { get; set; }
    }
}
