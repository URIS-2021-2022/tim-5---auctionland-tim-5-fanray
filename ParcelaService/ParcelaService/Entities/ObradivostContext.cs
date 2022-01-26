using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class ObradivostContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ObradivostContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Obradivost> ObradivostSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Obradivost>()
                .HasData(
                    new Obradivost
                    {
                        ObradivostID = Guid.Parse("9e1a4745-8838-4130-8662-4337d153a5fd"),
                        NazivObradivosti = "Obradivo"
                    },
                    new Obradivost
                    {
                        ObradivostID = Guid.Parse("8a8d331a-3553-4de1-a8aa-c4a70e5b7765"),
                        NazivObradivosti = "Ostalo"
                    }
            );
        }
    }
}
