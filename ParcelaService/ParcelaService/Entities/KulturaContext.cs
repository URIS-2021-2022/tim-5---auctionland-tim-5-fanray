using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class KulturaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public KulturaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Kultura> KulturaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Kultura>()
                .HasData(
                    new Kultura
                    {
                        KulturaID = Guid.Parse("562d2838-345b-46e0-977e-b1350199e46b"),
                        NazivKulture = "Njive"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("429b3bd9-c9e4-42e5-a94d-dcf10276756d"),
                        NazivKulture = "Vrtovi"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("c52c698e-ab99-4b69-bd7f-80addbd72e10"),
                        NazivKulture = "Voćnjaci"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("d54ae671-92eb-4892-8579-e91ef4a53f3e"),
                        NazivKulture = "Vinogradi"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("a644ca6e-89c2-4b16-84d8-6f5b76909ad2"),
                        NazivKulture = "Livade"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("101395f3-0ab9-4952-a691-530f14fa443d"),
                        NazivKulture = "Pašnjaci"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("fc963149-30b2-4038-b5f0-bdaff5e332c2"),
                        NazivKulture = "Šume"
                    },
                    new Kultura
                    {
                        KulturaID = Guid.Parse("21b610b2-50fd-478e-b649-8d67694618c6"),
                        NazivKulture = "Trstici-močvare"
                    }
            );
        }
    }
}
