using LicitacijaService.Models;
using System;
using LicitacijaService.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LicitacijaService.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        public bool AuthenticatePrincipal(Principal principal)
        {
            throw new NotImplementedException();
        }

        public string GenerateJwt(Principal principal)
        {
            throw new NotImplementedException();
        }
    }
}
