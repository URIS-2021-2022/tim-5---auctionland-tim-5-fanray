using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class ClanProfile : Profile
    {
        public ClanProfile()
        {
            CreateMap<Clan, ClanDto>();
        }
    }
}
