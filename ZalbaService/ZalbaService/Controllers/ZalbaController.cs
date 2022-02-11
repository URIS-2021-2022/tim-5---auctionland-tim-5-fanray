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
    [Route("api/v1/zalba")]
    public class ZalbaController : ControllerBase
    {
        private IZalbaRepository ZalbaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        
        public ZalbaController(IZalbaRepository zalbaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ZalbaRepository = zalbaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<ZalbaDto>> GetZalbaList()
        {
            List<Zalba> zalbaList = ZalbaRepository.GetZalbaList();

            if (zalbaList == null || zalbaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ZalbaDto>>(zalbaList));
        }
        
        [HttpGet("{zalbaId}")]
        public ActionResult<Zalba> GetZalbaById(Guid zalbaId)
        {
            Zalba zalba = ZalbaRepository.GetZalbaById(zalbaId);

            if (zalba == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ZalbaDto>(zalba));
        }

        [HttpPost]
        public ActionResult<ZalbaConfirmationDto> CreateZalba([FromBody] ZalbaCreateDto zalbaDto)
        {
            try
            {
                Zalba zalba = Mapper.Map<Zalba>(zalbaDto);
                ZalbaConfirmationDto confirmation = ZalbaRepository.CreateZalba(zalba);

                string location = LinkGenerator.GetPathByAction("GetZalbaById", "Zalba", new { zalbaId = confirmation.ZalbaID });

                return Created(location, Mapper.Map<ZalbaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpPut]
        public ActionResult<ZalbaConfirmationDto> UpdateZalba(ZalbaUpdateDto zalbaDto)
        {
            try
            {
                Zalba oldZalba = ZalbaRepository.GetZalbaById(zalbaDto.ZalbaID);

                if (oldZalba == null)
                {
                    return NotFound();
                }

                Zalba zalba = Mapper.Map<Zalba>(zalbaDto);

                Mapper.Map(zalba, oldZalba);

                return Ok(Mapper.Map<ZalbaConfirmationDto>(oldZalba));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        [HttpDelete("{zalbaId}")]
        public ActionResult<ZalbaConfirmationDto> DeleteZalba(Guid zalbaId)
        {
            try
            {
                Zalba zalba = ZalbaRepository.GetZalbaById(zalbaId);

                if (zalba == null)
                {
                    return NotFound();
                }

                ZalbaRepository.DeleteZalba(zalbaId);

                return Ok(Mapper.Map<ZalbaConfirmationDto>(zalba));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetExamRegistrationOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}