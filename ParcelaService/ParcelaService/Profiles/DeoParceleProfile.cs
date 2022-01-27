using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class DeoParceleProfile : Profile
    {
        public DeoParceleProfile()
        {
            CreateMap<DeoParcele, DeoParceleDto>();
        }
    }
}
