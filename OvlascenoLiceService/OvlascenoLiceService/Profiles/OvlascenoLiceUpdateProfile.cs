using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Profiles
{
    public class OvlascenoLiceUpdateProfile : Profile
    {
        public OvlascenoLiceUpdateProfile()
        {
            CreateMap<OvlascenoLiceUpdateDto, Entities.OvlascenoLice>();
        }
    }
}