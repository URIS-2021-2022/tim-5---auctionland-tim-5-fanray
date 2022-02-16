using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LicitacijaService.Entities;
using LicitacijaService.Models;

namespace LicitacijaService.Profiles
{
    public class LicitacijaConfirmationProfile : Profile
    {
        public LicitacijaConfirmationProfile()
        {
            CreateMap<Licitacija, LicitacijaConfirmationDto>();
        }
    }
}
