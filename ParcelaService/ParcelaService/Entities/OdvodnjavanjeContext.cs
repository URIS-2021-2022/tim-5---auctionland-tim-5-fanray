using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class OdvodnjavanjeContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public OdvodnjavanjeContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Odvodnjavanje> OdvodnjavanjeSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Odvodnjavanje>()
                .HasData(
                    new Odvodnjavanje
                    {
                        OdvodnjavanjeID = Guid.Parse("814f8e70-0edf-4cf5-8729-5091f7590b68"),
                        NazivOdvodnjavanja = "Površinsko odvodnjavanje"
                    },
                    new Odvodnjavanje
                    {
                        OdvodnjavanjeID = Guid.Parse("0f18b42e-3451-426d-8720-cdd50110989b"),
                        NazivOdvodnjavanja = "Podzemno odvodnjavanje"
                    }
            );
        }
    }
}
