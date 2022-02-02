using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ObradivostRepository : IObradivostRepository
    {
        private readonly ParcelaContext Context;

        public ObradivostRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<Obradivost> GetObradivostList()
        {
            return Context.Obradivost.ToList();
        }

        public Obradivost GetObradivostById(Guid obradivostId)
        {
            return Context.Obradivost.FirstOrDefault(e => e.ObradivostID == obradivostId);
        }
    }
}
