using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class ParcelaConfirmationProfile : Profile
    {
        public ParcelaConfirmationProfile()
        {
            CreateMap<Parcela, ParcelaConfirmationDto>();
        }
    }
}
