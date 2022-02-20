using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Services
{
   public interface ILoggerService
    {
        Task createLogAsync(string opis);

    }
}
