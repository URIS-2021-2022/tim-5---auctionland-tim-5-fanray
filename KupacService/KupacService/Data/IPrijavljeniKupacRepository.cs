using KupacService.Entities;
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
    }
}
