using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Entities
{
    public class Uplata
    {
        public Guid UplataID { get; internal set; }
        public int Broj_Racuna { get; set; }
        public int Poziv_Na_Broj { get; set; }
        public int Iznos { get; set; }
        public string Svrha_Uplate { get; set; }
        public DateTime DatumUplate { get; set; }
        public DateTime DatumKursa { get; set; }
        public string Valuta { get; set; }
        public float Vrednost { get; set; }
    }
}
