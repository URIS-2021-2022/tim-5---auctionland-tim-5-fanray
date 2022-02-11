using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class StatusZalbeProfile : Profile
    {
        public StatusZalbeProfile()
        {
            CreateMap<StatusZalbe, StatusZalbeDto>();
        }
    }
}