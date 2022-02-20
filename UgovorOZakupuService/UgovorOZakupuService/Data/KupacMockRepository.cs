using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Data
{
    public class KupacMockRepository : IKupacMockRepository
    {
        public List<PrijavljeniKupacDto> PrijavljeniKupacList { get; set; } = new List<PrijavljeniKupacDto>();
        public List<NajboljiPonudjacDto> NajboljiPonudjacList { get; set; } = new List<NajboljiPonudjacDto>();
        public List<PrioritetDto> PrioritetList { get; set; } = new List<PrioritetDto>();


        public KupacMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            PrijavljeniKupacList.AddRange(new List<PrijavljeniKupacDto>
            {
                new PrijavljeniKupacDto
                {
                   KupacID = Guid.Parse("5d71cfa3-7ebc-4ea0-a55e-c7547a724d75"),
                   PrijavljeniKupacID= Guid.Parse("ea16bb54-9826-466d-aa86-75628a9822ec"),
                   OstvarenaPovrsina = "20ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2021-04-23T13:00:00"),
                   TrajanjaZabraneUGod = "1 godina",
                   DatumPrestankaZabrane = DateTime.Parse("2022-04-23T13:00:00")
                }
            });

            NajboljiPonudjacList.AddRange(new List<NajboljiPonudjacDto>
            {
                new NajboljiPonudjacDto
                {
                   KupacID = Guid.Parse("e0bf5b99-cb3d-4d49-8f31-0907dce95b28"),
                   NajboljiPonudjacID= Guid.Parse("7d421f2b-852f-40fb-8989-a3c78273c3b5"),
                   OstvarenaPovrsina = "100ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2020-08-09T12:05:46"),
                   TrajanjaZabraneUGod = "3 godine",
                   DatumPrestankaZabrane = DateTime.Parse("2023-08-09T12:05:46")
                }
            });

            PrioritetList.AddRange(new List<PrioritetDto>
            {
                new PrioritetDto
                {
                   KupacID = Guid.Parse("c91f8eed-e743-4795-9706-c2b24df8fd98"),
                   PrioritetID= Guid.Parse("3f843462-c00e-4b97-ba4a-c2e46051d138"),
                   OstvarenaPovrsina = "80ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2019-05-19T10:25:46"),
                   TrajanjaZabraneUGod = "2 godine",
                   DatumPrestankaZabrane = DateTime.Parse("2021-05-19T12:25:46")
                }
            });
        }

        public PrijavljeniKupacDto GetPrijavljeniKupacById(Guid prijavljeniKupacID)
        {
            return PrijavljeniKupacList.FirstOrDefault(e => e.PrijavljeniKupacID == prijavljeniKupacID);
        }

        public List<PrijavljeniKupacDto> GetPrijavljeniKupacList()
        {
            return PrijavljeniKupacList;
        }

        public NajboljiPonudjacDto GetNajboljiPonudjacById(Guid najboljiPonudjacID)
        {
            return NajboljiPonudjacList.FirstOrDefault(e => e.NajboljiPonudjacID == najboljiPonudjacID);
        }

        public List<NajboljiPonudjacDto> GetNajboljiPonudjacList()
        {
            return NajboljiPonudjacList;
        }

        public PrioritetDto GetPrioritetById(Guid prioritetID)
        {
            return PrioritetList.FirstOrDefault(e => e.PrioritetID == prioritetID);
        }

        public List<PrioritetDto> GetPrioritetList()
        {
            return PrioritetList;
        }

    }
}
