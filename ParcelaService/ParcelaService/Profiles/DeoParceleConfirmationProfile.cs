using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class DeoParceleConfirmationProfile : Profile
    {
        public DeoParceleConfirmationProfile()
        {
            CreateMap<DeoParcele, DeoParceleConfirmationDto>();
        }
    }
}
