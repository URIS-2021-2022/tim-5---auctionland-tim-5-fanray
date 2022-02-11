using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;
using System;
using System.Collections.Generic;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/v1/radnja")]
    [Produces("application/json")]
    [Authorize]
    public class RadnjaNaOsnovuZalbeController : ControllerBase 
    {
        private readonly IRadnjaNaOsnovuZalbeRepository RadnjaNaOsnovuZalbeRepository; 
        private readonly IMapper Mapper;

        public RadnjaNaOsnovuZalbeController(IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository, IMapper mapper) 
        {
            this.RadnjaNaOsnovuZalbeRepository = radnjaNaOsnovuZalbeRepository; 
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<RadnjaNaOsnovuZalbeDto>> GetRadnjaNaOsnovuZalbeList() 
        {
            List<RadnjaNaOsnovuZalbe> radnjaNaOsnovuZalbeList = RadnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeList(); 

            if (radnjaNaOsnovuZalbeList == null || radnjaNaOsnovuZalbeList.Count == 0) 
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<RadnjaNaOsnovuZalbeDto>>(radnjaNaOsnovuZalbeList)); 
        }

        /// OBJASNJENJE [1]
        [HttpGet("{radnjaId}")]    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RadnjaNaOsnovuZalbeDto> GetRadnjaNaOsnovuZalbeById(Guid radnjaId) 
        {
            RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe = RadnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeById(radnjaId);

            if (radnjaNaOsnovuZalbe == null) 
            {
                return NotFound();
            }

            return Ok(Mapper.Map<RadnjaNaOsnovuZalbeDto>(radnjaNaOsnovuZalbe));
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetExamRegistrationOptions()
        {
            Response.Headers.Add("Allow", "GET");

            return Ok();
        }
    }
}