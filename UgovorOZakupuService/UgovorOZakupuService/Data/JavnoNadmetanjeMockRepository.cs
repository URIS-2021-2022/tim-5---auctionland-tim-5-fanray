using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Data
{
    public class JavnoNadmetanjeMockRepository : IJavnoNadmetanjeMockRepository
    {
        public List<KatastarskaOpstinaDto> KatastarskaOpstinaList { get; set; } = new List<KatastarskaOpstinaDto>();
        public List<SluzbeniListDto> SluzbeniListList { get; set; } = new List<SluzbeniListDto>();
        public List<StatusJavnogNadmetanjaDto> StatusJavnogNadmetanjaList { get; set; } = new List<StatusJavnogNadmetanjaDto>();
        public List<TipJavnogNadmetanjaDto> TipJavnogNadmetanjaList { get; set; } = new List<TipJavnogNadmetanjaDto>();


        public JavnoNadmetanjeMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            KatastarskaOpstinaList.AddRange(new List<KatastarskaOpstinaDto>
            {
                new KatastarskaOpstinaDto
                {
                    JavnoNadmetanjeID = Guid.Parse("fc9cd8ca-34c7-4e5f-b4e9-e4818e00cad8"),
                    KatastarskaOpstinaID= Guid.Parse("44a3744b-3308-4b75-8515-2611674892f1"),
                    NazivKatastarskeOpstine = "Čantavir",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("f27960a2-476e-44ae-8124-73a84ee3971c"),
                        Ulica = "Bulevar Evrope",
                        Broj = "7",
                        Mesto = "Novi Sad",
                        PostanskiBroj = "21000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("1bff108c-490a-4a99-a24c-c19f8bde048a"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = DateTime.Parse("2021-04-23T12:34:22"),
                   VremePocetka = DateTime.Parse("2021-04-23T13:00:00"),
                   VremeKraja = DateTime.Parse("2021-04-23T18:00:00"),
                   PocetnaCenaHektar = 8300,
                   Izuzeto = false,
                   IzlicitiranaCena = 11000,
                   PeriodZakupa = 24,
                   BrojUcesnika = 11,
                   VisinaDopuneDepozita = 500,
                   Krug = 1
                }
            });

            SluzbeniListList.AddRange(new List<SluzbeniListDto>
            {
                new SluzbeniListDto
                {
                    JavnoNadmetanjeID = Guid.Parse("f983ada7-1432-46b7-88ef-f573be4dc627"),
                    SluzbeniListID  = Guid.Parse("54c15839-f5a5-4b8f-997e-a73a564b60f6"),
                    Opstina = "Čantavir",
                    BrojSluzbenogLista=1,
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("54a4eb2e-a68b-44a9-954f-7835fa944143"),
                        Ulica = "Bulevar Evrope",
                        Broj = "7",
                        Mesto = "Novi Sad",
                        PostanskiBroj = "21000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("cf2bd0ae-233c-4868-a30c-9f2cf92d2f16"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = DateTime.Parse("2021-04-23T12:34:22"),
                   VremePocetka = DateTime.Parse("2021-04-23T13:00:00"),
                   VremeKraja = DateTime.Parse("2021-04-23T18:00:00"),
                   PocetnaCenaHektar = 8300,
                   Izuzeto = false,
                   IzlicitiranaCena = 11000,
                   PeriodZakupa = 24,
                   BrojUcesnika = 11,
                   VisinaDopuneDepozita = 500,
                   Krug = 1
                }
            });

            StatusJavnogNadmetanjaList.AddRange(new List<StatusJavnogNadmetanjaDto>
            {
                new StatusJavnogNadmetanjaDto
                {
                    JavnoNadmetanjeID = Guid.Parse("d8dde8f6-30dc-4066-a839-6606d85bb99c"),
                    StatusJavnogNadmetanjaID= Guid.Parse("34c201a5-10b7-4fb0-bf2c-f624dc3dd67e"),
                    NazivStatusaJavnogNadmetanja = "Prvi krug",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("40ed2d16-8b73-4c1d-bdda-b3cb7469908c"),
                        Ulica = "Bulevar Evrope",
                        Broj = "7",
                        Mesto = "Novi Sad",
                        PostanskiBroj = "21000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("97324ac6-85bd-44dd-a322-b99413721918"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = DateTime.Parse("2021-04-23T12:34:22"),
                   VremePocetka = DateTime.Parse("2021-04-23T13:00:00"),
                   VremeKraja = DateTime.Parse("2021-04-23T18:00:00"),
                   PocetnaCenaHektar = 8300,
                   Izuzeto = false,
                   IzlicitiranaCena = 11000,
                   PeriodZakupa = 24,
                   BrojUcesnika = 11,
                   VisinaDopuneDepozita = 500,
                   Krug = 1
                }
            });

            TipJavnogNadmetanjaList.AddRange(new List<TipJavnogNadmetanjaDto>
            {
                new TipJavnogNadmetanjaDto
                {
                    JavnoNadmetanjeID = Guid.Parse("03e7d90e-5c6e-4972-9455-66f0a4a5176c"),
                    TipJavnogNadmetanjaID = Guid.Parse("a62a5c13-2936-4182-9c61-daddeb4561c6"),
                    NazivTipaJavnogNadmetanja = "Javna licitacija",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("fca6ce4a-ed00-4813-9d00-ce5e0ef501df"),
                        Ulica = "Bulevar Evrope",
                        Broj = "7",
                        Mesto = "Novi Sad",
                        PostanskiBroj = "21000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("7d55988c-420a-495f-8534-5f371311769f"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = DateTime.Parse("2021-04-23T12:34:22"),
                   VremePocetka = DateTime.Parse("2021-04-23T13:00:00"),
                   VremeKraja = DateTime.Parse("2021-04-23T18:00:00"),
                   PocetnaCenaHektar = 8300,
                   Izuzeto = false,
                   IzlicitiranaCena = 11000,
                   PeriodZakupa = 24,
                   BrojUcesnika = 11,
                   VisinaDopuneDepozita = 500,
                   Krug = 1
                }
            });
        }

        public KatastarskaOpstinaDto GetKatastarskaOpstinaById(Guid katastarskaOpstinaID)
        {
            return KatastarskaOpstinaList.FirstOrDefault(e => e.KatastarskaOpstinaID == katastarskaOpstinaID);
        }

        public List<KatastarskaOpstinaDto> GetKatastarskaOpstinaList()
        {
            return KatastarskaOpstinaList;
        }

        public SluzbeniListDto GetSluzbeniListById(Guid sluzbeniListID)
        {
            return SluzbeniListList.FirstOrDefault(e => e.SluzbeniListID == sluzbeniListID);
        }

        public List<SluzbeniListDto> GetSluzbeniListList()
        {
            return SluzbeniListList;
        }

        public StatusJavnogNadmetanjaDto GetStatusJavnogNadmetanjaById(Guid statusJavnogNadmetanjaID)
        {
            return StatusJavnogNadmetanjaList.FirstOrDefault(e => e.StatusJavnogNadmetanjaID == statusJavnogNadmetanjaID);
        }

        public List<StatusJavnogNadmetanjaDto> GetStatusJavnogNadmetanjaList()
        {
            return StatusJavnogNadmetanjaList;
        }

        public TipJavnogNadmetanjaDto GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaID)
        {
            return TipJavnogNadmetanjaList.FirstOrDefault(e => e.TipJavnogNadmetanjaID == tipJavnogNadmetanjaID);
        }

        public List<TipJavnogNadmetanjaDto> GetTipJavnogNadmetanjaList()
        {
            return TipJavnogNadmetanjaList;
        }
    }
}
