using LicitacijaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Data
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
                    JavnoNadmetanjeId = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    KatastarskaOpstinaId= Guid.Parse("12cfc696-83c6-4d7b-826b-dbe2c32f0b55"),
                    NazivKatastarskeOpstine = "Bački Vinogradi",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("ad7eff33-ae00-44b4-bac0-8013695db944"),
                        Ulica = "Sonje Marinković",
                        Broj = "18",
                        Mesto = "Centar III",
                        PostanskiBroj = "24000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("81e7f36e-1563-4f4f-9f5c-2d6fe5bc3bf1"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = new DateTime(2022, 2, 10),
                   VremePocetka = new DateTime(2022, 2, 10, 9, 0, 0),
                   VremeKraja = new DateTime(2022, 2, 10, 11, 0, 0),
                   PocetnaCenaHektar = 7000,
                   Izuzeto = false,
                   IzlicitiranaCena = 8600,
                   PeriodZakupa = 12,
                   BrojUcesnika = 15,
                   VisinaDopuneDepozita = 200,
                   Krug = 1
                }
            });

            SluzbeniListList.AddRange(new List<SluzbeniListDto>
            {
                new SluzbeniListDto
                {
                    JavnoNadmetanjeId = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    SluzbeniListId= Guid.Parse("ecd3b16b-c48b-482a-8138-6ad2dacfe07f"),
                    Opstina = "Bikovo",
                    BrojSluzbenogLista=1,
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("ad7eff33-ae00-44b4-bac0-8013695db944"),
                        Ulica = "Sonje Marinković",
                        Broj = "18",
                        Mesto = "Centar III",
                        PostanskiBroj = "24000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("81e7f36e-1563-4f4f-9f5c-2d6fe5bc3bf1"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = new DateTime(2022, 2, 10),
                   VremePocetka = new DateTime(2022, 2, 10, 9, 0, 0),
                   VremeKraja = new DateTime(2022, 2, 10, 11, 0, 0),
                   PocetnaCenaHektar = 7000,
                   Izuzeto = false,
                   IzlicitiranaCena = 8600,
                   PeriodZakupa = 12,
                   BrojUcesnika = 15,
                   VisinaDopuneDepozita = 200,
                   Krug = 1
                }
            });

            StatusJavnogNadmetanjaList.AddRange(new List<StatusJavnogNadmetanjaDto>
            {
                new StatusJavnogNadmetanjaDto
                {
                    JavnoNadmetanjeId = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    StatusJavnogNadmetanjaId= Guid.Parse("cbabe629-9b49-4b26-a509-c733715ad6cb"),
                    NazivStatusaJavnogNadmetanja = "Prvi krug",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("ad7eff33-ae00-44b4-bac0-8013695db944"),
                        Ulica = "Sonje Marinković",
                        Broj = "18",
                        Mesto = "Centar III",
                        PostanskiBroj = "24000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("81e7f36e-1563-4f4f-9f5c-2d6fe5bc3bf1"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = new DateTime(2022, 2, 10),
                   VremePocetka = new DateTime(2022, 2, 10, 9, 0, 0),
                   VremeKraja = new DateTime(2022, 2, 10, 11, 0, 0),
                   PocetnaCenaHektar = 7000,
                   Izuzeto = false,
                   IzlicitiranaCena = 8600,
                   PeriodZakupa = 12,
                   BrojUcesnika = 15,
                   VisinaDopuneDepozita = 200,
                   Krug = 1
                }
            });

            TipJavnogNadmetanjaList.AddRange(new List<TipJavnogNadmetanjaDto>
            {
                new TipJavnogNadmetanjaDto
                {
                    JavnoNadmetanjeId = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    TipJavnogNadmetanjaId= Guid.Parse("e64d1a1a-46c1-4d66-aec2-5f0e51eb9932"),
                    NazivTipaJavnogNadmetanja = "Javna licitacija",
                    Adresa = new AdresaDto
                    {
                        AdresaID = Guid.Parse("ad7eff33-ae00-44b4-bac0-8013695db944"),
                        Ulica = "Sonje Marinković",
                        Broj = "18",
                        Mesto = "Centar III",
                        PostanskiBroj = "24000",
                        Drzava = new DrzavaDto
                        {
                            DrzavaID = Guid.Parse("81e7f36e-1563-4f4f-9f5c-2d6fe5bc3bf1"),
                            NazivDrzave = "Srbija"
                        }
                    },
                   Datum = new DateTime(2022, 2, 10),
                   VremePocetka = new DateTime(2022, 2, 10, 9, 0, 0),
                   VremeKraja = new DateTime(2022, 2, 10, 11, 0, 0),
                   PocetnaCenaHektar = 7000,
                   Izuzeto = false,
                   IzlicitiranaCena = 8600,
                   PeriodZakupa = 12,
                   BrojUcesnika = 15,
                   VisinaDopuneDepozita = 200,
                   Krug = 1
                }
            });
        }

        public KatastarskaOpstinaDto GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            return KatastarskaOpstinaList.FirstOrDefault(e => e.KatastarskaOpstinaId == katastarskaOpstinaId);
        }

        public List<KatastarskaOpstinaDto> GetKatastarskaOpstinaList()
        {
            return KatastarskaOpstinaList;
        }

        public SluzbeniListDto GetSluzbeniListById(Guid sluzbeniListId)
        {
            return SluzbeniListList.FirstOrDefault(e => e.SluzbeniListId == sluzbeniListId);
        }

        public List<SluzbeniListDto> GetSluzbeniListList()
        {
            return SluzbeniListList;
        }

        public StatusJavnogNadmetanjaDto GetStatusJavnogNadmetanjaById(Guid statusJavnogNadmetanjaId)
        {
            return StatusJavnogNadmetanjaList.FirstOrDefault(e => e.StatusJavnogNadmetanjaId == statusJavnogNadmetanjaId);
        }

        public List<StatusJavnogNadmetanjaDto> GetStatusJavnogNadmetanjaList()
        {
            return StatusJavnogNadmetanjaList;
        }

        public TipJavnogNadmetanjaDto GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaId)
        {
            return TipJavnogNadmetanjaList.FirstOrDefault(e => e.TipJavnogNadmetanjaId == tipJavnogNadmetanjaId);
        }

        public List<TipJavnogNadmetanjaDto> GetTipJavnogNadmetanjaList()
        {
            return TipJavnogNadmetanjaList;
        }
    }
}
