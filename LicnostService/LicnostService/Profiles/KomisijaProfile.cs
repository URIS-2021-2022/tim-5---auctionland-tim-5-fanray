using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;


namespace LicnostService.Profiles
{
    public class KomisijaProfile : Profile
    {
        public KomisijaProfile()
        {
            CreateMap<Komisija, KomisijaDto>();
        }
    }
}
