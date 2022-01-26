using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class DeoParceleContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DeoParceleContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<DeoParcele> DeoParceleSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DeoParcele>()
                .HasData(
                    new DeoParcele
                    {
                        DeoParceleID = Guid.Parse("bdafb306-0e28-4dd3-ad97-14532d86552c"),
                        ParcelaID = Guid.Parse("ae463837-b971-4354-9f40-92cc819edf25"),
                        NazivDelaParcele = "Pored puta"
                    }
            );
        }
    }
}
