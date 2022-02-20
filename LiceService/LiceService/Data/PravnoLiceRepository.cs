using LiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public class PravnoLiceRepository : IPravnoLiceRepository
    {
        private readonly LiceContext Context;
        public PravnoLiceRepository(LiceContext context)
        {
            this.Context = context;
        }

        public PravnoLice GetPravnoLiceById(Guid pravnoLiceId)
        {
            return Context.PravnoLice.FirstOrDefault(e => e.LiceID == pravnoLiceId);
        }

        public List<PravnoLice> GetPravnoLiceList()
        {
            return Context.PravnoLice.ToList();
        }
    }
}
