using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;

namespace LicnostService.Data
{
    public class PredsednikRepository : IPredsednikRepository
    {
        private readonly LicnostContext Context;

        public PredsednikRepository(LicnostContext context)
        {
            this.Context = context;
        }

        public Predsednik GetPredsednikById(Guid predsednikId)
        {
            return Context.Predsednik.FirstOrDefault(e => e.PredsednikID == predsednikId);
        }

        public List<Predsednik> GetPredsednikList()
        {
            return Context.Predsednik.ToList();
        }
    }
}
