using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class OvlascenoLiceMockRepository : IOvlascenoLiceMockRepository
    {
        public List<OvlascenoLiceDto> OvlascenoLiceList { get; set; } = new List<OvlascenoLiceDto>();

        public OvlascenoLiceMockRepository()
        {
            FillData();
        }
        private void FillData()
        {
            OvlascenoLiceList.AddRange(new List<OvlascenoLiceDto>
            {
                new OvlascenoLiceDto
                {
                    OvlascenoLiceID = Guid.Parse("d041c26e-34c1-4c2d-a9f6-0c0478f3f437"),
                    Ime = "Milos",
                    Prezime = "Jovanovic",
                    JMBG = "1007990171500",
                    BrojPasosa = "BP0710",
                    BrojTable = new BrojTableDto
                    {
                        BrojTableID = Guid.Parse("aad4011e-d00a-49c0-ac13-27f485621e7e"),
                        Broj_Table = "143"
                    },
                    Drzava = new DrzavaDto
                    {
                        DrzavaID = Guid.Parse("bb9c4ebc-2028-4a83-88d7-04422ab58548"),
                        NazivDrzave = "Srbija"
                    }

                }
            });
        }

        public OvlascenoLiceDto GetOvlascenoLiceById(Guid ovlascenoLiceId)
        {
            return OvlascenoLiceList.FirstOrDefault(e => e.OvlascenoLiceID == ovlascenoLiceId);
        }

        public List<OvlascenoLiceDto> GetOvlascenoLiceList()
        {
            return OvlascenoLiceList;
        }
    }
}
