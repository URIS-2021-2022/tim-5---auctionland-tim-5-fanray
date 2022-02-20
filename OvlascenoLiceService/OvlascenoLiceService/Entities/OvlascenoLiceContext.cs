using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace OvlascenoLiceService.Entities
{
    public class OvlascenoLiceContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public OvlascenoLiceContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<OvlascenoLice> OvlascenoLice { get; set; }
        public DbSet<BrojTable> BrojTable { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("OvlascenoLiceDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrojTable>()
                .HasData(
                    new BrojTable
                    {
                        BrojTableID = Guid.Parse("206a4efa-5389-41a8-a730-4df3842cf7fe"),
                        Broj_Table = "255"
                    },
                    new BrojTable
                    {
                        BrojTableID = Guid.Parse("0f8c16a6-0503-4871-a454-8ac3f9cb7e07"),
                        Broj_Table = "356"
                    },
                    new BrojTable
                    {
                        BrojTableID = Guid.Parse("aad4011e-d00a-49c0-ac13-27f485621e7e"),
                        Broj_Table = "143"
                    }
            );

            modelBuilder.Entity<OvlascenoLice>()
                .HasData(
                    new OvlascenoLice
                    {
                        OvlascenoLiceID = Guid.Parse("d041c26e-34c1-4c2d-a9f6-0c0478f3f437"),
                        Ime = "Milos",
                        Prezime = "Jovanovic",
                        JMBG = "1007990171500",
                        BrojPasosa = "BP0710",
                        BrojTableID = Guid.Parse("206a4efa-5389-41a8-a730-4df3842cf7fe"),
                        DrzavaID = Guid.Parse("bb9c4ebc-2028-4a83-88d7-04422ab58548")
                    }
            );
        }
    }
}