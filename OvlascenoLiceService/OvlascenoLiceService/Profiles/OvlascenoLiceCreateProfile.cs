using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Profiles
{
    public class OvlascenoLiceCreateProfile : Profile
    {
        public OvlascenoLiceCreateProfile()
        {
            CreateMap<OvlascenoLiceCreateDto, Entities.OvlascenoLice>();
        }
    }
}