
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class UgovorContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public UgovorContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Ugovor> Ugovor { get; set; }
        public DbSet<Dokument> Dokument { get; set; }
        public DbSet<TipGarancije> TipGarancije { get; set; }
        public DbSet<Rok> Rok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UgovorOZakupuDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipGarancije>()
                .HasData(
                    new TipGarancije
                    {
                        TipGarancijeID = Guid.Parse("8a02b3ef-651c-4893-8c71-8cf5ca4619fe"),
                        NazivTipaG = "Jemstvo"
                    },
                    new TipGarancije
                    {
                        TipGarancijeID = Guid.Parse("d2e52d2e-8c27-49e1-b4e0-4a873a6ca75e"),
                        NazivTipaG = "Bankarska Garancija"
                    },
                    new TipGarancije
                    {
                        TipGarancijeID = Guid.Parse("8d66093b-bffa-4b50-8d94-f1a9dd9a336c"),
                        NazivTipaG = "Garancija nekretninom"
                    },
                    new TipGarancije
                    {
                        TipGarancijeID = Guid.Parse("311eafc9-251d-40ee-835d-d40cedf96caf"),
                        NazivTipaG = "Žirantska"
                    },
                    new TipGarancije
                    {
                        TipGarancijeID = Guid.Parse("14df6d32-8cf8-4516-975d-cbf6f63889ff"),
                        NazivTipaG = "Uplata gotovinom"
                    }
                );
            modelBuilder.Entity<Rok>()
                .HasData(
                    new Rok
                    {
                        RokID = Guid.Parse("34562293-3bb6-4ef3-922f-f9d7d3c57864"),
                        DatumRokaDospeca = DateTime.Parse("2021-03-22T10:00:00")
                    }
                );
            modelBuilder.Entity<Dokument>()
                .HasData(
                    new Dokument
                    {
                        DokumentID = Guid.Parse("6d9bf251-8c70-495f-93bf-ff1e9ad85b88"),
                        ZavodniBrojD = "ROO-1/17",
                        Datum = DateTime.Parse("2020-03-22T10:00:00"),
                        DatumDonosenja = DateTime.Parse("2020-03-22T10:00:00"),
                        Sablon = "Rešenje o obrazovanju stručne komisije za izradu predloga godišnjeg Programa zaštite, uređenja i korišćenja poljoprivrednog zemljišta"
                    },
                    new Dokument

                    {
                        DokumentID = Guid.Parse("6e5dff7a-ea13-4294-8f95-5f258e32f96f"),
                        ZavodniBrojD = "ROO-2/17",
                        Datum = DateTime.Parse("2019-09-15T12:30:00"),
                        DatumDonosenja = DateTime.Parse("2019-09-15T12:30:00"),
                        Sablon = "Rešenje o obrazovanju komisije za davanje mišljenja na godišnji Program zaštite, uređenja i korišćenja poljoprivrednog zemljišta"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("38d906b5-f8d5-4775-b0a1-1edee955193f"),
                        ZavodniBrojD = "ZDS-5/10",
                        Datum = DateTime.Parse("2021-04-12T13:22:31"),
                        DatumDonosenja = DateTime.Parse("2021-04-12T14:30:00"),
                        Sablon = "Zahtev za davanje saglasnosti na godišnji Program zaštite, uređenja i korišćenja poljoprivrednog zemljišta"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("4a807a16-a73f-4f02-944a-0db26fd2fa5e"),
                        ZavodniBrojD = "PZU-3/11",
                        Datum = DateTime.Parse("2020-02-18T10:29:41"),
                        DatumDonosenja = DateTime.Parse("2020-03-01T12:44:51"),
                        Sablon = "Program zaštite, uređenja i korišćenja poljopriverednog zemljišta"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("f80153c4-322b-4eee-b73f-cd450fa8c1cd"),
                        ZavodniBrojD = "ONO-4/14",
                        Datum = DateTime.Parse("2020-09-12T15:12:11"),
                        DatumDonosenja = DateTime.Parse("2020-11-05T12:00:51"),
                        Sablon = "Odluka o određivanju nadležnog organa za sprovođenje postupaka davanja poljoprivrednog zemljišta u zakup"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("af511cdf-cd94-400a-815e-2bf5b329eff2"),
                        ZavodniBrojD = "ROK-7/19",
                        Datum = DateTime.Parse("2021-06-10T14:34:15"),
                        DatumDonosenja = DateTime.Parse("2021-08-05T13:02:50"),
                        Sablon = "Rešenje o obrazovanju Komisije za sprovođenje postupaka davanje poljoprivrednog zemljišta u zakup"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("cb41cfed-1d43-4f45-8971-a91fd9f144a7"),
                        ZavodniBrojD = "POD-7/10",
                        Datum = DateTime.Parse("2022-01-30T11:20:00"),
                        DatumDonosenja = DateTime.Parse("2022-02-05T12:00:12"),
                        Sablon = "Predlog odluke o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("2f1c2288-8255-4128-aa44-91303617bcb8"),
                        ZavodniBrojD = "ONO-4/14",
                        Datum = DateTime.Parse("2020-03-25T08:35:23"),
                        DatumDonosenja = DateTime.Parse("2020-04-15T13:11:23"),
                        Sablon = "Odluka o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini"
                    }
                );
            modelBuilder.Entity<Ugovor>()
                .HasData(
                    new Ugovor
                    {
                        UgovorID = Guid.Parse("0ec914e2-a7a2-4935-ad30-5912fc86fd19"),
                        KorisnikID = Guid.Parse("25862727-de11-49c4-aea2-5431db48f0a5"),
                        ZavodniBroj = "UGV-3/21",
                        DatumZavodjenja = DateTime.Parse("2022-01-18T16:14:33"),
                        RokZaVracanjeZem = DateTime.Parse("2023-04-29T10:00:00"),
                        MestoPotpisivanja = "Beograd",
                        DatumPotpisa = DateTime.Parse("2022-01-23T14:20:57"),
                        JavnoNadmetanjeID = Guid.Parse("84b3ea4c-e02f-41b1-a1ef-2734ef97abb2"),
                        KupacID = Guid.Parse("81037b57-d24c-4d85-9649-7fc6ed635a0c"),
                        LicnostID = Guid.Parse("45aed467-8061-4011-bfc6-3bc4d01b65f9"),
                        DokumentID = Guid.Parse("2f1c2288-8255-4128-aa44-91303617bcb8"),
                        TipGarancijeID = Guid.Parse("8a02b3ef-651c-4893-8c71-8cf5ca4619fe"),
                        RokID = Guid.Parse("34562293-3bb6-4ef3-922f-f9d7d3c57864")
                    }
                );
        }

    }
}
