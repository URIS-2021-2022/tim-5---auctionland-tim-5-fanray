﻿using AutoMapper;
using LicnostService.Entities;
using LicnostService.Models;

namespace LicnostService.Profiles
{
    public class PredsednikProfile : Profile
    {
        public PredsednikProfile()
        {
            CreateMap<Predsednik, PredsednikDto>();
        }
    }
}
