using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class LiceContext : DbContext
    {


        private readonly IConfiguration Configuration;

        public LiceContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<Lice> Lice { get; set; }

        public DbSet<FizickoLice> FizickoLice { get; set; }

        public DbSet<PravnoLice> PravnoLice { get; set; }

        public DbSet<KontaktOsoba> KontaktOsoba { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LiceDB"));
        }

       
    }
}