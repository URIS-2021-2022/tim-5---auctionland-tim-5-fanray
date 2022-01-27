using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class ZasticenaZonaProfile : Profile
    {
        public ZasticenaZonaProfile()
        {
            CreateMap<ZasticenaZona, ZasticenaZonaDto>();
        }
    }
}
