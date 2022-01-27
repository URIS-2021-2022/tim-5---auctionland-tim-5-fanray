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
    [Route("api/v1/obradivost")]
    public class ObradivostController : ControllerBase
    {
        private IObradivostRepository ObradivostRepository;
        private readonly IMapper Mapper;

        public ObradivostController(IObradivostRepository obradivostRepository, IMapper mapper)
        {
            this.ObradivostRepository = obradivostRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ObradivostDto>> GetObradivostList()
        {
            List<Obradivost> obradivostList = ObradivostRepository.GetObradivostList();

            if (obradivostList == null || obradivostList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ObradivostDto>>(obradivostList));
        }

        [HttpGet("{obradivostId}")]
        public ActionResult<ObradivostDto> GetObradivostById(Guid obradivostId)
        {
            Obradivost obradivost = ObradivostRepository.GetObradivostById(obradivostId);

            if (obradivost == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ObradivostDto>(obradivost));
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
