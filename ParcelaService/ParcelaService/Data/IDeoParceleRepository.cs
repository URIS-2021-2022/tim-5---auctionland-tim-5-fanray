using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IDeoParceleRepository
    {
        List<DeoParcele> GetDeoParceleList(Guid parcelaId);
        DeoParcele GetDeoParcelaById(Guid deoParceleId);
        DeoParceleConfirmationDto CreateDeoParcele(DeoParcele deoParcele);
        DeoParceleConfirmationDto UpdateDeoParcele(DeoParcele deoParcele);
        DeoParceleConfirmationDto DeleteDeoParcele(Guid deoParceleId);
    }
}
