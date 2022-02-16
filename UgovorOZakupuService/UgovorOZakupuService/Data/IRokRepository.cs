using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public interface IRokRepository
    {
        List<Rok> GetRokList();
        Rok GetRokById(Guid rokId);
    }
}
