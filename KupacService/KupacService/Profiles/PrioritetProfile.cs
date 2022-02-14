using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Profiles
{
    public class PrioritetProfile : Profile
    {
        public PrioritetProfile()
        {
            CreateMap<Prioritet, PrioritetDto>();
        }
    }
}
