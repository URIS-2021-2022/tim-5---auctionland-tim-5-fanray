using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Profiles
{
    public class NajboljiPonudjacProfile : Profile
    {
        public NajboljiPonudjacProfile()
        {
            CreateMap<Najbolji_Ponudjac, NajboljiPonudjacDto>();
        }
    }
}
