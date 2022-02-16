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
        List<Prijavljen_Kupac> GetPrijavljen_KupacList();
        Prijavljen_Kupac GetPrijavljen_KupacById(Guid prijavljenKupacId);
        PrijavljenKupacConfirmationDto CreatePrijavljenKupac(Prijavljen_Kupac prijavljenKupac);
        PrijavljenKupacConfirmationDto UpdatePrijavljenKupac(Prijavljen_Kupac prijavljenKupac);
        PrijavljenKupacConfirmationDto DeletePrijavljenKupac(Guid prijavljenKupacId);
    }
}
