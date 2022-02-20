using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Data
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private readonly KorisnikContext Context;
        private readonly IMapper Mapper;

        public List<Korisnik> KorisnikList { get; set; } = new List<Korisnik>();

        public KorisnikRepository(KorisnikContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;

            KorisnikList.AddRange(GetKorisnikList());
        }

        public List<Korisnik> GetKorisnikList()
        {
            return Context.Korisnik.ToList();
        }

        public Korisnik GetKorisnikById(Guid korisnikId)
        {
            return Context.Korisnik.FirstOrDefault(e => e.KorisnikID == korisnikId);
        }

        public KorisnikConfirmationDto CreateKorisnik(Korisnik korisnik)
        {
            korisnik.KorisnikID = Guid.NewGuid();

            var sifra = HashPassword(korisnik.Lozinka);

            korisnik.Lozinka = sifra.Item1;
            korisnik.Salt = sifra.Item2;

            Context.Korisnik.Add(korisnik);
            Context.SaveChanges();

            return Mapper.Map<KorisnikConfirmationDto>(korisnik);
        }

        public KorisnikConfirmationDto UpdateKorisnik(Korisnik korisnik)
        {
            Korisnik k = Context.Korisnik.FirstOrDefault(e => e.KorisnikID == korisnik.KorisnikID);

            if (k == null)
            {
                throw new EntryPointNotFoundException();
            }

            k.TipKorisnikaID = korisnik.TipKorisnikaID;
            k.Ime = korisnik.Ime;
            k.Prezime = korisnik.Prezime;
            k.KorisnickoIme = korisnik.KorisnickoIme;

            var sifra = HashPassword(korisnik.Lozinka);

            k.Lozinka = sifra.Item1;
            k.Salt = sifra.Item2;

            Context.SaveChanges();

            return Mapper.Map<KorisnikConfirmationDto>(k);
        }

        public KorisnikConfirmationDto DeleteKorisnik(Guid korisnikId)
        {
            Korisnik korisnik = GetKorisnikById(korisnikId);

            if (korisnik == null)
            {
                throw new ArgumentNullException("korisnikId");
            }

            Context.Korisnik.Remove(korisnik);
            Context.SaveChanges();

            return Mapper.Map<KorisnikConfirmationDto>(korisnik);
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
