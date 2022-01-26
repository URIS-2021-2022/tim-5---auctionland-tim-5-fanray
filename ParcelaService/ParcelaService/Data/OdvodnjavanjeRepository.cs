using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class OdvodnjavanjeRepository : IOdvodnjavanjeRepository
    {
        private readonly OdvodnjavanjeContext Context;

        public OdvodnjavanjeRepository(OdvodnjavanjeContext context)
        {
            this.Context = context;
        }

        public List<Odvodnjavanje> GetOdvodnjavanjeList()
        {
            return Context.OdvodnjavanjeSet.ToList();
        }

        public Odvodnjavanje GetOdvodnjavanjeById(Guid odvodnjavanjeId)
        {
            return Context.OdvodnjavanjeSet.FirstOrDefault(e => e.OdvodnjavanjeID == odvodnjavanjeId);
        }
    }
}
