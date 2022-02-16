using System;

namespace ZalbaService.Entities
{
    public class Korisnik
    {
        public Guid KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public Guid TipKorisnika { get; set; }
        public string Salt { get; set; }
    }
}
