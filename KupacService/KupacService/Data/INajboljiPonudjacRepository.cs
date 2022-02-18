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
        List<NajboljiPonudjac> GetNajbolji_PonudjacList();
        NajboljiPonudjac GetNajbolji_PonudjacById(Guid najboljiPonudjacId);
        NajboljiPonudjacConfirmationDto CreateNajboljiPonudjac(NajboljiPonudjac najboljiPonudjac);
        NajboljiPonudjacConfirmationDto UpdateNajboljiPonudjac(NajboljiPonudjac najboljiPonudjac);
        NajboljiPonudjacConfirmationDto DeleteNajboljiPonudjac(Guid najboljiPonudjacId);
    }
}
