using ZalbaService.Entities;
//using ZalbaService.Models;
using System;
using System.Collections.Generic;

namespace ZalbaService.Data
{
    public interface IZalbaRepository
    {
        List<Zalba> GetZalbaList();
        Zalba GetZalbaById(Guid zalbaId);
        /*ZalbaConfirmationDto CreateZalba(Zalba zalba);
        ZalbaConfirmationDto UpdateZalba(Zalba zalba);
        ZalbaConfirmationDto DeleteZalba(Guid zalbaId);*/
    }
}