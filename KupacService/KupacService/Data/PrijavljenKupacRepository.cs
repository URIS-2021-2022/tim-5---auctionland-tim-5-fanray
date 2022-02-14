using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class PrijavljenKupacRepository : IPrijavljeniKupacRepository
    {
        private readonly KupacContext Context;

        public PrijavljenKupacRepository(KupacContext context)
        {
            this.Context = context;
        }
        public Prijavljen_Kupac GetPrijavljen_KupacById(Guid prijavljenKupacId)
        {
            return Context.Prijavljen_Kupac.FirstOrDefault(e => e.PrijavljenKupacId == prijavljenKupacId);
        }

        public List<Prijavljen_Kupac> GetPrijavljen_KupacList()
        {
            return Context.Prijavljen_Kupac.ToList();
        }
    }
}
