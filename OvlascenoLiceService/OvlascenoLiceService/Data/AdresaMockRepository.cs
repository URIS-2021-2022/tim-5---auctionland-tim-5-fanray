using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Data
{
    public class AdresaMockRepository : IAdresaMockRepository
    {
        public List<AdresaDto> AdresaList { get; set; } = new List<AdresaDto>();

        public AdresaMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            AdresaList.AddRange(new List<AdresaDto>
            {
                new AdresaDto
                {
                    AdresaID = Guid.Parse("313c6264-668d-4dce-816e-8420709d318f"),
                    Ulica = "Solunska",
                    Broj = "11",
                    Mesto = "Centar I",
                    PostanskiBroj = "24000",
                    Drzava = new DrzavaDto
                    {
                      DrzavaID = Guid.Parse("4e20bcdc-9700-4b72-b6f1-f2c85c017bea"),
                      NazivDrzave = "Srbija"
                    }
                }
            });

            AdresaList.AddRange(new List<AdresaDto>
            {
                new AdresaDto
                {
                    AdresaID = Guid.Parse("92acd446-fc8b-4deb-9ae0-bd09bd8b7d2d"),
                    Ulica = "Njegoseva",
                    Broj = "22",
                    Mesto = "Centar III",
                    PostanskiBroj = "24000",
                    Drzava = new DrzavaDto
                    {
                      DrzavaID = Guid.Parse("4e20bcdc-9700-4b72-b6f1-f2c85c017bea"),
                      NazivDrzave = "Srbija"
                    }
                }
            });
        }

        public List<AdresaDto> GetAdresaList()
        {
            return AdresaList;
        }

        public AdresaDto GetAdresaById(Guid adresaId)
        {
            return AdresaList.FirstOrDefault(e => e.AdresaID == adresaId);
        }
    }
}