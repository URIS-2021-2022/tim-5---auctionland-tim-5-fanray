using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;

namespace LicnostService.Data
{

    public class KomisijaRepository : IKomisijaRepository
    {

        private readonly LicnostContext Context;

        public KomisijaRepository(LicnostContext context)
        {
            this.Context = context;
        }
        public Komisija GetKomisijaById(Guid komisijaId)
        {
            return Context.Komisija.FirstOrDefault(e => e.KomisijaID == komisijaId);
        }

        public List<Komisija> GetKomisijaList()
        {
            return Context.Komisija.ToList();
        }
    }
}
