using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaConfirmationProfile : Profile
    {
        public ZalbaConfirmationProfile()
        {
            CreateMap<Zalba, ZalbaConfirmationDto>();
        }
    }
}