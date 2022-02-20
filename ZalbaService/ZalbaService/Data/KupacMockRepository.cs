using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Models;

namespace ZalbaService.Data
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
                   KupacID = Guid.Parse("751b922b-54ed-4cfc-8f3b-a2033c781378"),
                   PrijavljeniKupacID= Guid.Parse("c88fd21d-1d8b-4fff-9243-4d652177a411"),
                   OstvarenaPovrsina = "15ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2018-07-10T13:00:00"),
                   TrajanjaZabraneUGod = "4 godine",
                   DatumPrestankaZabrane = DateTime.Parse("2022-07-10T13:00:00")
                }
            });

            NajboljiPonudjacList.AddRange(new List<NajboljiPonudjacDto>
            {
                new NajboljiPonudjacDto
                {
                   KupacID = Guid.Parse("37084d30-daf2-4c35-b8b0-6448a7726d57"),
                   NajboljiPonudjacID= Guid.Parse("216c1074-3d0d-43ed-93ad-331a3acfb116"),
                   OstvarenaPovrsina = "20ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2010-10-10T12:05:46"),
                   TrajanjaZabraneUGod = "10 godina",
                   DatumPrestankaZabrane = DateTime.Parse("2020-10-10T12:05:46")
                }
            });

            PrioritetList.AddRange(new List<PrioritetDto>
            {
                new PrioritetDto
                {
                   KupacID = Guid.Parse("0b551160-411a-43d6-9652-8fc2686e4184"),
                   PrioritetID= Guid.Parse("2757b8df-4f3c-4ba6-b8be-e177480fbc22"),
                   OstvarenaPovrsina = "150ha",
                   ImaZabranu = true,
                   DatumPocetkaZabrane = DateTime.Parse("2016-05-02T10:25:46"),
                   TrajanjaZabraneUGod = "5 godina",
                   DatumPrestankaZabrane = DateTime.Parse("2021-05-02T12:25:46")
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
