using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class KlasaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public KlasaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Klasa> KlasaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Klasa>()
                .HasData(
                    new Klasa
                    {
                        KlasaID = Guid.Parse("5c3ad689-4409-4e4d-8e93-fd452776c770"),
                        NazivKlase = "I"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("5af4b60e-1aaa-46c8-a4a0-550e602e633a"),
                        NazivKlase = "II"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("7cfbb7c4-6a83-4a69-bc73-5cacca0c01fd"),
                        NazivKlase = "III"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("4a0f4309-15ed-428b-b1a6-67245d316739"),
                        NazivKlase = "IV"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("2c063dc7-fc37-4071-a1be-60f574184909"),
                        NazivKlase = "V"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("480a44e0-dc28-4d2b-8013-96326d0f9982"),
                        NazivKlase = "VI"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("ae9b7c8e-3f80-43b6-bc97-14f50bee4fb7"),
                        NazivKlase = "VII"
                    },
                    new Klasa
                    {
                        KlasaID = Guid.Parse("a95ea9b3-4eef-495e-9bcd-3ede006d7609"),
                        NazivKlase = "VIII"
                    }
            );
        }
    }
}
