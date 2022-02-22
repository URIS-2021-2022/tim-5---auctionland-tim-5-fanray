using KorisnikSistemaService.Helpers;
using KorisnikSistemaService.Models;
using KorisnikSistemaService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHelper AuthHelper;
        private readonly ILoggerService LoggerService;
        public AuthController(IAuthHelper authHelper, ILoggerService loggerService)
        {
            this.AuthHelper = authHelper;
            this.LoggerService = loggerService;
        }

        [HttpPost("login")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] Principal principal)
        {
            if (AuthHelper.AuthenticatePrincipal(principal))
            {
                var tokenString = AuthHelper.GenerateJwt(principal);

                LoggerService.createLogAsync("KorisnikSistema", "Auth", "POST", 200);

                return Ok(new { token = tokenString });
            }

            LoggerService.createLogAsync("KorisnikSistema", "Auth", "POST", 201);

            return Unauthorized();
        }
    }
}
