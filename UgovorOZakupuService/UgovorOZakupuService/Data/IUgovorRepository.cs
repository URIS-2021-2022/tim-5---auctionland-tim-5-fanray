using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Data
{
    public interface IUgovorRepository
    {
        List<Ugovor> GetUgovorList();
        Ugovor GetUgovorById(Guid ugovorId);
        UgovorConfirmationDto CreateUgovor(Ugovor ugovor);
        UgovorConfirmationDto UpdateUgovor(Ugovor ugovor);
        UgovorConfirmationDto DeleteUgovor(Guid ugovorId);
    }
}
