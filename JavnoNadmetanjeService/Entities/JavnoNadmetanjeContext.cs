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
        public DbSet<KatastarskaOpstina> KatastarskaOpstina { get; set; }
        public DbSet<TipJavnogNadmetanja> TipJavnogNadmetanja { get; set; }
        public DbSet<StatusJavnogNadmetanja> StatusJavnogNadmetanja { get; set; }
        public DbSet<SluzbeniList> SluzbeniList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("JavnoNadmetanjeDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KatastarskaOpstina>()
                .HasData(
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("7d03a946-40a3-41e8-8feb-dbe9381d2170"),
                        NazivKatastarskeOpstine = "Čantavir"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("5a20c276-5b98-4e24-92b4-0996cb51b293"),
                        NazivKatastarskeOpstine = "Bački Vinogradi"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("24742b99-32c6-4999-b0a7-757a178f9ee7"),
                        NazivKatastarskeOpstine = "Bikovo"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("55c5e423-e70c-452f-a89f-42c412163b76"),
                        NazivKatastarskeOpstine = "Đuđin"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("714f831b-b86b-443d-abf5-f248694a8b2e"),
                        NazivKatastarskeOpstine = "Žednik"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("835bd51d-80e3-4c28-9e34-3951bac861c7"),
                        NazivKatastarskeOpstine = "Tavankut"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("ddc12930-390b-4e16-8c91-b9259d53bf16"),
                        NazivKatastarskeOpstine = "Bajmok"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("a077a57d-6e63-41c8-a944-c93eb938b8f7"),
                        NazivKatastarskeOpstine = "Donji Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("26831746-3efb-48a5-8cd9-9810db3a75f4"),
                        NazivKatastarskeOpstine = "Stari Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("f0152fa7-8abc-43e9-956d-1eff5a4ace62"),
                        NazivKatastarskeOpstine = "Novi Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaId = Guid.Parse("870742be-2358-45f2-bb1b-1d4efa6bf9d2"),
                        NazivKatastarskeOpstine = "Palić"
                    }
            );

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
