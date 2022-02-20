using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanjeContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public JavnoNadmetanjeContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<JavnoNadmetanje> JavnoNadmetanje { get; set; }
        public DbSet<TipJavnogNadmetanja> TipJavnogNadmetanja { get; set; }
        public DbSet<StatusJavnogNadmetanja> StatusJavnogNadmetanja { get; set; }
        public DbSet<SluzbeniList> SluzbeniList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("JavnoNadmetanjeDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipJavnogNadmetanja>()
                .HasData(
                    new TipJavnogNadmetanja
                    {
                        TipJavnogNadmetanjaId = Guid.Parse("bc679089-e19f-43e4-946f-651ffbdb2afb"),
                        NazivTipaJavnogNadmetanja = "Javna licitacija"
                    },
                    new TipJavnogNadmetanja
                    {
                        TipJavnogNadmetanjaId = Guid.Parse("d7a80343-d802-43d6-b128-79ba8554acd2"),
                        NazivTipaJavnogNadmetanja = "Otvaranje zatvorenih ponuda"
                    }
            );

            modelBuilder.Entity<StatusJavnogNadmetanja>()
                .HasData(
                    new StatusJavnogNadmetanja
                    {
                        StatusJavnogNadmetanjaId = Guid.Parse("167a01c0-2e68-46a8-b201-3a23e3a20bff"),
                        NazivStatusaJavnogNadmetanja = "Prvi krug"
                    },
                    new StatusJavnogNadmetanja
                    {
                        StatusJavnogNadmetanjaId = Guid.Parse("f876fbcc-a7d0-49f8-b6ef-9b5a59c44fa0"),
                        NazivStatusaJavnogNadmetanja = "Drugi krug sa starim uslovima"
                    },
                    new StatusJavnogNadmetanja
                    {
                        StatusJavnogNadmetanjaId = Guid.Parse("cb5b3279-811c-4ca4-abaa-69016ba157b6"),
                        NazivStatusaJavnogNadmetanja = "Drugi krug sa novim uslovima"
                    }
            );

            modelBuilder.Entity<JavnoNadmetanje>()
                .HasData(
                    new JavnoNadmetanje
                    {
                        JavnoNadmetanjeId = Guid.Parse("1ae8137b-1674-4c91-a4b5-87a133f5dd87"),
                        TipJavnogNadmetanjaId = Guid.Parse("bc679089-e19f-43e4-946f-651ffbdb2afb"),
                        StatusJavnogNadmetanjaId = Guid.Parse("167a01c0-2e68-46a8-b201-3a23e3a20bff"),
                        KatastarskaOpstinaId = Guid.Parse("24742b99-32c6-4999-b0a7-757a178f9ee7"),
                        Datum = new DateTime(2022, 2, 10),
                        VremePocetka = new DateTime(2022, 2, 10, 9, 0, 0),
                        VremeKraja = new DateTime(2022, 2, 10, 11, 0, 0),
                        PocetnaCenaHektar = 7000,
                        Izuzeto = false,
                        IzlicitiranaCena = 8600,
                        PeriodZakupa = 12,
                        BrojUcesnika = 15,
                        VisinaDopuneDepozita = 200,
                        Krug = 1
                    }
            );

            modelBuilder.Entity<SluzbeniList>()
                .HasData(
                    new SluzbeniList
                    {
                        SluzbeniListId = Guid.Parse("496ac934-a718-43a6-ac7f-8db141478180"),
                        Opstina = "Bikovo",
                        BrojSluzbenogLista = "5/2022",
                        DatumIzdavanja = new DateTime(2022, 2, 5),
                        JavnoNadmetanjeId = Guid.Parse("1ae8137b-1674-4c91-a4b5-87a133f5dd87")
                    }
            );


        }
    }
}
