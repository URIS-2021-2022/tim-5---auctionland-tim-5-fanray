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


    }
}
