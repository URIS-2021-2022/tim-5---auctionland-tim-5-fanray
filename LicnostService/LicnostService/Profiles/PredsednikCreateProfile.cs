using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class PredsednikCreateProfile : Profile
    {
        public PredsednikCreateProfile()
        {
            CreateMap<PredsednikCreateDto, Predsednik>();
        }
    }
}
