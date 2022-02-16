using AutoMapper;
using LiceService.Data;
using LiceService.Entities;
using LiceService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Controllers
{
    [ApiController]
    [Route("api/v1/lice")]
    [Produces("application/json")]
    //[Authorize]
    public class LiceController : ControllerBase
    {
        private readonly ILiceRepository LiceRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public LiceController(ILiceRepository liceRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.LiceRepository = liceRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<LiceDto>> GetUplataList()
        {
            List<Lice> liceList = LiceRepository.GetLiceList();

            if (liceList == null || liceList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<LiceDto>>(liceList));
        }


        [HttpGet("{liceId}")]
        public ActionResult<Lice> GetLiceById(Guid liceId)
        {
            Lice lice = LiceRepository.GetLiceById(liceId);

            if (lice == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LiceDto>(lice));
        }
        [HttpPost]
        public ActionResult<LiceConfirmationDto> CreateLice([FromBody] LiceCreateDto liceDto)
        {
            try
            {
                Lice lice = Mapper.Map<Lice>(liceDto);

                LiceConfirmationDto confirmation = LiceRepository.CreateLice(lice);

                string location = LinkGenerator.GetPathByAction("GetLiceById", "Lice", new { liceId = confirmation.LiceID });

                return Created(location, Mapper.Map<LiceConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpPut]
        public ActionResult<LiceConfirmationDto> LiceUplata(LiceUpdateDto liceDto)
        {
            try
            {
                Lice oldLice = LiceRepository.GetLiceById(liceDto.LiceID);

                if (oldLice == null)
                {
                    return NotFound();
                }

                Lice lice = Mapper.Map<Lice>(liceDto);

                Mapper.Map(lice, oldLice);

                return Ok(Mapper.Map<LiceConfirmationDto>(oldLice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }
        [HttpDelete("{liceId}")]
        public ActionResult<LiceConfirmationDto> DeleteLice(Guid liceId)
        {
            try
            {
                Lice lice = LiceRepository.GetLiceById(liceId);

                if (lice == null)
                {
                    return NotFound();
                }

                LiceRepository.DeleteLice(liceId);

                return Ok(Mapper.Map<LiceConfirmationDto>(lice));
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
            Response.Headers.Add("Allow", "GET");

            return Ok();
        }
    }
}