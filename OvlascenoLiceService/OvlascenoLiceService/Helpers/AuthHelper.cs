using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OvlascenoLiceService.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration Configuration;
        private readonly IKorisnikRepository KorisnikRepository;

        public AuthHelper(IConfiguration configuration, IKorisnikRepository korisnikRepository)
        {
            this.Configuration = configuration;
            this.KorisnikRepository = korisnikRepository;
        }

        public bool AuthenticatePrincipal(Principal principal)
        {
            return KorisnikRepository.UserWithCredentialsExists(principal.KorisnickoIme, principal.Lozinka);
        }

        public string GenerateJwt(Principal principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}