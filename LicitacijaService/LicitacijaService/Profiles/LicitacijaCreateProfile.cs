﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LicitacijaService.Entities;
using LicitacijaService.Models;

namespace LicitacijaService.Profiles
{
    public class LicitacijaCreateProfile : Profile
    {
        public LicitacijaCreateProfile()
        {
            CreateMap<LicitacijaCreateDto, Licitacija>();
        }
    }
}
