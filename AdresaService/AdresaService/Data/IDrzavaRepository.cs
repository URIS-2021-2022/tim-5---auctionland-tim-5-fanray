using AdresaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Data
{
    public interface IDrzavaRepository
    {
        List<Drzava> GetDrzavaList();
        Drzava GetDrzavaById(Guid drzavaId);
    
    }
}
