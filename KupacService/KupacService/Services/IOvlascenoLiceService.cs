using KupacService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Services
{
    public interface IOvlascenoLiceService
    {
        Task<OvlascenoLiceDto> GetOvlascenoLiceByIdAsync(Guid ovlascenoLiceId, HttpRequest httpRequest);
    }
}
