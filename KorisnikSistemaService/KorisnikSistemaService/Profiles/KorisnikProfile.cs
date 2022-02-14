using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Profiles
{
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<Korisnik, KorisnikDto>();
        }
    }
}
