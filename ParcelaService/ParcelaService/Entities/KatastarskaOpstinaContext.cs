using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class KatastarskaOpstinaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public KatastarskaOpstinaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<KatastarskaOpstina> KatastarskaOpstinaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KatastarskaOpstina>()
                .HasData(
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("7d03a946-40a3-41e8-8feb-dbe9381d2170"),
                        NazivKatastarskeOpstine = "Čantavir"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("5a20c276-5b98-4e24-92b4-0996cb51b293"),
                        NazivKatastarskeOpstine = "Bački Vinogradi"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("24742b99-32c6-4999-b0a7-757a178f9ee7"),
                        NazivKatastarskeOpstine = "Bikovo"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("55c5e423-e70c-452f-a89f-42c412163b76"),
                        NazivKatastarskeOpstine = "Đuđin"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("714f831b-b86b-443d-abf5-f248694a8b2e"),
                        NazivKatastarskeOpstine = "Žednik"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("835bd51d-80e3-4c28-9e34-3951bac861c7"),
                        NazivKatastarskeOpstine = "Tavankut"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("ddc12930-390b-4e16-8c91-b9259d53bf16"),
                        NazivKatastarskeOpstine = "Bajmok"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("a077a57d-6e63-41c8-a944-c93eb938b8f7"),
                        NazivKatastarskeOpstine = "Donji Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("26831746-3efb-48a5-8cd9-9810db3a75f4"),
                        NazivKatastarskeOpstine = "Stari Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("f0152fa7-8abc-43e9-956d-1eff5a4ace62"),
                        NazivKatastarskeOpstine = "Novi Grad"
                    },
                    new KatastarskaOpstina
                    {
                        KatastarskaOpstinaID = Guid.Parse("870742be-2358-45f2-bb1b-1d4efa6bf9d2"),
                        NazivKatastarskeOpstine = "Palić"
                    }
            );
        }
    }
}
