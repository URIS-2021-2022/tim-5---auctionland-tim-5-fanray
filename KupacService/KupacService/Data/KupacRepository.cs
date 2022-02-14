using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class KupacRepository : IKupacRepository
    {
        private readonly KupacContext Context;
        private readonly IMapper Mapper;

        public KupacRepository(KupacContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public KupacConfirmationDto CreateKupac(Kupac kupac)
        {
            kupac.KupacId = Guid.NewGuid();

            Context.Kupac.Add(kupac);
            Context.SaveChanges();

            return Mapper.Map<KupacConfirmationDto>(kupac);
        }

        public KupacConfirmationDto DeleteKupac(Guid kupacId)
        {
            throw new NotImplementedException();
        }

        public Kupac GetKupacById(Guid kupacId)
        {
            return Context.Kupac.FirstOrDefault(e => e.KupacId == kupacId);
        }

        public List<Kupac> GetKupacList()
        {
            return Context.Kupac.ToList();
        }

        public KupacConfirmationDto UpdateKupac(Kupac kupac)
        {
            Kupac k = Context.Kupac.FirstOrDefault(e => e.KupacId == kupac.KupacId);

            if (k == null)
            {
                throw new EntryPointNotFoundException();
            }

            k.PrioritetId = kupac.PrioritetId;
            k.OstvarenaPovrsina = kupac.OstvarenaPovrsina;
            k.UplataId = kupac.UplataId;
            k.OvlascenoLiceId = kupac.OvlascenoLiceId;
            k.ImaZabranu = kupac.ImaZabranu;
            k.DatumPocetkaZabrane = kupac.DatumPocetkaZabrane;
            k.DatumPrestankaZabrane = kupac.DatumPrestankaZabrane;
            k.DatumTrajanjaZabrane = kupac.DatumTrajanjaZabrane;

            Context.SaveChanges();

            return Mapper.Map<KupacConfirmationDto>(k);
        }
    }
}
