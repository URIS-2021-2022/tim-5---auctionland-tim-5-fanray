using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ZasticenaZonaRepository : IZasticenaZonaRepository
    {
        private readonly ZasticenaZonaContext Context;

        public ZasticenaZonaRepository(ZasticenaZonaContext context)
        {
            this.Context = context;
        }

        public List<ZasticenaZona> GetZasticenaZonaList()
        {
            return Context.ZasticenaZonaSet.ToList();
        }

        public ZasticenaZona GetZasticenaZonaById(Guid zasticenaZonaId)
        {
            return Context.ZasticenaZonaSet.FirstOrDefault(e => e.ZasticenaZonaID == zasticenaZonaId);
        }
    }
}
