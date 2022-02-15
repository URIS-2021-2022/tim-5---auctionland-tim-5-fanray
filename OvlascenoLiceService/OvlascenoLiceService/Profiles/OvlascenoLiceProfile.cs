using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Profiles
{
    public class OvlascenoLiceProfile : Profile
    {
        public OvlascenoLiceProfile()
        {
            CreateMap<Entities.OvlascenoLice, OvlascenoLiceDto>();
        }
    }
}