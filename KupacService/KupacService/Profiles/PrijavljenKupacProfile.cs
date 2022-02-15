using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Profiles
{
    public class PrijavljenKupacProfile : Profile
    {
        public PrijavljenKupacProfile()
        {
            CreateMap<Prijavljen_Kupac, PrijavljenKupacDto>();
            CreateMap<Prijavljen_Kupac, PrijavljenKupacConfirmationDto>();
            CreateMap<PrijavljenKupacCreateDto, Prijavljen_Kupac>();
            CreateMap<PrijavljenKupacUpdateDto, Prijavljen_Kupac>();
        }
    }
}
