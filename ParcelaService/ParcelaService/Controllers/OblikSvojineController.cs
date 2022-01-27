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
    [Route("api/v1/svojina")]
    public class OblikSvojineController : ControllerBase
    {
        private IOblikSvojineRepository OblikSvojineRepository;
        private readonly IMapper Mapper;

        public OblikSvojineController(IOblikSvojineRepository oblikSvojineRepository, IMapper mapper)
        {
            this.OblikSvojineRepository = oblikSvojineRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OblikSvojineDto>> GetOblikSvojineList()
        {
            List<OblikSvojine> oblikSvojineList = OblikSvojineRepository.GetOblikSvojineList();

            if (oblikSvojineList == null || oblikSvojineList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<OblikSvojineDto>>(oblikSvojineList));
        }

        [HttpGet("{svojinaId}")]
        public ActionResult<OblikSvojineDto> GetOblikSvojineById(Guid svojinaId)
        {
            OblikSvojine oblikSvojine = OblikSvojineRepository.GetOblikSvojineById(svojinaId);

            if (oblikSvojine == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OblikSvojineDto>(oblikSvojine));
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
