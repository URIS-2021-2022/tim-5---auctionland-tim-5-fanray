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
    [Route("api/v1/pravno")]
    [Produces("application/json")]
    [Authorize]
    public class DokumentacijaZaPravnoLiceController : ControllerBase
    {

        private readonly IDokumentacijaZaPravnoLiceRepository DokumentacijaZaPravnoLiceRepository;
        private readonly IMapper Mapper;

        public DokumentacijaZaPravnoLiceController(IDokumentacijaZaPravnoLiceRepository dokumentacijaZaPravnoLiceRepository, IMapper mapper)
        {
            this.DokumentacijaZaPravnoLiceRepository = dokumentacijaZaPravnoLiceRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DokumentacijaZaPravnoLiceDto>> GetDokumentacijaZaPravnoLiceList()
        {
            List<DokumentacijaZaPravnoLice> dokumentacijaZaPravnoLiceList = DokumentacijaZaPravnoLiceRepository.GetDokumentacijaZaPravnoLiceList();

            if (dokumentacijaZaPravnoLiceList == null || dokumentacijaZaPravnoLiceList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DokumentacijaZaPravnoLiceDto>>(dokumentacijaZaPravnoLiceList));
        }

        /// <response code="404">Klasa nije pronadjena</response>
        [HttpGet("{dokumentacijaPlId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DokumentacijaZaPravnoLiceDto> GetDokumentacijaZaPravnoLiceById(Guid dokumentacijaPlId)
        {
            DokumentacijaZaPravnoLice dokumentacijaZaPravnoLice = DokumentacijaZaPravnoLiceRepository.GetDokumentacijaZaPravnoLiceById(dokumentacijaPlId);

            if (dokumentacijaZaPravnoLice == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DokumentacijaZaPravnoLiceDto>(dokumentacijaZaPravnoLice));
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
