using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public class SluzbeniListRepository : ISluzbeniListRepository
    {
        private readonly JavnoNadmetanjeContext Context;
        private readonly IMapper Mapper;

        public SluzbeniListRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public SluzbeniListConfirmationDto CreateSluzbeniList(SluzbeniList sluzbeniList)
        {
            sluzbeniList.SluzbeniListId = Guid.NewGuid();

            Context.SluzbeniList.Add(sluzbeniList);
            Context.SaveChanges();

            return Mapper.Map<SluzbeniListConfirmationDto>(sluzbeniList);
        }

        public SluzbeniListConfirmationDto DeleteSluzbeniList(Guid sluzbeniListId)
        {
            SluzbeniList sluzbeniList = GetSluzbeniListById(sluzbeniListId);

            if (sluzbeniList == null)
            {
                throw new ArgumentNullException("sluzbeniListId");
            }

            Context.SluzbeniList.Remove(sluzbeniList);
            Context.SaveChanges();

            return Mapper.Map<SluzbeniListConfirmationDto>(sluzbeniList);
        }

        public SluzbeniList GetSluzbeniListById(Guid sluzbeniListId)
        {
            return Context.SluzbeniList.FirstOrDefault(e => e.SluzbeniListId == sluzbeniListId);
        }

        public List<SluzbeniList> GetSluzbeniListList()
        {
            return Context.SluzbeniList.ToList();
        }

        public SluzbeniListConfirmationDto UpdateSluzbeniList(SluzbeniList sluzbeniList)
        {
            SluzbeniList sl = Context.SluzbeniList.FirstOrDefault(e => e.SluzbeniListId == sluzbeniList.SluzbeniListId);

            if (sl == null)
            {
                throw new EntryPointNotFoundException();
            }

            sl.SluzbeniListId = sluzbeniList.SluzbeniListId;
            sl.Opstina = sluzbeniList.Opstina;
            sl.JavnoNadmetanjeId = sluzbeniList.JavnoNadmetanjeId;
            sl.BrojSluzbenogLista = sluzbeniList.BrojSluzbenogLista;
            sl.DatumIzdavanja = sluzbeniList.DatumIzdavanja;

            Context.SaveChanges();

            return Mapper.Map<SluzbeniListConfirmationDto>(sl);
        }
    }
}
