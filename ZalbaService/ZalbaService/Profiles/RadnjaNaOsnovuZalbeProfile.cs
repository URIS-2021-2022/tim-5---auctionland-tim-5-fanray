using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class RadnjaNaOsnovuZalbeProfile : Profile
    {
        public RadnjaNaOsnovuZalbeProfile()
        {
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbeDto>();
        }
    }
}