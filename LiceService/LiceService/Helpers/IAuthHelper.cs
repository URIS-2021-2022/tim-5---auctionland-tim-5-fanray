using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiceService.Models;

namespace LiceService.Helpers
{
    public interface IAuthHelper
    {
        bool AuthenticatePrincipal(Principal principal);
        string GenerateJwt(Principal principal);
    }
}
