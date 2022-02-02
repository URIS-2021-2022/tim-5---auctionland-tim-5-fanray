using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LicitacijaService.Entities
{
    public class LicitacijaContext : DbContext
    {

        private readonly IConfiguration Configuration;

        public LicitacijaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<Licitacija> Licitacija { get; set; }

        public DbSet<Dokumentacija> Dokumentacija { get; set; }

        public DbSet<DokumentacijaZaFizickoLice> DokumentacijaZaFizickoLice { get; set; }

        public DbSet<DokumentacijaZaPravnoLice> DokumentacijaZaPravnoLice { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LicitacijaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dokumentacija>()
                .HasData(
                    new Dokumentacija
                    {
                        DokumentacijaID = Guid.Parse("f1247d53-334e-433f-84dd-b67a3660a269"),
                        NazivDokumentacije = "Dokumentacija1"
                    },
                    new Dokumentacija
                    {
                        DokumentacijaID = Guid.Parse("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa"),
                        NazivDokumentacije = "Dokumentacija2"
                    },
                    new Dokumentacija
                    {
                        DokumentacijaID = Guid.Parse("4cc35a36-46cc-4115-bc4b-a580e20cd23f"),
                        NazivDokumentacije = "Dokumentacija3"
                    },
                    new Dokumentacija
                    {
                        DokumentacijaID = Guid.Parse("d8695c8d-ce0f-40be-a7b4-82042c223e39"),
                        NazivDokumentacije = "Dokumentacija4"
                    }
            );

            builder.Entity<DokumentacijaZaFizickoLice>()
                .HasData(
                    new DokumentacijaZaFizickoLice
                    {
                        DokumentacijaFlID = Guid.Parse("050c3e3d-0698-48a3-a1c5-eda9dc448da5"),
                        DokumentacijaID = Guid.Parse("f1247d53-334e-433f-84dd-b67a3660a269"),
                    },
                    new DokumentacijaZaFizickoLice
                    {
                        DokumentacijaFlID = Guid.Parse("edc4ee98-a0b1-4386-a8b5-be436ef5bb2a"),
                        DokumentacijaID = Guid.Parse("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa"),
                    }
            );

            builder.Entity<DokumentacijaZaPravnoLice>()
                .HasData(
                    new DokumentacijaZaPravnoLice
                    {
                        DokumentacijaPlID = Guid.Parse("20e00a61-9e6a-4d6b-9df0-0b85e645849d"),
                        DokumentacijaID = Guid.Parse("4cc35a36-46cc-4115-bc4b-a580e20cd23f"),
                    },
                    new DokumentacijaZaPravnoLice
                    {
                        DokumentacijaPlID = Guid.Parse("975f85c2-79d4-483d-a520-2aad03b9e215"),
                        DokumentacijaID = Guid.Parse("d8695c8d-ce0f-40be-a7b4-82042c223e39"),
                    }
            );

            builder.Entity<Licitacija>()
                .HasData(
                    new Licitacija
                    {
                        LicitacijaID = Guid.Parse("50af7348-2f6c-4763-84c7-0d9ddf556dde"),
                        DokumentacijaID = Guid.Parse("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa"),
                        Broj = 1,
                        Godina = 2022,
                        Datum = DateTime.Parse("2020-11-15T09:00:00"),
                        Ogranicenje = "",
                        KorakCene = "",
                        RokZaPrijavu = DateTime.Parse("2020-12-20T09:00:00")
                    }
            );
        }
    }
}
