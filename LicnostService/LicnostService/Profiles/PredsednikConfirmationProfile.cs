using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class PredsednikConfirmationProfile : Profile
    {
        public PredsednikConfirmationProfile()
        {
            CreateMap<Predsednik, PredsednikConfirmationDto>();
        }
    }
}
