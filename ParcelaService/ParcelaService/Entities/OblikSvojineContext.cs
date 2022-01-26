using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class OblikSvojineContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public OblikSvojineContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<OblikSvojine> OblikSvojineSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OblikSvojine>()
                .HasData(
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("84226e05-ec99-4c6c-827f-f0ccf63a0990"),
                        NazivOblikaSvojine = "Privatna svojina"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("36e7d2b4-188a-4560-8325-c8b591afcce4"),
                        NazivOblikaSvojine = "Državna svojina RS"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("2994163c-e08a-4647-996b-86eda5e0be7a"),
                        NazivOblikaSvojine = "Državna svojina"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("4938990b-fee0-464f-8fa7-835a0d1e71e1"),
                        NazivOblikaSvojine = "Društvena svojina"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("38f76c13-8b55-45f6-bf1a-7adfa9007aba"),
                        NazivOblikaSvojine = "Zadružna svojina"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("cf1e7bd8-2a93-4a08-9768-57e172643630"),
                        NazivOblikaSvojine = "Mešovita svojina"
                    },
                    new OblikSvojine
                    {
                        OblikSvojineID = Guid.Parse("718462dc-15e4-4dce-81cf-e150ce5846bd"),
                        NazivOblikaSvojine = "Drugi oblici"
                    }
            );
        }
    }
}
