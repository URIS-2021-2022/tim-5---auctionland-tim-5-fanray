
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Profiles
{
    public class UgovorProfile : Profile
    {
        public UgovorProfile()
        {
            CreateMap<Ugovor, UgovorDto>();
        }
    }
}
