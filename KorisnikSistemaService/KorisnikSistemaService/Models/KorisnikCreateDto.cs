using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Models
{
    public class KorisnikCreateDto
    {
        public Guid TipKorisnikaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set;}
    }
}
