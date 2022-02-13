using AutoMapper;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Profiles
{
   public class KorisnikCreateProfile : Profile
   {
       public KorisnikCreateProfile()
       {
           CreateMap<KorisnikCreateDto, Korisnik>();
       }
   }
}
