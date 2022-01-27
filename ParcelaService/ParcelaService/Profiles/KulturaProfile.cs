using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class KulturaProfile : Profile
    {
        public KulturaProfile()
        {
            CreateMap<Kultura, KulturaDto>();
        }
    }
}
