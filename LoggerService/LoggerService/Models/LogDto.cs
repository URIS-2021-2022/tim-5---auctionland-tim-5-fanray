using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Models
{
    public class LogDto
    {
        public Guid LogID { get; set; }
        public string Opis { get; set; }
        public string DatumKreiranja { get; set; }
        public string VremeKreiranja { get; set; }
    }
}
