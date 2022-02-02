using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ZasticenaZonaRepository : IZasticenaZonaRepository
    {
        private readonly ParcelaContext Context;

        public ZasticenaZonaRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<ZasticenaZona> GetZasticenaZonaList()
        {
            return Context.ZasticenaZona.ToList();
        }

        public ZasticenaZona GetZasticenaZonaById(Guid zasticenaZonaId)
        {
            return Context.ZasticenaZona.FirstOrDefault(e => e.ZasticenaZonaID == zasticenaZonaId);
        }
    }
}
