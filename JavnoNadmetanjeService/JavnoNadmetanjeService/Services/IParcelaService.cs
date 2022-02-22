using JavnoNadmetanjeService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Services
{
    public interface IParcelaService
    {
        Task<KatastarskaOpstinaDto> GetKatastarskaOpstinaByIdAsync(Guid katastarId, HttpRequest httpRequest);
    }
}
