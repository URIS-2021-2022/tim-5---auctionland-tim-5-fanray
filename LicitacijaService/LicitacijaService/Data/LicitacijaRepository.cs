using LicitacijaService.Entities;
using LicitacijaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace LicitacijaService.Data
{
    public class LicitacijaRepository : ILicitacijaRepository
    {
        private readonly LicitacijaContext Context;
        private readonly IMapper Mapper;

        public LicitacijaRepository(LicitacijaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public LicitacijaConfirmationDto CreateLicitacija(Licitacija licitacija)
        {
            licitacija.LicitacijaID = Guid.NewGuid();

            Context.Licitacija.Add(licitacija);
            Context.SaveChanges();

            return Mapper.Map<LicitacijaConfirmationDto>(licitacija);
        }

        public LicitacijaConfirmationDto DeleteLicitacija(Guid licitacijaId)
        {
            Licitacija licitacija = getLicitacijaById(licitacijaId);

            if (licitacija == null)
            {
                throw new ArgumentNullException("licitacijaId");
            }

            Context.Remove(licitacija);
            Context.SaveChanges();

            return Mapper.Map<LicitacijaConfirmationDto>(licitacija);
        }

        public Licitacija getLicitacijaById(Guid licitacijaID)
        {
            return Context.Licitacija.FirstOrDefault(e => e.LicitacijaID == licitacijaID);
        }

        public List<Licitacija> getLicitacijaList()
        {
            return Context.Licitacija.ToList();
        }

        public LicitacijaConfirmationDto UpdateLicitacija(Licitacija licitacija)
        {
            Licitacija l = Context.Licitacija.FirstOrDefault(e => e.LicitacijaID == licitacija.LicitacijaID);

            if (l == null)
            {
                throw new EntryPointNotFoundException();
            }

            l.DokumentacijaID = licitacija.DokumentacijaID;
            l.Broj = licitacija.Broj;
            l.Godina = licitacija.Godina;
            l.Datum = licitacija.Datum;
            l.Ogranicenje = licitacija.Ogranicenje;
            l.KorakCene = licitacija.KorakCene;
            l.RokZaPrijavu = licitacija.RokZaPrijavu;

            Context.SaveChanges();

            return Mapper.Map<LicitacijaConfirmationDto>(l);
        }
    }
}
