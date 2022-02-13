using LicnostService.Entities;
using LicnostService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace LicnostService.Data
{
    public class LicnostRepository : ILicnostRepository
    {
        private readonly LicnostContext Context;
        private readonly IMapper Mapper;

        public LicnostRepository(LicnostContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public LicnostConfirmationDto CreateLicnost(Licnost licnost)
        {
            licnost.LicnostID = Guid.NewGuid();

            Context.Licnost.Add(licnost);
            Context.SaveChanges();

            return Mapper.Map<LicnostConfirmationDto>(licnost);
        }

        public LicnostConfirmationDto DeleteLicnost(Guid licnostId)
        {
            Licnost licnost = GetLicnostById(licnostId);

            if (licnost == null)
            {
                throw new ArgumentNullException("licnostId");
            }

            Context.Licnost.Remove(licnost);
            Context.SaveChanges();

            return Mapper.Map<LicnostConfirmationDto>(licnost);
        }

        public Licnost GetLicnostById(Guid licnostId)
        {
            return Context.Licnost.FirstOrDefault(e => e.LicnostID == licnostId);
        }

        public List<Licnost> GetLicnostList()
        {
            return Context.Licnost.ToList();
        }

        public LicnostConfirmationDto UpdateLicnost(Licnost licnost)
        {
            Licnost l = Context.Licnost.FirstOrDefault(e => e.LicnostID == licnost.LicnostID);

            if (l == null)
            {
                throw new EntryPointNotFoundException();
            }

            l.Ime = licnost.Ime;
            l.Prezime = licnost.Prezime;
            l.Funkcija = licnost.Funkcija;

            Context.SaveChanges();

            return Mapper.Map<LicnostConfirmationDto>(l);
        }
    }
}
