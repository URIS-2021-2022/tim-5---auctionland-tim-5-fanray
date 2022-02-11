using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaUpdateProfile : Profile
    {
        public ZalbaUpdateProfile()
        {
            CreateMap<ZalbaUpdateDto, Zalba>();
        }
    }
}