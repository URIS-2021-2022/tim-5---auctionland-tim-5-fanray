using AutoMapper;
using KupacService.Entities;
using KupacService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Data
{
    public class NajboljiPonudjacRepository : INajboljiPonudjacRepository
    {
        private readonly KupacContext Context;
        private readonly IMapper Mapper;

        public NajboljiPonudjacRepository(KupacContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public Najbolji_Ponudjac GetNajbolji_PonudjacById(Guid najboljiPonudjacId)
        {
            return Context.Najbolji_Ponudjac.FirstOrDefault(e => e.NajboljiPonudjacId == najboljiPonudjacId);
        }

        public List<Najbolji_Ponudjac> GetNajbolji_PonudjacList()
        {
            return Context.Najbolji_Ponudjac.ToList();
        }
        public NajboljiPonudjacConfirmationDto CreateNajboljiPonudjac(Najbolji_Ponudjac najboljiPonudjac)
        {
            najboljiPonudjac.NajboljiPonudjacId = Guid.NewGuid();

            Context.Najbolji_Ponudjac.Add(najboljiPonudjac);
            Context.SaveChanges();

            return Mapper.Map<NajboljiPonudjacConfirmationDto>(najboljiPonudjac);
        }

        public NajboljiPonudjacConfirmationDto DeleteNajboljiPonudjac(Guid najboljiPonudjacId)
        {
            Najbolji_Ponudjac najboljiPonudjac = GetNajbolji_PonudjacById(najboljiPonudjacId);

            if (najboljiPonudjac == null)
            {
                throw new ArgumentNullException("najboljiPonudjacId");
            }

            Context.Najbolji_Ponudjac.Remove(najboljiPonudjac);
            Context.SaveChanges();

            return Mapper.Map<NajboljiPonudjacConfirmationDto>(najboljiPonudjac);
        }
        public NajboljiPonudjacConfirmationDto UpdateNajboljiPonudjac(Najbolji_Ponudjac najboljiPonudjac)
        {
            Najbolji_Ponudjac np = Context.Najbolji_Ponudjac.FirstOrDefault(e => e.NajboljiPonudjacId == najboljiPonudjac.NajboljiPonudjacId);

            if (np == null)
            {
                throw new EntryPointNotFoundException();
            }

            np.NajboljiPonudjacId = najboljiPonudjac.NajboljiPonudjacId;
            np.KupacId = najboljiPonudjac.KupacId;

            Context.SaveChanges();

            return Mapper.Map<NajboljiPonudjacConfirmationDto>(np);
        }
    }
}
