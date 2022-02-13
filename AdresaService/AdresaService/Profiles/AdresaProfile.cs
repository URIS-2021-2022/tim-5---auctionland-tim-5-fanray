using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<Adresa, AdresaDto>();
            CreateMap<Adresa, AdresaConfirmationDto>();
            CreateMap<AdresaCreateDto, Adresa>();
            CreateMap<AdresaUpdateDto, Adresa>();
        }
    }
}
