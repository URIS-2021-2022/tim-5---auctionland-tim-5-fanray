using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ZalbaService.Entities
{
    public class ZalbaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ZalbaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Zalba> Zalba { get; set; }
        public DbSet<RadnjaNaOsnovuZalbe> RadnjaNaOsnovuZalbe { get; set; }
        public DbSet<StatusZalbe> StatusZalbe { get; set; }
        public DbSet<TipZalbe> TipZalbe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ZalbaDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RadnjaNaOsnovuZalbe>()
                .HasData(
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("78f43850-ddc4-49ba-b71d-62266a13a164"),
                        NazivRadnjeNaOsnovuZalbe = "Ponovo pokrenut postupak"
                    },
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("f0b093b4-b2ea-45e8-99d4-55e0b2d703b7"),
                        NazivRadnjeNaOsnovuZalbe = "Zatvaranje postupka"
                    },
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("ed7da07e-c1f6-4d4f-882c-d6c4b5118e46"),
                        NazivRadnjeNaOsnovuZalbe = "Preusmeravanje predmeta na viši nivo"
                    },
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("2c08f0ac-532d-49fb-baaa-ab175c1130f8"),
                        NazivRadnjeNaOsnovuZalbe = "Privremeno obustavljanje aktivnosti"
                    }
            );

            modelBuilder.Entity<StatusZalbe>()
                .HasData(
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("567ada34-3b58-4925-9227-7fa1be213f7e"),
                        NazivStatusaZalbe = "U razmatranju"
                    },
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("8bb54326-11a9-4f6f-9dca-6afb917ba2bf"),
                        NazivStatusaZalbe = "Odbijena"
                    },
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("c6fb5ac5-eaef-4db2-99a5-84a938972183"),
                        NazivStatusaZalbe = "Prihvaćena"
                    },
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("1c7dd989-39c3-4802-8c1d-b1f29a36d3bb"),
                        NazivStatusaZalbe = "Ponovno poslata na razmatranje"
                    }
            );

            modelBuilder.Entity<TipZalbe>()
                .HasData(
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566"),
                        NazivTipaZalbe = "Granice ispitivanja prvostepene odluke"
                    },
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("e3470949-664c-41fc-af1a-6850ff5a7a80"),
                        NazivTipaZalbe = "Pogrešno utvrđeno činjenično stanje"
                    },
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("7e82c9ce-c998-40c0-b743-6b9456d3629e"),
                        NazivTipaZalbe = "Nepotpuno utvrđeno činjenično stanje"
                    }
            );

            modelBuilder.Entity<Zalba>()
                .HasData(
                    new Zalba
                    {
                        ZalbaID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566"),
                        RadnjaNaOsnovuZalbeID = Guid.Parse("2c08f0ac-532d-49fb-baaa-ab175c1130f8"),
                        StatusZalbeID = Guid.Parse("c6fb5ac5-eaef-4db2-99a5-84a938972183"),
                        TipZalbeID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566"),
                        Datum_Podnosenja_Zalbe = DateTime.Parse("2020-11-15T09:00:00"),
                        Razlog_Podnosenja_Zalbe = "Bitna povreda odredaba parničnog postupka",
                        Obrazlozenje = "Neispravno utvređno stanje razgraničenja parcela",
                        Datum_Resenja = DateTime.Parse("2021-01-17T09:00:00"),
                        Broj_Resenja = 13,
                        Broj_Nadmetanja = 53
                    }
            );
        }

    }
}