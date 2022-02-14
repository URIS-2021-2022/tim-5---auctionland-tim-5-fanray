using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class PrioritetRepository : IPrioritetRepository
    {
        private readonly KupacContext Context;

        public PrioritetRepository(KupacContext context)
        {
            this.Context = context;
        }
        public Prioritet GetPrioritetById(Guid prioritetId)
        {
            return Context.Prioritet.FirstOrDefault(e => e.PrioritetId == prioritetId);
        }

        public List<Prioritet> GetPrioritetList()
        {
            return Context.Prioritet.ToList();
        }
    }
}
