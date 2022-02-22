using Microsoft.AspNetCore.Http;
using ParcelaService.Models;

namespace ParcelaService.Helpers
{
    public interface IAuthHelper
    {
        bool AuthenticatePrincipal(Principal principal);
        string GenerateJwt(Principal principal);
        string GetToken(HttpRequest request);
    }
}
