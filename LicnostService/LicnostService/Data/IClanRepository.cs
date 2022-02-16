using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Data
{
    public interface IClanRepository
    {
        List<Clan> GetClanList(Guid licnostId);
        Clan GetClanById(Guid clanId);

        ClanConfirmationDto CreateClan(Clan clan);
        ClanConfirmationDto UpdateClan(Clan clan);
        ClanConfirmationDto DeleteClan(Guid clanId);
    }
}
