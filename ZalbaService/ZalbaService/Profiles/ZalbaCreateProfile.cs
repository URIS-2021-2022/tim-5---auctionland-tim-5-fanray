using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaCreateProfile : Profile
    {
        public ZalbaCreateProfile()
        {
            CreateMap<ZalbaCreateDto, Zalba>();
        }
    }
}