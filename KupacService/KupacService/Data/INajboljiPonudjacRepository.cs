using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public interface INajboljiPonudjacRepository
    {
        List<Najbolji_Ponudjac> GetNajbolji_PonudjacList();
        Najbolji_Ponudjac GetNajbolji_PonudjacById(Guid najboljiPonudjacId);
        NajboljiPonudjacConfirmationDto CreateNajboljiPonudjac(Najbolji_Ponudjac najboljiPonudjac);
        NajboljiPonudjacConfirmationDto UpdateNajboljiPonudjac(Najbolji_Ponudjac najboljiPonudjac);
        NajboljiPonudjacConfirmationDto DeleteNajboljiPonudjac(Guid najboljiPonudjacId);
    }
}
