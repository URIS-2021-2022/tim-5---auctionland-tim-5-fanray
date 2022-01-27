using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class OdvodnjavanjeRepository : IOdvodnjavanjeRepository
    {
        private readonly ParcelaContext Context;

        public OdvodnjavanjeRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<Odvodnjavanje> GetOdvodnjavanjeList()
        {
            return Context.Odvodnjavanje.ToList();
        }

        public Odvodnjavanje GetOdvodnjavanjeById(Guid odvodnjavanjeId)
        {
            return Context.Odvodnjavanje.FirstOrDefault(e => e.OdvodnjavanjeID == odvodnjavanjeId);
        }
    }
}
