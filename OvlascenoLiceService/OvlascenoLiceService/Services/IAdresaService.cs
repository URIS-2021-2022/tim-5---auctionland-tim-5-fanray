using Microsoft.AspNetCore.Http;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvlascenoLiceService.Services
{
    public interface IAdresaService
    {
        Task<DrzavaDto> GetDrzavaByIdAsync(Guid drzavaId, HttpRequest httpRequest);
    }
}
