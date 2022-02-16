using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;


namespace LicnostService.Profiles
{
    public class KomisijaCreateProfile : Profile
    {
        public KomisijaCreateProfile()
        {
            CreateMap<KomisijaCreateDto, Komisija>();
        }
    }
}
