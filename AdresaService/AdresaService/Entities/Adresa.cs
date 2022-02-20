using System;

namespace AdresaService.Entities
{
    public class Adresa
    {
        public Guid AdresaID { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public int PostanskiBroj { get; set; }
        public Guid DrzavaID { get; set; }
       
    }
}
