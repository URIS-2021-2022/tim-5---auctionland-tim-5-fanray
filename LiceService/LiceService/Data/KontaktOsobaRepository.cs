using LiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public class KontaktOsobaRepository : IKontaktOsobaRepository


    {
        private readonly LiceContext Context;

        public KontaktOsobaRepository(LiceContext context)
        {
            this.Context = context;
        }
        public KontaktOsoba GetKontaktOsobaById(Guid kontaktosobaId)
        {
            return Context.KontaktOsoba.FirstOrDefault(e => e.KontaktOsobaID == kontaktosobaId);
        }

        public List<KontaktOsoba> GetKontaktOsobaList()
        {
            return Context.KontaktOsoba.ToList();
        }
    }
}
