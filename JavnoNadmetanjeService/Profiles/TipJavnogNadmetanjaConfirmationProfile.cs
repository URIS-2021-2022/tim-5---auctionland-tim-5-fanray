﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class TipJavnogNadmetanjaConfirmationProfile : Profile
    {
        public TipJavnogNadmetanjaConfirmationProfile()
        {
            CreateMap<TipJavnogNadmetanja, TipJavnogNadmetanjaConfirmationDto>();
        }
    }
}
