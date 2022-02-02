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

        public LicitacijaConfirmationDto CreateLicitacija(LicitacijaCreateDto licitacijaDto)
        {
            Licitacija licitacija = new Licitacija()
            {
                LicitacijaID = Guid.NewGuid(),
                DokumentacijaID = licitacijaDto.DokumentacijaID,
                Broj = licitacijaDto.Broj,
                Godina = licitacijaDto.Godina,
                Datum = licitacijaDto.Datum,
                Ogranicenje = licitacijaDto.Ogranicenje,
                KorakCene = licitacijaDto.KorakCene,
                RokZaPrijavu = licitacijaDto.RokZaPrijavu
            };

            Context.Add(licitacija);
            Context.SaveChanges();

            return Mapper.Map<LicitacijaConfirmationDto>(licitacija);
        }

        public LicitacijaConfirmationDto DeleteLicitacija(Guid licitacijaId)
        {
            Licitacija licitacija = getLicitacijaById(licitacijaId);

            if (licitacija == null)
            {
                throw new ArgumentNullException();
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

        public LicitacijaConfirmationDto UpdateLicitacija(LicitacijaUpdateDto licitacijaDto)
        {
            Licitacija licitacija = Context.Licitacija.FirstOrDefault(e => e.LicitacijaID == licitacijaDto.LicitacijaID);

            if (licitacija == null)
            {
                throw new EntryPointNotFoundException();
            }

            licitacija.DokumentacijaID = licitacijaDto.DokumentacijaID;
            licitacija.Broj = licitacijaDto.Broj;
            licitacija.Godina = licitacijaDto.Godina;
            licitacija.Datum = licitacijaDto.Datum;
            licitacija.Ogranicenje = licitacijaDto.Ogranicenje;
            licitacija.KorakCene = licitacijaDto.KorakCene;
            licitacija.RokZaPrijavu = licitacijaDto.RokZaPrijavu;

            Context.SaveChanges();

            return Mapper.Map<LicitacijaConfirmationDto>(licitacija);
        }
    }
}
