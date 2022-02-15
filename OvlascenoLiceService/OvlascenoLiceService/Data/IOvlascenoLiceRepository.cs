using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Data
{        using OvlascenoLice;
    public interface IOvlascenoLiceRepository
    {
        List<Entities.OvlascenoLice> GetOvlascenoLiceList();
        Entities.OvlascenoLice GetOvlascenoLiceById(Guid ovlascenoLiceId);
        OvlascenoLiceConfirmationDto CreateOvlascenoLice(Entities.OvlascenoLice ovlascenoLice);
        OvlascenoLiceConfirmationDto UpdateOvlascenoLice(Entities.OvlascenoLice ovlascenoLice);
        OvlascenoLiceConfirmationDto DeleteOvlascenoLice(Guid ovlascenoLiceId);
    }
}