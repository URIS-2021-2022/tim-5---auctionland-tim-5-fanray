using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class StatusJavnogNadmetanjaConfirmationProfile : Profile
    {
        public StatusJavnogNadmetanjaConfirmationProfile()
        {
            CreateMap<StatusJavnogNadmetanja, StatusJavnogNadmetanjaConfirmationDto>();
        }
    }
}
