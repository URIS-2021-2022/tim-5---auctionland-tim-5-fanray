using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LicitacijaService.Data;
using LicitacijaService.Entities;
using LicitacijaService.Models;
using System;
using System.Collections.Generic;

namespace LicitacijaService.Controllers
{
    [ApiController]
    [Route("api/v1/dokumentacija")]
    [Produces("application/json")]
    [Authorize]
    public class DokumentacijaController : ControllerBase
    {
        private readonly IDokumentacijaRepository DokumentacijaRepository;
        private readonly IMapper Mapper;

        public DokumentacijaController(IDokumentacijaRepository dokumentacijaRepository, IMapper mapper)
        {
            this.DokumentacijaRepository = dokumentacijaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DokumentacijaDto>> GetKlasaList()
        {
            List<Dokumentacija> dokumentacijaList = DokumentacijaRepository.GetDokumentacijaList();

            if (dokumentacijaList == null || dokumentacijaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DokumentacijaDto>>(dokumentacijaList));
        }

        /// <response code="404">Klasa nije pronadjena</response>
        [HttpGet("{dokumentacijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DokumentacijaDto> GetDokumentacijaById(Guid dokumentacijaId)
        {
           Dokumentacija dokumentacija = DokumentacijaRepository.GetDokumentacijaById(dokumentacijaId);

            if (dokumentacija == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DokumentacijaDto>(dokumentacija));
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
