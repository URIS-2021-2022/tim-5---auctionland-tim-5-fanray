using LicnostService.Entities;
using LicnostService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace LicnostService.Data
{
    public class ClanRepository : IClanRepository
    {
        private readonly LicnostContext Context;
        private readonly IMapper Mapper;

        public ClanRepository(LicnostContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public ClanConfirmationDto CreateClan(Clan clan)
        {
            clan.ClanID = Guid.NewGuid();

            Context.Clan.Add(clan);
            Context.SaveChanges();

            return Mapper.Map<ClanConfirmationDto>(clan);
        }

        public ClanConfirmationDto DeleteClan(Guid clanId)
        {
            Clan clan = GetClanById(clanId);

            if (clan == null)
            {
                throw new ArgumentNullException("clanId");
            }

            Context.Clan.Remove(clan);
            Context.SaveChanges();

            return Mapper.Map<ClanConfirmationDto>(clan);
        }

        public Clan GetClanById(Guid clanId)
        {
            return Context.Clan.FirstOrDefault(e => e.ClanID == clanId);
        }

        public List<Clan> GetClanList(Guid licnostId)
        {
            return Context.Clan.Where(e => e.LicnostID == licnostId).ToList();
        }

        public ClanConfirmationDto UpdateClan(Clan clan)
        {
            Clan dp = Context.Clan.FirstOrDefault(e => e.ClanID == clan.ClanID);

            if (dp == null)
            {
                throw new EntryPointNotFoundException();
            }

            dp.ClanID = clan.ClanID;
            
            Context.SaveChanges();

            return Mapper.Map<ClanConfirmationDto>(dp);
        }
    }
}
