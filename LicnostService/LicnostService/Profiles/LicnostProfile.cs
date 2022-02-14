using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class LicnostProfile : Profile
    {
        public LicnostProfile()
        {
            CreateMap<Licnost, LicnostDto>();
        }
    }
}
