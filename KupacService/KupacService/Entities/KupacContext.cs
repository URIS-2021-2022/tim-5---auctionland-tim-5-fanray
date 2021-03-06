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

        public DbSet<PrijavljenKupac> Prijavljen_Kupac { get; set; }

        public DbSet<NajboljiPonudjac> Najbolji_Ponudjac { get; set; }

        public DbSet<Prioritet> Prioritet { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KupacDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrijavljenKupac>()
                .HasData(
                    new PrijavljenKupac
                    {
                        PrijavljenKupacId = Guid.Parse("1a1bdf95-8ee1-4998-a78c-360039502626"),
                        KupacId = Guid.Parse("a35d8ec7-4cea-42ec-859e-5c012476ced0")
                    }
                   
            );

            modelBuilder.Entity<NajboljiPonudjac>()
                .HasData(
                    new NajboljiPonudjac
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
                        OvlascenoLiceId = Guid.Parse("d041c26e-34c1-4c2d-a9f6-0c0478f3f437"),
                        ImaZabranu = true,
                        DatumPocetkaZabrane = DateTime.Parse("2020-11-15T09:00:00"),
                        DatumTrajanjaZabrane = "1 godinu",
                        DatumPrestankaZabrane = DateTime.Parse("2021-11-15T09:00:00")
                        
                    }
            );
        }
    }
}
