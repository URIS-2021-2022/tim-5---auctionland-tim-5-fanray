using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class KontaktOsoba
    {
        [Key]
        public Guid KontaktOsobaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Funkcija { get; set; }
        public string Telefon { get; set; }

        [ForeignKey("PravnoLice")]
        public Guid Maticni_broj { get; set; }
        public PravnoLice LiPravnoLicece { get; set; }

        

    }
}
