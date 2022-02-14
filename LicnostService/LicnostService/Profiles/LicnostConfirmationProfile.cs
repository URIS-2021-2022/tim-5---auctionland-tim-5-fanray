using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class LicnostConfirmationProfile : Profile
    {
        public LicnostConfirmationProfile()
        {
            CreateMap<Licnost, LicnostConfirmationDto>();
        }
    }
}
