using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Profiles
{
    public class TipKorisnikaProfile : Profile
    {
        public TipKorisnikaProfile()
        {
            CreateMap<TipKorisnika, TipKorisnikaDto>();
        }
    }
}
