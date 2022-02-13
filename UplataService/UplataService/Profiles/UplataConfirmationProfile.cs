using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Profiles
{
    public class UplataConfirmationProfile : Profile
    {


        public UplataConfirmationProfile()
        {
            CreateMap<Uplata, UplataConfirmationDto>();
        }
    }
}
