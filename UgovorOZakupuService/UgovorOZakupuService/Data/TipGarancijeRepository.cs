using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public class TipGarancijeRepository : ITipGarancijeRepository
    {
        private readonly UgovorContext Context;

        public TipGarancijeRepository(UgovorContext context)
        {
            this.Context = context;
        }

        public List<TipGarancije> GetTipGarancijeList()
        {

            return Context.TipGarancije.ToList();
        }

        public TipGarancije GetTipGarancijeById(Guid tipGarancijeId)
        {
            return Context.TipGarancije.FirstOrDefault(e => e.TipGarancijeID == tipGarancijeId);
        }
    }
}
