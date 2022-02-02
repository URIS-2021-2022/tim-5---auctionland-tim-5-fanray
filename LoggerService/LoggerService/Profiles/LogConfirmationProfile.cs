using AutoMapper;
using LoggerService.Entities;
using LoggerService.Models;

namespace LoggerService.Profiles
{
    public class LogConfirmationProfile : Profile
    {
        public LogConfirmationProfile()
        {
            CreateMap<Log, LogConfirmationDto>();
        }
    }
}
