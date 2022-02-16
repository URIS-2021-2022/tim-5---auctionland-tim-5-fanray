using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Data
{
    public interface IKomisijaRepository
    {
        List<Komisija> GetKomisijaList();
        Komisija GetKomisijaById(Guid komisijaId);

        KomisijaConfirmationDto CreateKomisija(Komisija komisija);
        KomisijaConfirmationDto UpdateKomisija(Komisija komisija);
        KomisijaConfirmationDto DeleteKomisija(Guid komisijaId);
    }
}
