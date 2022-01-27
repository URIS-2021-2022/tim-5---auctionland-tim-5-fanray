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
    [Route("api/v1/odvodnjavanje")]
    public class OdvodnjavanjeController : ControllerBase
    {
        private IOdvodnjavanjeRepository OdvodnjavanjeRepository;
        private readonly IMapper Mapper;

        public OdvodnjavanjeController(IOdvodnjavanjeRepository odvodnjavanjeRepository, IMapper mapper)
        {
            this.OdvodnjavanjeRepository = odvodnjavanjeRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OdvodnjavanjeDto>> GetOdvodnjavanjeList()
        {
            List<Odvodnjavanje> odvodnjavanjeList = OdvodnjavanjeRepository.GetOdvodnjavanjeList();

            if (odvodnjavanjeList == null || odvodnjavanjeList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<OdvodnjavanjeDto>>(odvodnjavanjeList));
        }

        [HttpGet("{odvodnjavanjeId}")]
        public ActionResult<OdvodnjavanjeDto> GetOdvodnjavanjeById(Guid odvodnjavanjeId)
        {
            Odvodnjavanje odvodnjavanje = OdvodnjavanjeRepository.GetOdvodnjavanjeById(odvodnjavanjeId);

            if (odvodnjavanje == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));
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
