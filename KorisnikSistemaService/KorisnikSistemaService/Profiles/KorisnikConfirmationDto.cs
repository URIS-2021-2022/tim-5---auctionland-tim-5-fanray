using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;

namespace ParcelaService.Profiles
{
    public class KorisnikConfirmationProfile : Profile
    {
        public KorisnikConfirmationProfile()
        {
            CreateMap<Korisnik, KorisnikConfirmationDto>();
        }
    }
}