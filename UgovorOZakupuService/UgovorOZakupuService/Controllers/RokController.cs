using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Controllers
{
        [ApiController]
        [Route("api/v1/rok")]
        [Produces("application/json")]
        [Authorize]
        public class RokController : ControllerBase
        {
            private readonly IRokRepository RokRepository;
            private readonly IMapper Mapper;

            public RokController(IRokRepository rokRepository, IMapper mapper)
            {
                this.RokRepository = rokRepository;
                this.Mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult<List<RokDto>> GetRokList()
            {
                List<Rok> rokList = RokRepository.GetRokList();

                if (rokList == null || rokList.Count == 0)
                {
                    return NoContent();
                }

                return Ok(Mapper.Map<List<RokDto>>(rokList));
            }


            [HttpGet("{rokId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<RokDto> GetRokById(Guid rokId)
            {
                Rok rok = RokRepository.GetRokById(rokId);

                if (rok == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<RokDto>(rok));
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
