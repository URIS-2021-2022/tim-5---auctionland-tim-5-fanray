using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Models
{
    public class SluzbeniListUpdateDto
    {
        public Guid SluzbeniListId { get; set; }

        public string Opstina { get; set; }

        public string BrojSluzbenogLista { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        public Guid JavnoNadmetanjeId { get; set; }
    }
}
