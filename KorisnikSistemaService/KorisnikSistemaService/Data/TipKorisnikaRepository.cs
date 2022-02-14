using KorisnikSistemaService.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Data
{
    public class TipKorisnikaRepository : ITipKorisnikaRepository
    {
        private readonly KorisnikContext Context;

        public TipKorisnikaRepository(KorisnikContext context)
        {
            this.Context = context;
        }

        public List<TipKorisnika> GetTipKorisnikaList()
        {

            return Context.TipKorisnika.ToList();
        }

        public TipKorisnika GetTipKorisnikaById(Guid tipKorisnikaId)
        {
            return Context.TipKorisnika.FirstOrDefault(e => e.TipKorisnikaID == tipKorisnikaId);
        }
    }
}
