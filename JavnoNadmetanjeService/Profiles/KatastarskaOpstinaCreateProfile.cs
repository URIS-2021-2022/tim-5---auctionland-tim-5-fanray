using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Profiles
{
    public class KatastarskaOpstinaCreateProfile : Profile
    {
        public KatastarskaOpstinaCreateProfile()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaCreateDto>();
        }

    }
}
