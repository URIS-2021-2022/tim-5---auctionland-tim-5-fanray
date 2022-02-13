using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Models;

namespace LicitacijaService.Helpers
{
    public interface IAuthHelper
    {
        bool AuthenticatePrincipal(Principal principal);
        string GenerateJwt(Principal principal);
    }
}
