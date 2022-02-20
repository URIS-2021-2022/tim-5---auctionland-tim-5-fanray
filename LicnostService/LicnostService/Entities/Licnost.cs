using System;

namespace LicnostService.Entities
{
    public class Licnost
    {
        public Guid LicnostID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Funkcija { get; set; }
    }
}
