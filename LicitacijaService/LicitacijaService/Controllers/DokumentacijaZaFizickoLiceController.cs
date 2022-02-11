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
    [Route("api/v1/fizicko")]
    [Produces("application/json")]
    [Authorize]
    public class DokumentacijaZaFizickoLiceController : ControllerBase
    {
        private readonly IDokumentacijaZaFizickoLiceRepository DokumentacijaZaFizickoLiceRepository;
        private readonly IMapper Mapper;

        public DokumentacijaZaFizickoLiceController(IDokumentacijaZaFizickoLiceRepository dokumentacijaZaFizickoLiceRepository, IMapper mapper)
        {
            this.DokumentacijaZaFizickoLiceRepository = dokumentacijaZaFizickoLiceRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DokumentacijaZaFizickoLiceDto>> GetDokumentacijaZaFizickoLiceList()
        {
            List<DokumentacijaZaFizickoLice> dokumentacijaZaFizickoLiceList = DokumentacijaZaFizickoLiceRepository.GetDokumentacijaZaFizickoLiceList();

            if (dokumentacijaZaFizickoLiceList == null || dokumentacijaZaFizickoLiceList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DokumentacijaZaFizickoLiceDto>>(dokumentacijaZaFizickoLiceList));
        }

        /// <response code="404">Klasa nije pronadjena</response>
        [HttpGet("{dokumentacijaFlId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DokumentacijaZaFizickoLiceDto> GetDokumentacijaZaFizickoLiceById(Guid dokumentacijaFlId)
        {
            DokumentacijaZaFizickoLice dokumentacijaZaFizickoLice = DokumentacijaZaFizickoLiceRepository.GetDokumentacijaZaFizickoLiceById(dokumentacijaFlId);

            if (dokumentacijaZaFizickoLice == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DokumentacijaZaFizickoLiceDto>(dokumentacijaZaFizickoLice));
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
