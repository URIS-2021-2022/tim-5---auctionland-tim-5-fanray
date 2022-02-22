using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Services
{
    public interface ILicnostService
    {
        Task<LicnostDto> GetLicnostByIdAsync(Guid licnostId, HttpRequest httpRequest);
    }
}
