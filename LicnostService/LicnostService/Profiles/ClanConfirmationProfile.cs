using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class ClanConfirmationProfile : Profile
    {
        public ClanConfirmationProfile()
        {
            CreateMap<Clan, ClanConfirmationDto>();
        }
    }
}
