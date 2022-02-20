using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Models
{
    public class LiceDto
    {
        public Guid LiceID { get; set; }
        public int Broj_Telefona1 { get; set; }
        public int Broj_Telefona2 { get; set; }
        public string Email { get; set; }
        public int Broj_Racuna { get; set; }
    }
}
