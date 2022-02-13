using LicitacijaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LicitacijaService.Data
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
            var korisnik = HashPassword("licitacija123");

            KorisnikList.AddRange(new List<Korisnik>
            {
                new Korisnik
                {
                    KorisnikID = Guid.Parse("5bf4d21b-a7af-43dc-af47-ee45ccf4cedd"),
                    Ime = "Lena",
                    Prezime = "Stancic",
                    KorisnickoIme = "lenastancic",
                    Lozinka = korisnik.Item1,
                    TipKorisnika = Guid.Parse("fe364921-6ad7-4558-b559-6bb826691521"),
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
