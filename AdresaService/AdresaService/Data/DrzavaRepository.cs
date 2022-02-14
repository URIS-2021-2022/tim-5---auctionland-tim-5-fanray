using AdresaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Data
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly AdresaContext Context;

        public DrzavaRepository(AdresaContext context)
        {
            this.Context = context;
        }
        public Drzava GetDrzavaById(Guid drzavaId)
        {
            return Context.Drzava.FirstOrDefault(e => e.DrzavaID == drzavaId);
        }

        public List<Drzava> GetDrzavaList()
        {
            return Context.Drzava.ToList();
        }
    }
}
