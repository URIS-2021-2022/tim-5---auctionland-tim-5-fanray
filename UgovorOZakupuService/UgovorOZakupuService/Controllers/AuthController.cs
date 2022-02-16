﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Helpers;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Controllers
{   
        [ApiController]
        [Route("api/v1/auth")]
        [Produces("application/json")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthHelper AuthHelper;

            public AuthController(IAuthHelper authHelper)
            {
                this.AuthHelper = authHelper;
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

                    return Ok(new { token = tokenString });
                }

                return Unauthorized();
            }
        }
}
