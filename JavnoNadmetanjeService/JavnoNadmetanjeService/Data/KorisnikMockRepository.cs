using JavnoNadmetanjeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public class KorisnikMockRepository : IKorisnikRepository
    {
        public List<Korisnik> KorisnikList { get; set; } = new List<Korisnik>();

        public KorisnikMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            var korisnik = HashPassword("javnonadmetanje123");

            KorisnikList.AddRange(new List<Korisnik>
            {
                new Korisnik
                {
                    KorisnikID = Guid.Parse("6679f93a-d6f9-4cae-96c7-f7ea80d8af18"),
                    Ime = "Nikola",
                    Prezime = "Gajic",
                    KorisnickoIme = "nikolag",
                    Lozinka = korisnik.Item1,
                    TipKorisnika = Guid.Parse("77a3e7b5-c53b-4eff-9c78-92c7dada91b3"),
                    Salt = korisnik.Item2
                }
            });
        }

        private Tuple<string, string> HashPassword(string lozinka)
        {
            var sBytes = new byte[lozinka.Length];

            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);

            var salt = Convert.ToBase64String(sBytes);
            var derivedBytes = new Rfc2898DeriveBytes(lozinka, sBytes, 100);

            return new Tuple<string, string>(Convert.ToBase64String(derivedBytes.GetBytes(256)), salt);
        }

        private bool VerifyPassword(string lozinka, string savedLozinka, string savedSalt)
        {
            var saltBytes = Convert.FromBase64String(savedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(lozinka, saltBytes, 100);

            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == savedLozinka;
        }

        public bool UserWithCredentialsExists(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = KorisnikList.FirstOrDefault(k => k.KorisnickoIme == korisnickoIme);

            if (korisnik == null)
            {
                return false;
            }

            if (VerifyPassword(lozinka, korisnik.Lozinka, korisnik.Salt))
            {
                return true;
            }

            return false;
        }
    }
}
