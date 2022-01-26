using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IOdvodnjavanjeRepository
    {
        List<Odvodnjavanje> GetOdvodnjavanjeList();
        Odvodnjavanje GetOdvodnjavanjeById(Guid odvodnjavanjeId);
    }
}
