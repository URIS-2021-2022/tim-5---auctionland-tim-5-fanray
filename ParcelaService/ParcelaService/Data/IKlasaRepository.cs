using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IKlasaRepository
    {
        List<Klasa> GetKlasaList();
        Klasa GetKlasaById(Guid klasaId);
    }
}
