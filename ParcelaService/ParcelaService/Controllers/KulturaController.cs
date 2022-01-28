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
    [Route("api/v1/kultura")]
    public class KulturaController : ControllerBase
    {
        private readonly IKulturaRepository KulturaRepository;
        private readonly IMapper Mapper;

        public KulturaController(IKulturaRepository kulturaRepository, IMapper mapper)
        {
            this.KulturaRepository = kulturaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<KulturaDto>> GetKulturaList()
        {
            List<Kultura> kulturaList = KulturaRepository.GetKulturaList();

            if (kulturaList == null || kulturaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KulturaDto>>(kulturaList));
        }

        [HttpGet("{kulturaId}")]
        public ActionResult<KulturaDto> GetKulturaById(Guid kulturaId)
        {
            Kultura kultura = KulturaRepository.GetKulturaById(kulturaId);

            if (kultura == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KulturaDto>(kultura));
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
