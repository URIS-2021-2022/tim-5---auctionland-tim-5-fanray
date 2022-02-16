using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class ClanUpdateProfile : Profile
    {
        public ClanUpdateProfile()
        {
            CreateMap<ClanUpdateDto, Clan>();
        }
    }
}
