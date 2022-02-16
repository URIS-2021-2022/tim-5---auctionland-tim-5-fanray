﻿using AutoMapper;
using LiceService.Entities;
using LiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Profiles
{
    public class KontaktOsobaProfile : Profile
    {
        public KontaktOsobaProfile()
        {
            CreateMap<KontaktOsoba, KontaktOsobaDto>();
        }
    }

}

