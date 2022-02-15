using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Profiles
{
    public class OvlascenoLiceConfirmationProfile : Profile
    {
        public OvlascenoLiceConfirmationProfile()
        {
            CreateMap<Entities.OvlascenoLice, OvlascenoLiceConfirmationDto>();
        }
    }
}