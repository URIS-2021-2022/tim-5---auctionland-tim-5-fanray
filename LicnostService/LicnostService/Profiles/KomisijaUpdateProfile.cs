using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class KomisijaUpdateProfile : Profile
    {
        public KomisijaUpdateProfile()
        {
            CreateMap<KomisijaUpdateDto, Komisija>();
        }
    }
}
