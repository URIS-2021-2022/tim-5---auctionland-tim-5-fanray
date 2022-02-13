using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Helpers
{
    public interface IAuthHelper
    {
        bool AuthenticatePrincipal(Principal principal);
        string GenerateJwt(Principal principal);
    }
}
