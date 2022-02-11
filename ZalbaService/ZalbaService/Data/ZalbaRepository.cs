using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZalbaService.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
       private readonly ZalbaContext Context;
       private readonly IMapper Mapper;

        public ZalbaRepository(ZalbaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Zalba> GetZalbaList()
        {
            return Context.Zalba.ToList();
        }

        public Zalba GetZalbaById(Guid zalbaId)
        {
            return Context.Zalba.FirstOrDefault(e => e.ZalbaID == zalbaId);
        }

        public ZalbaConfirmationDto CreateZalba(Zalba zalba)
        {
            zalba.ZalbaID = Guid.NewGuid();

            Context.Zalba.Add(zalba);
            Context.SaveChanges();

            return Mapper.Map<ZalbaConfirmationDto>(zalba);
        }

        public ZalbaConfirmationDto UpdateZalba(Zalba zalba)
        {
            Zalba z = Context.Zalba.FirstOrDefault(e => e.ZalbaID == zalba.ZalbaID);

            if (z == null)
            {
                throw new EntryPointNotFoundException();
            }

            z.Datum_Podnosenja_Zalbe = zalba.Datum_Podnosenja_Zalbe;
            z.Razlog_Podnosenja_Zalbe = zalba.Razlog_Podnosenja_Zalbe;
            z.Obrazlozenje = zalba.Obrazlozenje;
            z.Datum_Resenja = zalba.Datum_Resenja;
            z.Broj_Resenja = zalba.Broj_Resenja;
            z.Broj_Nadmetanja = zalba.Broj_Nadmetanja;
            z.RadnjaNaOsnovuZalbeID = zalba.RadnjaNaOsnovuZalbeID;
            z.StatusZalbeID = zalba.StatusZalbeID;
            z.TipZalbeID = zalba.TipZalbeID;

            Context.SaveChanges();

            return Mapper.Map<ZalbaConfirmationDto>(z);
        }
      
        public ZalbaConfirmationDto DeleteZalba(Guid zalbaId)
        {
            Zalba zalba = GetZalbaById(zalbaId);

            if (zalba == null)
            {
                throw new ArgumentNullException("zalbaId");
            }

            Context.Zalba.Remove(zalba);
            Context.SaveChanges();

            return Mapper.Map<ZalbaConfirmationDto>(zalba);
        }
    }
}