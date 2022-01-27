using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;
namespace ParcelaService.Profiles
{
    public class DeoParceleUpdateProfile : Profile
    {
        public DeoParceleUpdateProfile()
        {
            CreateMap<DeoParceleUpdateDto, DeoParcele>();
        }
    }
}
