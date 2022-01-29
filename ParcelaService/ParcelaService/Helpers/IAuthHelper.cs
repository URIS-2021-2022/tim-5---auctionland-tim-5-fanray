using ParcelaService.Models;

namespace ParcelaService.Helpers
{
    public interface IAuthHelper
    {
        public bool AuthenticatePrincipal(Principal principal);
        public string GenerateJwt(Principal principal);
    }
}
