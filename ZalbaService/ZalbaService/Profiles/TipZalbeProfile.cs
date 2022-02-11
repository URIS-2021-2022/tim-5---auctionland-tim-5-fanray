using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class TipZalbeProfile : Profile
    {
        public TipZalbeProfile()
        {
            CreateMap<TipZalbe, TipZalbeDto>();
        }
    }
}