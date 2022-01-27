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
    [Route("api/v1/katastar")]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private IKatastarskaOpstinaRepository KatastarskaOpstinaRepository;
        private readonly IMapper Mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaRepository, IMapper mapper)
        {
            this.KatastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<KatastarskaOpstinaDto>> GetKatastarskaOpstinaList()
        {
            List<KatastarskaOpstina> katastarskaOpstinaList = KatastarskaOpstinaRepository.GetKatastarskaOpstinaList();

            if (katastarskaOpstinaList == null || katastarskaOpstinaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KatastarskaOpstinaDto>>(katastarskaOpstinaList));
        }

        [HttpGet("{katastarId}")]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid katastarId)
        {
            KatastarskaOpstina katastarskaOpstina = KatastarskaOpstinaRepository.GetKatastarskaOpstinaById(katastarId);

            if (katastarskaOpstina == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
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
