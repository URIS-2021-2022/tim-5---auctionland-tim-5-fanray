using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class PredsednikUpdateProfile : Profile
    {
        public PredsednikUpdateProfile()
        {
            CreateMap<PredsednikUpdateDto, Predsednik>();
        }
    }
}
