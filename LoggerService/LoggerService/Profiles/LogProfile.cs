using AutoMapper;
using LoggerService.Entities;
using LoggerService.Models;

namespace LoggerService.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDto>();
        }
    }
}
