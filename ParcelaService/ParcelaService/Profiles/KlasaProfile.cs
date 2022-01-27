using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class KlasaProfile : Profile
    {
        public KlasaProfile()
        {
            CreateMap<Klasa, KlasaDto>();
        }
    }
}
