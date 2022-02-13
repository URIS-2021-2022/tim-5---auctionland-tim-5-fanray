using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;

namespace LicnostService.Data
{
    public interface IPredsednikRepository
    {  
        List<Predsednik> GetPredsednikList();
        Predsednik GetPredsednikById(Guid predsednikId);
    }
}
