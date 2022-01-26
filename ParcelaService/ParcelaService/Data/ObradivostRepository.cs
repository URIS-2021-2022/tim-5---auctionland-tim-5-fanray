using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ObradivostRepository : IObradivostRepository
    {
        private readonly ObradivostContext Context;

        public ObradivostRepository(ObradivostContext context)
        {
            this.Context = context;
        }

        public List<Obradivost> GetObradivostList()
        {
            return Context.ObradivostSet.ToList();
        }

        public Obradivost GetObradivostById(Guid obradivostId)
        {
            return Context.ObradivostSet.FirstOrDefault(e => e.ObradivostID == obradivostId);
        }
    }
}
