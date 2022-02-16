using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Data
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly UgovorContext Context;

        public DokumentRepository(UgovorContext context)
        {
            this.Context = context;
        }

        public List<Dokument> GetDokumentList()
        {

            return Context.Dokument.ToList();
        }

        public Dokument GetDokumentById(Guid dokumentId)
        {
            return Context.Dokument.FirstOrDefault(e => e.DokumentID == dokumentId);
        }
    }
}
