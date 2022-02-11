using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;
using System;
using System.Collections.Generic;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/v1/status")]
    [Produces("application/json")]
    [Authorize]
    public class StatusZalbeController : ControllerBase
    {
        private readonly IStatusZalbeRepository StatusZalbeRepository;
        private readonly IMapper Mapper;

        public StatusZalbeController(IStatusZalbeRepository statusZalbeRepository, IMapper mapper)
        {
            this.StatusZalbeRepository = statusZalbeRepository;
            this.Mapper = mapper;
        }

        /// OBJASNJENJE [1]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<StatusZalbeDto>> GetStatusZalbeList()
        {
            List<StatusZalbe> statusZalbeList = StatusZalbeRepository.GetStatusZalbeList();

            if (statusZalbeList == null || statusZalbeList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<StatusZalbeDto>>(statusZalbeList));
        }

        /// OBJASNJENJE [1]
        [HttpGet("{statusId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StatusZalbeDto> GetStatusZalbeById(Guid statusId)
        {
            StatusZalbe statusZalbe = StatusZalbeRepository.GetStatusZalbeById(statusId);

            if (statusZalbe == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<StatusZalbeDto>(statusZalbe));
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