using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;
namespace ParcelaService.Profiles
{
    public class ParcelaUpdateProfile : Profile
    {
        public ParcelaUpdateProfile()
        {
            CreateMap<ParcelaUpdateDto, Parcela>();
        }
    }
}
