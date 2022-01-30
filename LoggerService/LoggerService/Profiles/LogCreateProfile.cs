using AutoMapper;
using LoggerService.Entities;
using LoggerService.Models;

namespace LoggerService.Profiles
{
    public class LogCreateProfile : Profile
    {
        public LogCreateProfile()
        {
            CreateMap<LogCreateDto, Log>();
        }
    }
}
