using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class LicnostUpdateProfile : Profile
    {
        public LicnostUpdateProfile()
        {
            CreateMap<LicnostUpdateDto, Licnost>();
        }
    }
}
