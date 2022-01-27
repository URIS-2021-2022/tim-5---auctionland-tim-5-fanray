using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class ParcelaCreateProfile : Profile
    {
        public ParcelaCreateProfile()
        {
            CreateMap<ParcelaCreateDto, Parcela>();
        }
    }
}
