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
    [Route("api/v1/tip")]
    [Produces("application/json")]
    [Authorize]
    public class TipZalbeController : ControllerBase
    {
        private readonly ITipZalbeRepository TipZalbeRepository;
        private readonly IMapper Mapper;

        public TipZalbeController(ITipZalbeRepository tipZalbeRepository, IMapper mapper)
        {
            this.TipZalbeRepository = tipZalbeRepository;
            this.Mapper = mapper;
        }

        /// OBJASNJENJE [1]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipZalbeDto>> GetTipZalbeList()
        {
            List<TipZalbe> tipZalbeList = TipZalbeRepository.GetTipZalbeList();

            if (tipZalbeList == null || tipZalbeList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<TipZalbeDto>>(tipZalbeList));
        }

        /// OBJASNJENJE [1]
        [HttpGet("{tipId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipZalbeDto> GetTipZalbeById(Guid tipId) 
        {
            TipZalbe tipZalbe = TipZalbeRepository.GetTipZalbeById(tipId);

            if (tipZalbe == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TipZalbeDto>(tipZalbe));
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