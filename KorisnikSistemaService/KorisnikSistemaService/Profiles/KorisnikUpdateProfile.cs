using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Profiles
{
    public class KorisnikUpdateProfile : Profile
    {
        public KorisnikUpdateProfile()
        {
            CreateMap<KorisnikUpdateDto, Korisnik>();
        }

    }
}
