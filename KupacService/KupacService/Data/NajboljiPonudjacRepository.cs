using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class NajboljiPonudjacRepository : INajboljiPonudjacRepository
    {
        private readonly KupacContext Context;

        public NajboljiPonudjacRepository(KupacContext context)
        {
            this.Context = context;
        }
        public Najbolji_Ponudjac GetNajbolji_PonudjacById(Guid najboljiPonudjacId)
        {
            return Context.Najbolji_Ponudjac.FirstOrDefault(e => e.NajboljiPonudjacId == najboljiPonudjacId);
        }

        public List<Najbolji_Ponudjac> GetNajbolji_PonudjacList()
        {
            return Context.Najbolji_Ponudjac.ToList();
        }
    }
}
