using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Data
{
    public class LiceMockRepository : ILiceMockRepository
    {
        public List<FizickoLiceDto> FizickoLiceList { get; set; } = new List<FizickoLiceDto>();
        public List<PravnoLiceDto> PravnoLiceList { get; set; } = new List<PravnoLiceDto>();

        public LiceMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            FizickoLiceList.AddRange(new List<FizickoLiceDto> 
            { 
                new FizickoLiceDto
                {
                    LiceID = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    Ime = "Marko",
                    Prezime = "Marković",
                    JMBG = "1122999123123",
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
                    BrojTelefona1 = "+381611234567",
                    BrojTelefona2 = "",
                    Email = "markomarkovic@gmail.com",
                    BrojRacuna = "24987123"
                }
            });

            PravnoLiceList.AddRange(new List<PravnoLiceDto>
            {
                new PravnoLiceDto
                {
                    LiceID = Guid.Parse("efb3be0f-7082-4998-858d-51340d2abbab"),
                    Naziv = "Agro",
                    MaticniBroj = "345123",
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
                    KontaktOsoba = new KontaktOsobaDto
                    {
                        KontaktOsobaID = Guid.Parse("5aef69ca-4581-4d6a-a359-4b6a6792213a"),
                        Ime = "Ivana",
                        Prezime = "Ivanovic",
                        Funkcija = "Generalni direktor",
                        Telefon = "+381631234567"
                    },
                    BrojTelefona1 = "+381614567123",
                    BrojTelefona2 = "",
                    Email = "info@agro.com",
                    BrojRacuna = "24123987"
                }
            });
        }

        public List<FizickoLiceDto> GetFizickoLiceList()
        {
            return FizickoLiceList;
        }

        public FizickoLiceDto GetFizickoLiceById(Guid liceId)
        {
            return FizickoLiceList.FirstOrDefault(e => e.LiceID == liceId);
        }

        public List<PravnoLiceDto> GetPravnoLiceList()
        {
            return PravnoLiceList;
        }

        public PravnoLiceDto GetPravnoLiceById(Guid liceId)
        {
            return PravnoLiceList.FirstOrDefault(e => e.LiceID == liceId);
        }
    }
}
