using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    public class UplataRepository : IUplataRepository
    {


        private readonly UplataContext Context;
        private readonly IMapper Mapper;

        public UplataRepository(UplataContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public UplataConfirmationDto CreateUplata(Uplata uplata)
        {
            uplata.UplataID = Guid.NewGuid();

            Context.Uplata.Add(uplata);
            Context.SaveChanges();

            return Mapper.Map<UplataConfirmationDto>(uplata);
        }

        public UplataConfirmationDto CreateUplata(UplataCreateDto uplata)
        {
            throw new NotImplementedException();
        }

        public UplataConfirmationDto DeleteUplata(Guid uplataId)
        {
            Uplata uplata = getUplataById(uplataId);

            if (uplata == null)
            {
                throw new ArgumentNullException("uplataId");
            }

            Context.Remove(uplata);
            Context.SaveChanges();

            return Mapper.Map<UplataConfirmationDto>(uplata);
        }

        public Uplata getUplataById(Guid uplataId)
        {
            return Context.Uplata.FirstOrDefault(e => e.UplataID == uplataId);
        }

        public List<Uplata> getUplataList()
        {
            return Context.Uplata.ToList();
        }

        public UplataConfirmationDto UpdateUplata(UplataUpdateDto uplata)
        {
            Uplata u = Context.Uplata.FirstOrDefault(e => e.UplataID == uplata.UplataID);

            if (uplata == null)
            {
                throw new EntryPointNotFoundException();
            }

            u.Broj_Racuna = uplata.Broj_Racuna;
            u.Poziv_Na_Broj = uplata.Poziv_Na_Broj;
            u.Iznos = uplata.Iznos;
            u.Svrha_Uplate = uplata.Svrha_Uplate;
            u.DatumUplate = uplata.DatumUplate;
            u.DatumKursa = uplata.DatumKursa;
            u.Valuta = uplata.Valuta;
            u.Vrednost = uplata.Vrednost;


            Context.SaveChanges();

            return Mapper.Map<UplataConfirmationDto>(uplata);
        }
    }
}
