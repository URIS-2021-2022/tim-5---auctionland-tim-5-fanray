using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public class RokRepository : IRokRepository
    {
        private readonly UgovorContext Context;

        public RokRepository(UgovorContext context)
        {
            this.Context = context;
        }

        public List<Rok> GetRokList()
        {

            return Context.Rok.ToList();
        }

        public Rok GetRokById(Guid rokId)
        {
            return Context.Rok.FirstOrDefault(e => e.RokID == rokId);
        }
    }
}
