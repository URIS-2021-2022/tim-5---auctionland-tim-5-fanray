using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class KupacContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public KupacContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<Kupac> Kupac { get; set; }

        public DbSet<Prijavljen_Kupac> Prijavljen_Kupac { get; set; }

        public DbSet<Najbolji_Ponudjac> Najbolji_Ponudjac { get; set; }

        public DbSet<Prioritet> Prioritet { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KupacDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prijavljen_Kupac>()
                .HasData(
                    new Prijavljen_Kupac
                    {
                        PrijavljenKupacId = Guid.Parse("1a1bdf95-8ee1-4998-a78c-360039502626"),
                        KupacId = Guid.Parse("a35d8ec7-4cea-42ec-859e-5c012476ced0")
                    }
                   
            );

            modelBuilder.Entity<Najbolji_Ponudjac>()
                .HasData(
                    new Najbolji_Ponudjac
                    {
                        NajboljiPonudjacId = Guid.Parse("c566ecfd-a27d-4a0b-8032-66fc24754929"),
                        KupacId = Guid.Parse("a35d8ec7-4cea-42ec-859e-5c012476ced0"),
                    }
            );

            modelBuilder.Entity<Prioritet>()
                .HasData(
                    new Prioritet
                    {
                        PrioritetId = Guid.Parse("20e00a61-9e6a-4d6b-9df0-0b85e645849d"),
                        NazivPrioriteta = "Prioritet1"
                    }
            );

            modelBuilder.Entity<Kupac>()
                .HasData(
                    new Kupac
                    {
                        KupacId = Guid.Parse("a35d8ec7-4cea-42ec-859e-5c012476ced0"),
                        PrioritetId = Guid.Parse("608ed376-c4bb-4bdd-84cb-f34147ca96df"),
                        OstvarenaPovrsina  = "200m2",
                        OvlascenoLiceId = Guid.Parse("148805f4-3093-4fd3-aea1-f253038b3c8f"),
                        ImaZabranu = true,
                        DatumPocetkaZabrane = DateTime.Parse("2020-11-15T09:00:00"),
                        DatumTrajanjaZabrane = "1 godinu",
                        DatumPrestankaZabrane = DateTime.Parse("2021-11-15T09:00:00")
                        
                    }
            );
        }
    }
}
