using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelaService.Helpers;
using ParcelaService.Models;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHelper AuthHelper;

        public AuthController(IAuthHelper authnHelper)
        {
            this.AuthHelper = authnHelper;
        }

        /// <summary>
        /// Prijava u sistem
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca token korisnika</response>
        /// <response code="401">Autentifikacija nije uspjela</response>
        [HttpPost("login")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] Principal principal)
        {
            if (AuthHelper.AuthenticatePrincipal(principal))
            {
                var tokenString = AuthHelper.GenerateJwt(principal);

                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
    }
}
