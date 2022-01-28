using System;

namespace ParcelaService.Models
{
    public class KontaktOsobaDto
    {
        public Guid KontaktOsobaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Funkcija { get; set; }
        public string Telefon { get; set; }
    }
}
