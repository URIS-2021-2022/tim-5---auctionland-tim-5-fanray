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
    [Route("api/v1/tipGarancije")]
    [Produces("application/json")]
    [Authorize]
    public class TipGaranijeController : ControllerBase
    {
        private readonly ITipGarancijeRepository TipGarancijeRepository;
        private readonly IMapper Mapper;

        public TipGaranijeController(ITipGarancijeRepository tipGarancijeRepository, IMapper mapper)
        {
            this.TipGarancijeRepository = tipGarancijeRepository;
            this.Mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipGarancijeDto>> GetTipGarancijeList()
        {
            List<TipGarancije> tipGarancijeList = TipGarancijeRepository.GetTipGarancijeList();

            if (tipGarancijeList == null || tipGarancijeList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<TipGarancijeDto>>(tipGarancijeList));
        }


        [HttpGet("{tipGarancijeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipGarancijeDto> GetTipGarancijeById(Guid tipGarancijeId)
        {
            TipGarancije tipGarancije = TipGarancijeRepository.GetTipGarancijeById(tipGarancijeId);

            if (tipGarancije == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TipGarancijeDto>(tipGarancije));
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
