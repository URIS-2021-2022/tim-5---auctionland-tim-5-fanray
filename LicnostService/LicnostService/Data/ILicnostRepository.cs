using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Data
{
    public interface ILicnostRepository
    {
        List<Licnost> GetLicnostList();
        Licnost GetLicnostById(Guid licnostId);
        LicnostConfirmationDto CreateLicnost(Licnost licnost);
        LicnostConfirmationDto UpdateLicnost(Licnost licnost);
        LicnostConfirmationDto DeleteLicnost(Guid licnostId);
    }
}
