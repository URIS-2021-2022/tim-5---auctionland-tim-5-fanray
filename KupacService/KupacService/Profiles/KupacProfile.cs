using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Profiles
{
    public class KupacProfile : Profile
    {
        public KupacProfile()
        {
            CreateMap<Kupac, KupacDto>();
            CreateMap<Kupac, KupacConfirmationDto>();
            CreateMap<KupacCreateDto, Kupac>();
            CreateMap<KupacUpdateDto, Kupac>();
        }
    }
}
