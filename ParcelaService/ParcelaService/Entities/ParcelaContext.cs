using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ParcelaService.Entities
{
    public class ParcelaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ParcelaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Parcela> ParcelaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ParcelaDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Parcela>()
                .HasData(
                    new Parcela
                    {
                        ParcelaID = Guid.Parse("ae463837-b971-4354-9f40-92cc819edf25"),
                        KorisnikParceleID = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                        Povrsina = 100,
                        BrojParcele = "PC-2601",
                        KatastarskaOpstinaID = Guid.Parse("870742be-2358-45f2-bb1b-1d4efa6bf9d2"),
                        BrojListaNepokretnosti = "LN101",
                        KulturaID = Guid.Parse("a644ca6e-89c2-4b16-84d8-6f5b76909ad2"),
                        KlasaID = Guid.Parse("5c3ad689-4409-4e4d-8e93-fd452776c770"),
                        ObradivostID = Guid.Parse("9e1a4745-8838-4130-8662-4337d153a5fd"),
                        ZasticenaZonaID = Guid.Parse("308a9704-2235-4310-9092-9cde4a40164b"),
                        OblikSvojineID = Guid.Parse("84226e05-ec99-4c6c-827f-f0ccf63a0990"),
                        OdvodnjavanjeID = Guid.Parse("0f18b42e-3451-426d-8720-cdd50110989b"),
                        KulturaStvarnoStanje = "",
                        KlasaStvarnoStanje = "",
                        ObradivostStvarnoStanje = "",
                        ZasticenaZonaStvarnoStanje = "",
                        OdvodnjavanjeStvarnoStanje = ""
                    }
            );
        }
    }
}
