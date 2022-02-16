using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class ClanCreateProfile : Profile
    {
        public ClanCreateProfile()
        {
            CreateMap<ClanCreateDto, Clan>();
        }
    }
}
