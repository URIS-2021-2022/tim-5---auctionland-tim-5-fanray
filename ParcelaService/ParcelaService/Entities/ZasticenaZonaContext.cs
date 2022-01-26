using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class ZasticenaZonaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ZasticenaZonaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<ZasticenaZona> ZasticenaZonaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ZasticenaZona>()
                .HasData(
                    new ZasticenaZona
                    {
                        ZasticenaZonaID = Guid.Parse("70c4f5fe-694f-4879-84ca-de5744bbd967"),
                        NazivZasticeneZone = "1"
                    },
                    new ZasticenaZona
                    {
                        ZasticenaZonaID = Guid.Parse("7801b5f4-63ef-4990-b039-efa5afc22d1d"),
                        NazivZasticeneZone = "2"
                    },
                    new ZasticenaZona
                    {
                        ZasticenaZonaID = Guid.Parse("308a9704-2235-4310-9092-9cde4a40164b"),
                        NazivZasticeneZone = "3"
                    },
                    new ZasticenaZona
                    {
                        ZasticenaZonaID = Guid.Parse("25fb6ccc-6713-44e3-8234-44d680fc1b5f"),
                        NazivZasticeneZone = "4"
                    }
            );
        }
    }
}
