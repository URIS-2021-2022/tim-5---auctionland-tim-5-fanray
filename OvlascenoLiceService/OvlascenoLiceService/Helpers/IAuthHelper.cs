using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Helpers
{
    public interface IAuthHelper
    {
        bool AuthenticatePrincipal(Principal principal);
        string GenerateJwt(Principal principal);
    }
}