using AutoMapper;
using LiceService.Entities;
using LiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Profiles
{
    public class LiceCreateProfile : Profile
    {
        public LiceCreateProfile()
        {
            CreateMap<LiceCreateDto, Lice>();
        }
    }
}