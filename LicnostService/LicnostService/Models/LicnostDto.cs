using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicnostService.Models
{
    public class LicnostDto
    {
        public Guid LicnostID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Funkcija { get; set; }
    }
}
