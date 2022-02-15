using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    interface IOvlascenoLiceMockRepository
    {
        List<OvlascenoLiceDto> GetOvlascenoLiceList();
        OvlascenoLiceDto GetOvlascenoLiceById(Guid ovlascenoLiceId);
    }
}
