using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class PrijavljenKupacRepository : IPrijavljeniKupacRepository
    {
        private readonly KupacContext Context;
        private readonly IMapper Mapper;

        public PrijavljenKupacRepository(KupacContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public Prijavljen_Kupac GetPrijavljen_KupacById(Guid prijavljenKupacId)
        {
            return Context.Prijavljen_Kupac.FirstOrDefault(e => e.PrijavljenKupacId == prijavljenKupacId);
        }

        public List<Prijavljen_Kupac> GetPrijavljen_KupacList()
        {
            return Context.Prijavljen_Kupac.ToList();
        }
        public PrijavljenKupacConfirmationDto CreatePrijavljenKupac(Prijavljen_Kupac prijavljenKupac)
        {
            prijavljenKupac.PrijavljenKupacId = Guid.NewGuid();

            Context.Prijavljen_Kupac.Add(prijavljenKupac);
            Context.SaveChanges();

            return Mapper.Map<PrijavljenKupacConfirmationDto>(prijavljenKupac);
        }
        public PrijavljenKupacConfirmationDto UpdatePrijavljenKupac(Prijavljen_Kupac prijavljenKupac)
        {
            Prijavljen_Kupac pk = Context.Prijavljen_Kupac.FirstOrDefault(e => e.PrijavljenKupacId == prijavljenKupac.PrijavljenKupacId);

            if (pk == null)
            {
                throw new EntryPointNotFoundException();
            }

            pk.PrijavljenKupacId = prijavljenKupac.PrijavljenKupacId;
            pk.KupacId = prijavljenKupac.KupacId;

            Context.SaveChanges();

            return Mapper.Map<PrijavljenKupacConfirmationDto>(pk);
        }
        public PrijavljenKupacConfirmationDto DeletePrijavljenKupac(Guid prijavljenKupacId)
        {
            Prijavljen_Kupac prijavljenKupac = GetPrijavljen_KupacById(prijavljenKupacId);

            if (prijavljenKupac == null)
            {
                throw new ArgumentNullException("prijavljenKupacId");
            }

            Context.Prijavljen_Kupac.Remove(prijavljenKupac);
            Context.SaveChanges();

            return Mapper.Map<PrijavljenKupacConfirmationDto>(prijavljenKupac);
        }
    }
}
