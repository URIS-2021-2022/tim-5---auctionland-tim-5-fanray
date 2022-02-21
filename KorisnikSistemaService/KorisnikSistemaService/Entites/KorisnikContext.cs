using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Entites
{
    public class KorisnikContext : DbContext
    {

        private readonly IConfiguration Configuration;

        public KorisnikContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KorisnikSistemaDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipKorisnika>()
                .HasData(
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("454f563e-3057-4ea7-8f5f-c871249ab128"),
                        NazivTipa = "Operater"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("65fcb492-d16d-400d-86ae-8c111a662b5c"),
                        NazivTipa = "Tehnicki sekretar"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("5c3dce22-db15-4e07-ba9e-639ea7052e6e"),
                        NazivTipa = "Prva komisija"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("acfbe150-40cb-4f3e-9c38-2ad33bf1b0f0"),
                        NazivTipa = "Superuser"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("1c32413b-218e-4072-904e-4b5eb97002f2"),
                        NazivTipa = "Operater nadmetanja"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("88b2f64b-1644-479a-b36f-6bfd99727aa8"),
                        NazivTipa = "Licitant"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("2df591a9-588f-407c-9976-509398712d9d"),
                        NazivTipa = "Menadzer"
                    },
                    new TipKorisnika
                    {
                        TipKorisnikaID = Guid.Parse("9ec688a2-c452-4f4b-9d4f-79cd14ecf25f"),
                        NazivTipa = "Administrator"
                    }
                );

            var korisnik = HashPassword("tamara123");

            modelBuilder.Entity<Korisnik>()
                .HasData(
                    new Korisnik
                    {
                        KorisnikID = Guid.Parse("34f11383-cb12-481d-9ff7-2fd458dc7e2b"),
                        Ime = "Tamara",
                        Prezime = "Radulovic",
                        KorisnickoIme = "tamaraR",
                        Lozinka = korisnik.Item1,
                        TipKorisnikaID = Guid.Parse("acfbe150-40cb-4f3e-9c38-2ad33bf1b0f0"),
                        Salt = korisnik.Item2
                    }
                );
        }
        private Tuple<string, string> HashPassword(string lozinka)
        {
            var sBytes = new byte[lozinka.Length];

            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);

            var salt = Convert.ToBase64String(sBytes);
            var derivedBytes = new Rfc2898DeriveBytes(lozinka, sBytes, 100);

            return new Tuple<string, string>(Convert.ToBase64String(derivedBytes.GetBytes(256)), salt);
        }
    }
}
