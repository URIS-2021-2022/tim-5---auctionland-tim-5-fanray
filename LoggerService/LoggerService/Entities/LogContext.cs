using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LoggerService.Entities
{
    public class LogContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public LogContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LoggerDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime log = DateTime.Now;

            modelBuilder.Entity<Log>()
                .HasData(
                    new Log
                    {
                        LogID = Guid.Parse("d592cc56-f9ec-484d-b082-e8ae655b586c"),
                        Opis = "Logger je inicijalizovan u bazi podataka",
                        DatumKreiranja = log.Date.ToString(),
                        VremeKreiranja = log.TimeOfDay.ToString()
                    }
            );
        }
    }
}
