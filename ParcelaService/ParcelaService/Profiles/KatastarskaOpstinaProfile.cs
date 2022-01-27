using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class KatastarskaOpstinaProfile : Profile
    {
        public KatastarskaOpstinaProfile()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaDto>();
        }
    }
}
