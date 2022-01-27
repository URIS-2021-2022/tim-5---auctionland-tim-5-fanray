using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;

namespace ParcelaService.Profiles
{
    public class OdvodnjavanjeProfile : Profile
    {
        public OdvodnjavanjeProfile()
        {
            CreateMap<Odvodnjavanje, OdvodnjavanjeDto>();
        }
    }
}
