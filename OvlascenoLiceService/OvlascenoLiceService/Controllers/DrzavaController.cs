using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;

namespace OvlascenoLice.Controllers
{
    [ApiController]
    [Route("api/v1/drzava")]
    [Produces("application/json")]
    [Authorize]
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaRepository DrzavaRepository; 
        private readonly IMapper Mapper;

        public DrzavaController(IDrzavaRepository drzavaRepository, IMapper mapper) 
        {
            this.DrzavaRepository = drzavaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DrzavaDto>> GetDrzavaList()
        {
            List<Drzava> drzavaList = DrzavaRepository.GetDrzavaList();

            if (drzavaList == null || drzavaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DrzavaDto>>(drzavaList));
        }

        /// OBJASNJENJE [1]
        [HttpGet("{drzavaId}")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DrzavaDto> GetDrzavaById(Guid drzavaId) 
        {
            Drzava drzava = DrzavaRepository.GetDrzavaById(drzavaId);

            if (drzava == null)
            {
                return NotFound();
            }
             
            return Ok(Mapper.Map<DrzavaDto>(drzava));
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