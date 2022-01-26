using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IKulturaRepository
    {
        List<Kultura> GetKulturaList();
        Kultura GetKulturaById(Guid kulturaId);
    }
}
