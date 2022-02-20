using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Entites
{
    public class TipKorisnika
    {
        public Guid TipKorisnikaID { get; set; }
        public string NazivTipa { get; set; }

    }
}
