﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Services
{
   public interface ILoggerService
    {
        Task createLogAsync(string opis);

    }
}
