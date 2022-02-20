using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class LiceContext : DbContext
    {


        private readonly IConfiguration Configuration;

        public LiceContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<Lice> Lice { get; set; }

        public DbSet<FizickoLice> FizickoLice { get; set; }

        public DbSet<PravnoLice> PravnoLice { get; set; }

        public DbSet<KontaktOsoba> KontaktOsoba { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LiceDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Lice>()
                .HasData(
                    new Lice
                    {
                        LiceID = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                        Broj_Telefona1 = 0654488522,
                        Broj_Telefona2 = 0654488521,
                        Email = "nekolice@gmail.com",
                        Broj_Racuna = 123456789

                    },
                    new Lice
                    {
                        LiceID = Guid.Parse("e7c1316d-5805-4d2b-be96-f764f0247acc"),
                        Broj_Telefona1 = 0614188522,
                        Broj_Telefona2 = 0624489521,
                        Email = "nekolice99@gmail.com",
                        Broj_Racuna = 987456123

                    }
            );

            modelBuilder.Entity<FizickoLice>()
                .HasData(
                    new FizickoLice
                    {
                        JMBG = Guid.Parse("18dca15b-188f-49f9-b4db-ece15575995a"),
                        Ime = "Marko",
                        Prezime = "Markovic",                
                        LiceID = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")

                    }
            );

            modelBuilder.Entity<PravnoLice>()
                .HasData(
                    new PravnoLice
                    {
                        MaticniBroj = Guid.Parse("ffc4407f-68a8-4d74-a48d-17389cc3f01f"),
                        Naziv = "Firma1",
                        LiceID = Guid.Parse("e7c1316d-5805-4d2b-be96-f764f0247acc")

                    }
            );

            modelBuilder.Entity<KontaktOsoba>()
                .HasData(
                    new KontaktOsoba
                    {
                        KontaktOsobaID = Guid.Parse("a43a31f7-ffad-4aff-a199-1a6d31a8b850"),                     
                        Ime = "Petar",
                        Prezime = "Petrovic",
                        Funkcija = "Generalni direktor",
                        Telefon = "0658899471",
                        Maticni_Broj = Guid.Parse("ffc4407f-68a8-4d74-a48d-17389cc3f01f")
                    }
            );
        }
    }
}


