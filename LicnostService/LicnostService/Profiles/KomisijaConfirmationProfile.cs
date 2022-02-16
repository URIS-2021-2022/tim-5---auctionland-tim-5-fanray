using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class KomisijaConfirmationProfile : Profile
    {
        public KomisijaConfirmationProfile()
        {
            CreateMap<Komisija, KomisijaConfirmationDto>();
        }
    }
}
