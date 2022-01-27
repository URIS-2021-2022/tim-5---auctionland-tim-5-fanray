using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class DeoParceleCreateProfile : Profile
    {
        public DeoParceleCreateProfile()
        {
            CreateMap<DeoParceleCreateDto, DeoParcele>();
        }
    }
}
