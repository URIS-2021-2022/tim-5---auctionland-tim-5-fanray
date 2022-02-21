using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public interface IPrijavljeniKupacRepository
    {
        List<PrijavljenKupac> GetPrijavljen_KupacList();
        PrijavljenKupac GetPrijavljen_KupacById(Guid prijavljenKupacId);
        PrijavljenKupacConfirmationDto CreatePrijavljenKupac(PrijavljenKupac prijavljenKupac);
        PrijavljenKupacConfirmationDto UpdatePrijavljenKupac(PrijavljenKupac prijavljenKupac);
        PrijavljenKupacConfirmationDto DeletePrijavljenKupac(Guid prijavljenKupacId);
    }
}
