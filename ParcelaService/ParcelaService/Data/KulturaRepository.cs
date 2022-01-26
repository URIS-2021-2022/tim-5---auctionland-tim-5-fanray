using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KulturaRepository : IKulturaRepository
    {
        private readonly KulturaContext Context;

        public KulturaRepository(KulturaContext context)
        {
            this.Context = context;
        }

        public List<Kultura> GetKulturaList()
        {
            return Context.KulturaSet.ToList();
        }

        public Kultura GetKulturaById(Guid kulturaId)
        {
            return Context.KulturaSet.FirstOrDefault(e => e.KulturaID == kulturaId);
        }
    }
}
