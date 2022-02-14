using KupacService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public interface IPrioritetRepository
    {
        List<Prioritet> GetPrioritetList();
        Prioritet GetPrioritetById(Guid prioritetId);
    }
}
