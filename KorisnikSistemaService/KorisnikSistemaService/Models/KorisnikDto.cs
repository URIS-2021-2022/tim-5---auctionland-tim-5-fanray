using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Models
{
    public class KorisnikDto
    {
        public Guid KorisnikID { get; set; }
        public TipKorisnikaDto TipKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
