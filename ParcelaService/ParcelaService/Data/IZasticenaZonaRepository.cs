using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IZasticenaZonaRepository
    {
        List<ZasticenaZona> GetZasticenaZonaList();
        ZasticenaZona GetZasticenaZonaById(Guid zasticenaZonaId);
    }
}
