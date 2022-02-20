using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Data
{
    public interface IPredsednikRepository
    {
        List<Predsednik> GetPredsednikList(Guid licnostId);
        Predsednik GetPredsednikById(Guid predsednikId);

        PredsednikConfirmationDto CreatePredsednik(Predsednik predsednik);
        PredsednikConfirmationDto UpdatePredsednik(Predsednik plan);
        PredsednikConfirmationDto DeletePredsednik(Guid predsednikId);
    }
}
