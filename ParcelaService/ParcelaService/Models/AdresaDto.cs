using System;

namespace ParcelaService.Models
{
    public class AdresaDto
    {
        public Guid AdresaID { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public string PostanskiBroj { get; set; }
        public DrzavaDto Drzava { get; set; }
    }
}
