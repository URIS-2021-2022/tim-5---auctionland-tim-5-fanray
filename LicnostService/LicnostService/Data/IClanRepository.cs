using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;

namespace LicnostService.Data
{
    public interface IClanRepository
    {
        List<Clan> GetClanList();
        Clan GetClanById(Guid clanId);
    }
}
