﻿using AutoMapper;
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

            FillData();
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
            k.Lozinka = korisnik.Lozinka;

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

        private void FillData()
        {
            var korisnik = HashPassword("korisnik123");

            KorisnikList.AddRange(new List<Korisnik>
            {
                new Korisnik
                {
                    KorisnikID = Guid.Parse("fd1267ce-2ee2-4503-9578-480d4f056d8b"),
                    Ime = "Ivan",
                    Prezime = "Ilic",
                    KorisnickoIme = "ivanilic",
                    Lozinka = korisnik.Item1,
                    TipKorisnikaID = Guid.Parse("dff28caf-e345-4b3c-9525-85898b7f93c3"),
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
