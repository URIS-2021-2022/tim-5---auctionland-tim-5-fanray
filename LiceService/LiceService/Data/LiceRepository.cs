using AutoMapper;
using LiceService.Entities;
using LiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public class LiceRepository : ILiceRepository
    {


  private readonly LiceContext Context;
        private readonly IMapper Mapper;

        public LiceRepository(LiceContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public LiceConfirmationDto CreateLice(Lice lice)
        {
            lice.LiceID = Guid.NewGuid();

            Context.Lice.Add(lice);
            Context.SaveChanges();

            return Mapper.Map<LiceConfirmationDto>(lice);
        }

        public LiceConfirmationDto DeleteLice(Guid liceId)
        {
            Lice lice = GetLiceById(liceId);

            if (lice == null)
            {
                throw new ArgumentNullException("liceId");
            }

            Context.Lice.Remove(lice);
            Context.SaveChanges();

            return Mapper.Map<LiceConfirmationDto>(lice);
        }

        public Lice GetLiceById(Guid liceId)
        {
            return Context.Lice.FirstOrDefault(e => e.LiceID == liceId);
        }

        public List<Lice> GetLiceList()
        {
            return Context.Lice.ToList();
        }

        public LiceConfirmationDto UpdateLice(Lice lice)
        {
            Lice l = Context.Lice.FirstOrDefault(e => e.LiceID == lice.LiceID);

            if (l == null)
            {
                throw new EntryPointNotFoundException();
            }

            l.Broj_Telefona1 = lice.Broj_Telefona1;
            l.Broj_Telefona2 = lice.Broj_Telefona2;
            l.Email = lice.Email;
            l.Broj_Racuna= lice.Broj_Racuna;


            Context.SaveChanges();

            return Mapper.Map<LiceConfirmationDto>(l);
        }
    }
    }