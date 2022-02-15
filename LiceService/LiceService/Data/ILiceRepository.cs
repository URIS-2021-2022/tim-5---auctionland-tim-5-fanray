using LiceService.Entities;
using LiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public interface ILiceRepository
    {
        List<Lice> GetLiceList();
        Lice GetLiceById(Guid liceId);
        LiceConfirmationDto CreateLice(Lice lice);
        LiceConfirmationDto UpdateLice(Lice lice);
        LiceConfirmationDto DeleteLice(Guid liceId);
    }
}
