using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IObradivostRepository
    {
        List<Obradivost> GetObradivostList();
        Obradivost GetObradivostById(Guid obradivostId);
    }
}
