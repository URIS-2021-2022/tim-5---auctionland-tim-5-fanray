using AutoMapper;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OvlascenoLiceService.Data
{
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {
        private readonly OvlascenoLiceContext Context;
        private readonly IMapper Mapper;

        public OvlascenoLiceRepository(OvlascenoLiceContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Entities.OvlascenoLice> GetOvlascenoLiceList()
        {
            return Context.OvlascenoLice.ToList();
        }

        public Entities.OvlascenoLice GetOvlascenoLiceById(Guid ovlascenoLiceId)
        {
            return Context.OvlascenoLice.FirstOrDefault(e => e.OvlascenoLiceID == ovlascenoLiceId);
        }

        public OvlascenoLiceConfirmationDto CreateOvlascenoLice(Entities.OvlascenoLice ovlascenoLice)
        {
            ovlascenoLice.OvlascenoLiceID = Guid.NewGuid();

            Context.OvlascenoLice.Add(ovlascenoLice);
            Context.SaveChanges();

            return Mapper.Map<OvlascenoLiceConfirmationDto>(ovlascenoLice);
        }

        public OvlascenoLiceConfirmationDto UpdateOvlascenoLice(Entities.OvlascenoLice ovlascenoLice)
        {
            Entities.OvlascenoLice o = Context.OvlascenoLice.FirstOrDefault(e => e.OvlascenoLiceID == ovlascenoLice.OvlascenoLiceID);

            if (o == null)
            {
                throw new EntryPointNotFoundException();
            }

            o.Ime = ovlascenoLice.Ime;
            o.Prezime = ovlascenoLice.Prezime;
            o.JMBG = ovlascenoLice.JMBG;
            o.BrojPasosa = ovlascenoLice.BrojPasosa;
            o.BrojTableID = ovlascenoLice.BrojTableID;
            o.DrzavaID = ovlascenoLice.DrzavaID;

            Context.SaveChanges();

            return Mapper.Map<OvlascenoLiceConfirmationDto>(o);
        }

        public OvlascenoLiceConfirmationDto DeleteOvlascenoLice(Guid ovlascenoLiceId)
        {
            Entities.OvlascenoLice ovlascenoLice = GetOvlascenoLiceById(ovlascenoLiceId);

            if (ovlascenoLice == null)
            {
                throw new ArgumentNullException("ovlascenoLiceId");
            }

            Context.OvlascenoLice.Remove(ovlascenoLice);
            Context.SaveChanges();

            return Mapper.Map<OvlascenoLiceConfirmationDto>(ovlascenoLice);
        }
    }
}