using Microsoft.AspNetCore.Http;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Services
{
    public interface ILiceService
    {
        Task<LiceDto> GetLiceByIdAsync(Guid liceId, HttpRequest httpRequest);
    }
}
