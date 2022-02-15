using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Data
{
    public interface IDrzavaRepository
    {
        List<Drzava> GetDrzavaList();
        Drzava GetDrzavaById(Guid drzavaId);
    }
}