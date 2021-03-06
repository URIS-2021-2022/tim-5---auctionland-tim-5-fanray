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
                        NazivRadnjeNaOsnovuZalbe = "JN ide u drugi krug sa novim uslovima"
                    },
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("f0b093b4-b2ea-45e8-99d4-55e0b2d703b7"),
                        NazivRadnjeNaOsnovuZalbe = "JN ide u drugi krug sa starim uslovima"
                    },
                    new RadnjaNaOsnovuZalbe
                    {
                        RadnjaNaOsnovuZalbeID = Guid.Parse("ed7da07e-c1f6-4d4f-882c-d6c4b5118e46"),
                        NazivRadnjeNaOsnovuZalbe = "JN ne ide u drugi krug"
                    }
            );

            modelBuilder.Entity<StatusZalbe>()
                .HasData(
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("567ada34-3b58-4925-9227-7fa1be213f7e"),
                        NazivStatusaZalbe = "Usvojena"
                    },
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("8bb54326-11a9-4f6f-9dca-6afb917ba2bf"),
                        NazivStatusaZalbe = "Odbijena"
                    },
                    new StatusZalbe
                    {
                        StatusZalbeID = Guid.Parse("c6fb5ac5-eaef-4db2-99a5-84a938972183"),
                        NazivStatusaZalbe = "Otvorena"
                    }
            );

            modelBuilder.Entity<TipZalbe>()
                .HasData(
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566"),
                        NazivTipaZalbe = "Žalba na tok javnog nadmetanja"
                    },
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("e3470949-664c-41fc-af1a-6850ff5a7a80"),
                        NazivTipaZalbe = "Žalba na Odluku o davanju u zakup"
                    },
                    new TipZalbe
                    {
                        TipZalbeID = Guid.Parse("7e82c9ce-c998-40c0-b743-6b9456d3629e"),
                        NazivTipaZalbe = "Žalba na Odluku o davanju na korišćenje"
                    }
            );

            modelBuilder.Entity<Zalba>()
                .HasData(
                    new Zalba
                    {
                        ZalbaID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566"),
                        Datum_Podnosenja_Zalbe = DateTime.Parse("2020-11-15T09:00:00"),
                        Razlog_Podnosenja_Zalbe = "Bitna povreda odredaba parničnog postupka",
                        Obrazlozenje = "Neispravno utvređno stanje razgraničenja parcela",
                        Datum_Resenja = DateTime.Parse("2021-01-17T09:00:00"),
                        Broj_Resenja = 13,
                        Broj_Nadmetanja = 53,
                        RadnjaNaOsnovuZalbeID = Guid.Parse("78f43850-ddc4-49ba-b71d-62266a13a164"),
                        StatusZalbeID = Guid.Parse("c6fb5ac5-eaef-4db2-99a5-84a938972183"),
                        TipZalbeID = Guid.Parse("42058551-6a8a-4485-af7f-1124de19e566")
                    }
            );
        }

    }
}