using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    public interface IUplataRepository
    {

         
        List<Uplata> getUplataList();

        Uplata getUplataById(Guid uplataId);

        UplataConfirmationDto CreateUplata(Uplata uplataDto);

        UplataConfirmationDto UpdateUplata(UplataUpdateDto uplataDto);

        UplataConfirmationDto DeleteUplata(Guid uplataId);
    }

}
