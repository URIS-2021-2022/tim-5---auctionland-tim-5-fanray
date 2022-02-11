using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaProfile : Profile
    {
        public ZalbaProfile()
        {
            CreateMap<Zalba, ZalbaDto>();
        }
    }
}