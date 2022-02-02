using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KulturaRepository : IKulturaRepository
    {
        private readonly ParcelaContext Context;

        public KulturaRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<Kultura> GetKulturaList()
        {
            return Context.Kultura.ToList();
        }

        public Kultura GetKulturaById(Guid kulturaId)
        {
            return Context.Kultura.FirstOrDefault(e => e.KulturaID == kulturaId);
        }
    }
}
