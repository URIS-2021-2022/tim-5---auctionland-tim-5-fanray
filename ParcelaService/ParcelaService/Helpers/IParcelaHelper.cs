using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Helpers
{
    public interface IParcelaHelper
    {
        Parcela loadRepositories(Parcela parcela);
    }
}
