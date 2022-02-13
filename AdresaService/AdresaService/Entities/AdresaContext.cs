using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Entities
{
    public class AdresaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public AdresaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Adresa> Adresa { get; set; }
   
        public DbSet<Drzava> Drzava { get; set; }
        

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AdresaDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasData(
                    new Drzava
                    {
                        DrzavaID = Guid.Parse("a8d29242-7df3-4bfb-be49-48519f65649b"),
                        NazivDrzave = "Srbija"
                    }
                    );
            modelBuilder.Entity<Adresa>()
                .HasData(
                    new Adresa
                    {
                        AdresaID = Guid.Parse("98e5e83e-857f-4930-8b7f-276055d38557"),
                        Ulica = "Bulevar Evrope",
                        Broj = "5",
                        Mesto = "Novi Sad",
                        PostanskiBroj = 21207,
                        DrzavaID = Guid.Parse("a8d29242-7df3-4bfb-be49-48519f65649b")
                    }
            );

        }
    }
}
