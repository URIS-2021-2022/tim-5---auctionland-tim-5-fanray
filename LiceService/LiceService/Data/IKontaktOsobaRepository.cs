using LiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public interface IKontaktOsobaRepository
    {
        List<KontaktOsoba> GetKontaktOsobaList();
        KontaktOsoba GetKontaktOsobaById(Guid kontaktosobaId);
    }
}
