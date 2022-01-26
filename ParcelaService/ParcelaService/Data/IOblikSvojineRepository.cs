using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IOblikSvojineRepository
    {
        List<OblikSvojine> GetOblikSvojineList();
        OblikSvojine GetOblikSvojineById(Guid oblikSvojineId);
    }
}
