using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;

namespace OvlascenoLice.Controllers
{
    [ApiController]
    [Route("api/v1/tabla")]
    [Produces("application/json")]
    [Authorize]
    public class BrojTableController : ControllerBase 
    {
        private readonly IBrojTableRepository BrojTableRepository;
        private readonly IMapper Mapper;

        public BrojTableController(IBrojTableRepository brojTableRepository, IMapper mapper)
        {
            this.BrojTableRepository = brojTableRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<BrojTableDto>> GetBrojTableList()
        {
            List<BrojTable> brojTableList = BrojTableRepository.GetBrojTableList();

            if (brojTableList == null || brojTableList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<BrojTableDto>>(brojTableList));
        }

        /// OBJASNJENJE [1]
        [HttpGet("{tablaId}")]   
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BrojTableDto> GetBrojTableById(Guid brojTableId)
        {
            BrojTable brojTable = BrojTableRepository.GetBrojTableById(brojTableId); 

            if (brojTable == null) 
            {
                return NotFound();
            }
             
            return Ok(Mapper.Map<BrojTableDto>(brojTable));
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