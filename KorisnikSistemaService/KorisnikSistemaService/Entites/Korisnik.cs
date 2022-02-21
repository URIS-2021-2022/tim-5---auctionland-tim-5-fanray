using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Entites
{
    public class Korisnik
    {
       [Key]

       public Guid KorisnikID { get; set; }
       public string Ime { get; set; }
       public string Prezime { get; set; }
       public string KorisnickoIme { get; set; }
       public string Lozinka { get; set; }
       public string Salt { get; set; }

       [ForeignKey("TipKorisnika")]
       public Guid TipKorisnikaID { get; set; }
       public TipKorisnika TipKorisnika { get; set; }
    }
}
