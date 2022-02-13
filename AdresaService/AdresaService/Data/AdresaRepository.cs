using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Data
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly AdresaContext Context;
        private readonly IMapper Mapper;

        public AdresaRepository(AdresaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public Adresa GetAdresaById(Guid adresaId)
        {
            return Context.Adresa.FirstOrDefault(e => e.AdresaID == adresaId);
        }

        public List<Adresa> GetAdresaList()
        {
            return Context.Adresa.ToList();
        }

        public AdresaConfirmationDto CreateAdresa(Adresa adresa)
        { 
            adresa.AdresaID = Guid.NewGuid();

            Context.Adresa.Add(adresa);
            Context.SaveChanges();

            return Mapper.Map<AdresaConfirmationDto>(adresa);
        }

        public AdresaConfirmationDto UpdateAdresa(Adresa adresa)
        {
            Adresa a = Context.Adresa.FirstOrDefault(e => e.AdresaID == adresa.AdresaID);

            if (a == null)
            {
                throw new EntryPointNotFoundException();
            }

            a.AdresaID = adresa.AdresaID;
            a.Ulica = adresa.Ulica;
            a.Broj = adresa.Broj;
            a.Mesto = adresa.Mesto;
            a.PostanskiBroj = adresa.PostanskiBroj;


            Context.SaveChanges();

            return Mapper.Map<AdresaConfirmationDto>(a);
        }

        public AdresaConfirmationDto DeleteAdresa(Guid adresaId)
        {
            Adresa adresa = GetAdresaById(adresaId);

            if (adresa == null)
            {
                throw new ArgumentNullException("adresaId");
            }

            Context.Adresa.Remove(adresa);
            Context.SaveChanges();

            return Mapper.Map<AdresaConfirmationDto>(adresa);
        }
    }
}
