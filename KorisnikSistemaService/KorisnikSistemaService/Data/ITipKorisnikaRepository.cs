using KorisnikSistemaService.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Data
{
    public interface ITipKorisnikaRepository
    {
        List<TipKorisnika> GetTipKorisnikaList();
        TipKorisnika GetTipKorisnikaById(Guid tipKorisnikaId);
    }
}
