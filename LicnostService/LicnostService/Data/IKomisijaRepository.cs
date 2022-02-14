using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;

namespace LicnostService.Data
{
    public interface IKomisijaRepository
    {
        List<Komisija> GetKomisijaList();
        Komisija GetKomisijaById(Guid komisijaId);
    }
}
