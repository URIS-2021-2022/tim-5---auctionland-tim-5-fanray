using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class LicnostCreateProfile : Profile
    {
        public LicnostCreateProfile()
        {
            CreateMap<LicnostCreateDto, Licnost>();
        }
    }
}
