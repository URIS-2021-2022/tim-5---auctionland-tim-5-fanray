using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Profiles
{
    public class BrojTableProfile : Profile
    {
        public BrojTableProfile()
        {
            CreateMap<BrojTable, BrojTableDto>();
        }
    }
}