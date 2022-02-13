using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Entities
{
    public class UplataContext : DbContext
    {

        private readonly IConfiguration Configuration;

        public UplataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<Uplata> Uplata { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UplataDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Uplata>()
                .HasData(
                    new Uplata
                    {
                        UplataID = Guid.Parse("44af7348-2f6c-7763-84c7-0d3ddf556dde"),
                        Broj_Racuna = 289451,
                        Poziv_Na_Broj = 54185612,
                        Iznos = 2584,
                        Svrha_Uplate = "Uplata javnog nadmetanja",
                        DatumUplate = DateTime.Parse("2021-01-01 10:03:00"),
                        DatumKursa = DateTime.Parse("2021-01-01 10:03:00"),
                        Valuta= "RSD",
                        Vrednost = 2584
                      
                    }
            );
        }
    }
}