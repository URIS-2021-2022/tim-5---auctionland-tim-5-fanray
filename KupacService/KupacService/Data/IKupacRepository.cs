using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public interface IKupacRepository
    {
        List<Kupac> GetKupacList();
        Kupac GetKupacById(Guid kupacId);
        KupacConfirmationDto CreateKupac(Kupac kupac);
        KupacConfirmationDto UpdateKupac(Kupac kupac);
        KupacConfirmationDto DeleteKupac(Guid kupacId);
    }
}
