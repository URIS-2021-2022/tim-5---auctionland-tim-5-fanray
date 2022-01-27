using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaService.Data;
using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/v1/klasa")]
    public class KlasaController : ControllerBase
    {
        private IKlasaRepository KlasaRepository;
        private readonly IMapper Mapper;

        public KlasaController(IKlasaRepository klasaRepository, IMapper mapper)
        {
            this.KlasaRepository = klasaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<KlasaDto>> GetKlasaList()
        {
            List<Klasa> klasaList = KlasaRepository.GetKlasaList();

            if (klasaList == null || klasaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KlasaDto>>(klasaList));
        }

        [HttpGet("{klasaId}")]
        public ActionResult<KlasaDto> GetKlasaById(Guid klasaId)
        {
            Klasa klasa = KlasaRepository.GetKlasaById(klasaId);

            if (klasa == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KlasaDto>(klasa));
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
