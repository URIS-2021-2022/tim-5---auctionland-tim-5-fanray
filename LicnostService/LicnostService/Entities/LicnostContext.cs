using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LicnostService.Entities
{
    public class LicnostContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public LicnostContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Licnost> Licnost { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Predsednik> Predsednik { get; set; }
        public DbSet<Komisija> Komisija { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LicnostDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Licnost>()
                .HasData(
                    new Licnost
                    {
                        LicnostID = Guid.Parse("4a078606-30b2-497e-8650-7330a236e150"),
                        Ime = "Nemanja",
                        Prezime = "Sudarski",
                        Funkcija = ""

                    },
                    new Licnost
                    {
                        LicnostID = Guid.Parse("f45c4d55-00af-4f06-be69-f79e3fa9dcc2"),
                        Ime = "Sofija",
                        Prezime = "Bozic",
                        Funkcija = ""

                    }
            ) ;

            modelBuilder.Entity<Clan>()
                .HasData(
                    new Clan
                    {
                        ClanID = Guid.Parse("17fc842e-54f4-48fe-b189-0fd12d895c9a"),
                        LicnostID=Guid.Parse("4a078606-30b2-497e-8650-7330a236e150")
                        
                    }
            );

            modelBuilder.Entity<Predsednik>()
                .HasData(
                    new Predsednik
                    {
                        PredsednikID = Guid.Parse("8d878d03-fb76-42fc-91a0-5c8d3c36180e"),
                        LicnostID = Guid.Parse("f45c4d55-00af-4f06-be69-f79e3fa9dcc2")

                    }
            );

            modelBuilder.Entity<Komisija>()
                .HasData(
                    new Komisija
                    {
                        KomisijaID = Guid.Parse("8d878d03-fb76-42fc-91a0-5c8d3c36180e"),
                        ClanID = Guid.Parse("17fc842e-54f4-48fe-b189-0fd12d895c9a"),
                        PredsednikID = Guid.Parse("8d878d03-fb76-42fc-91a0-5c8d3c36180e")

                    }
            );
        }
    }
}
