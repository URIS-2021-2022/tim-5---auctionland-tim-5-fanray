﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Models
{
    public class PrijavljenKupacUpdateDto
    {
        public Guid PrijavljenKupacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
