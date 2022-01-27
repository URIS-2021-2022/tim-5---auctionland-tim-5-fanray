using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {
            CreateMap<Parcela, ParcelaDto>();
        }
    }
}
