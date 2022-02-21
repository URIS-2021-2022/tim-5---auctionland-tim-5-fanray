using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdresaService.Entities
{
    public class Adresa
    {
        [Key]
        public Guid AdresaID { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public int PostanskiBroj { get; set; }
        [ForeignKey("Drzava")]
        public Guid DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
    }
}
