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

        public UplataConfirmationDto CreateUplata(Uplata uplataDto)
        {
            Uplata uplata = new Uplata()
            {
                UplataID = Guid.NewGuid(),
                Broj_Racuna = uplataDto.Broj_Racuna,
                Poziv_Na_Broj = uplataDto.Poziv_Na_Broj,
                Iznos = uplataDto.Iznos,
                Svrha_Uplate = uplataDto.Svrha_Uplate,
                DatumUplate = uplataDto.DatumUplate,
                DatumKursa = uplataDto.DatumKursa,
                Valuta = uplataDto.Valuta,
                Vrednost = uplataDto.Vrednost
            };

            Context.Add(uplata);
            Context.SaveChanges();

            return Mapper.Map<UplataConfirmationDto>(uplata);
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

        public UplataConfirmationDto UpdateUplata(UplataUpdateDto uplataDto)
        {
            Uplata uplata = Context.Uplata.FirstOrDefault(e => e.UplataID == uplataDto.UplataID);

            if (uplata == null)
            {
                throw new EntryPointNotFoundException();
            }

            uplata.Broj_Racuna = uplataDto.Broj_Racuna;
            uplata.Poziv_Na_Broj = uplataDto.Poziv_Na_Broj;
            uplata.Iznos = uplataDto.Iznos;
            uplata.Svrha_Uplate = uplataDto.Svrha_Uplate;
            uplata.DatumUplate = uplataDto.DatumUplate;
            uplata.DatumKursa = uplataDto.DatumKursa;
            uplata.Valuta = uplataDto.Valuta;
            uplata.Vrednost = uplataDto.Vrednost;


            Context.SaveChanges();

            return Mapper.Map<UplataConfirmationDto>(uplata);
        }
    }
}
