using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;
using AutoMapper;


namespace LicnostService.Data
{

    public class KomisijaRepository : IKomisijaRepository
    {

        private readonly LicnostContext Context;
        private readonly IMapper Mapper;

        public KomisijaRepository(LicnostContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public KomisijaConfirmationDto CreateKomisija(Komisija komisija)
        {
            komisija.KomisijaID = Guid.NewGuid();

            Context.Komisija.Add(komisija);
            Context.SaveChanges();

            return Mapper.Map<KomisijaConfirmationDto>(komisija);
        }

        public KomisijaConfirmationDto DeleteKomisija(Guid komisijaId)
        {
            Komisija komisija = GetKomisijaById(komisijaId);

            if (komisija == null)
            {
                throw new ArgumentNullException("komisijaId");
            }

            Context.Komisija.Remove(komisija);
            Context.SaveChanges();

            return Mapper.Map<KomisijaConfirmationDto>(komisija);
        }

        public Komisija GetKomisijaById(Guid komisijaId)
        {
            return Context.Komisija.FirstOrDefault(e => e.KomisijaID == komisijaId);
        }

        public List<Komisija> GetKomisijaList()
        {
            return Context.Komisija.ToList();
        }

        public KomisijaConfirmationDto UpdateKomisija(Komisija komisija)
        {
            Komisija l = Context.Komisija.FirstOrDefault(e => e.KomisijaID == komisija.KomisijaID);

            if (l == null)
            {
                throw new EntryPointNotFoundException();
            }

            l.KomisijaID = komisija.KomisijaID;
            l.ClanID = komisija.ClanID;
            l.PredsednikID = komisija.PredsednikID;

            Context.SaveChanges();

            return Mapper.Map<KomisijaConfirmationDto>(l);
        }
    }
}
