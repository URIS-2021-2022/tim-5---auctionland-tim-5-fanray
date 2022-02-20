using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class SluzbeniList
    {
        [Key]
        public Guid SluzbeniListId { get; set; }

        public string Opstina { get; set; }

        public string BrojSluzbenogLista { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        public Guid JavnoNadmetanjeId { get; set; }

    }
}
