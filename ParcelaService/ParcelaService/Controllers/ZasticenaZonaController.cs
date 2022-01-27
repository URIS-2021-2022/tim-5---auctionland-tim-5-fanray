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
    [Route("api/v1/zona")]
    public class ZasticenaZonaController : ControllerBase
    {
        private IZasticenaZonaRepository ZasticenaZonaRepository;
        private readonly IMapper Mapper;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, IMapper mapper)
        {
            this.ZasticenaZonaRepository = zasticenaZonaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ZasticenaZonaDto>> GetZasticenaZonaList()
        {
            List<ZasticenaZona> zasticenaZonaList = ZasticenaZonaRepository.GetZasticenaZonaList();

            if (zasticenaZonaList == null || zasticenaZonaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ZasticenaZonaDto>>(zasticenaZonaList));
        }

        [HttpGet("{zonaId}")]
        public ActionResult<ZasticenaZonaDto> GetZasticenaZonaById(Guid zonaId)
        {
            ZasticenaZona zasticenaZona = ZasticenaZonaRepository.GetZasticenaZonaById(zonaId);

            if (zasticenaZona == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ZasticenaZonaDto>(zasticenaZona));
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
