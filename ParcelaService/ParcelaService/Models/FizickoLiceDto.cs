using System;

namespace ParcelaService.Models
{
    public class FizickoLiceDto
    {
        public Guid LiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public AdresaDto Adresa { get; set; }
        public string BrojTelefona1 { get; set; }
        public string BrojTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrojRacuna { get; set; }
    }
}
