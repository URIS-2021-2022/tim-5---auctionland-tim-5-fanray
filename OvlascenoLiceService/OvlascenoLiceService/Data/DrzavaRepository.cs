using OvlascenoLiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OvlascenoLiceService.Data
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly OvlascenoLiceContext Context;

        public DrzavaRepository(OvlascenoLiceContext context)
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