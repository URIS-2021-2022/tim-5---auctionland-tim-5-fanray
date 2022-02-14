using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Entites
{
    public class TipKorisnika
    {
        [Key]
        public Guid TipKorisnikaID { get; set; }

        [Required]
        public string NazivTipa { get; set; }

    }
}
