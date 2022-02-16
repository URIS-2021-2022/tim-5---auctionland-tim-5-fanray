using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Profiles
{
    public class UgovorConfirmationProfile : Profile
    {
        public UgovorConfirmationProfile()
        {
            CreateMap<Ugovor, UgovorConfirmationDto>();
        }
    }
}
