using LicnostService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Data
{
    public class ClanRepository : IClanRepository
    {
        private readonly LicnostContext Context;

        public ClanRepository(LicnostContext context)
        {
            this.Context = context;
        }

        public Clan GetClanById(Guid clanId)
        {
            return Context.Clan.FirstOrDefault(e => e.ClanID == clanId);
        }

        public List<Clan> GetClanList()
        {
            return Context.Clan.ToList();
        }
    }
}
