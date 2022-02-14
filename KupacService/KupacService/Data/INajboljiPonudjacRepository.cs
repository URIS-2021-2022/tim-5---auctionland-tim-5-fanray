using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    interface INajboljiPonudjacRepository
    {
        List<Najbolji_Ponudjac> GetNajbolji_PonudjacList();
        Najbolji_Ponudjac GetNajbolji_PonudjacById(Guid najboljiPonudjacId);
    }
}
