using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;
using UplataService.Services;

namespace UplataService.Controllers
{
    [ApiController]
    [Route("api/v1/uplata")]
    [Produces("application/json")]
    [Authorize]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository UplataRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public UplataController(IUplataRepository uplataRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.UplataRepository = uplataRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UplataDto>> GetUplataList()
        {
            List<Uplata> uplataList = UplataRepository.getUplataList();

            if (uplataList == null || uplataList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<UplataDto>>(uplataList));
        }

        [HttpGet("{uplataId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Uplata> GetUplataById(Guid uplataId)
        {
            Uplata uplata = UplataRepository.getUplataById(uplataId);

            if (uplata == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<UplataDto>(uplata));
        }


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataConfirmationDto> CreateUplata([FromBody] UplataCreateDto uplataDto)
        {
            try
            {

                Uplata uplata = Mapper.Map<Uplata>(uplataDto);
                UplataConfirmationDto confirmation = UplataRepository.CreateUplata(uplata);

               

                string location = LinkGenerator.GetPathByAction("GetUplataById", "Uplata", new { uplataId = confirmation.UplataID });

                LoggerService.createLogAsync("Uplata " + confirmation.UplataID + " je dodata");


                return Created(location, Mapper.Map<UplataConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataConfirmationDto> UpdateUplata(UplataUpdateDto uplataDto)
        {
            try
            {
                Uplata oldUplata = UplataRepository.getUplataById(uplataDto.UplataID);

                if (oldUplata == null)
                {
                    return NotFound();
                }

                Uplata uplata = Mapper.Map<Uplata>(uplataDto);

                Mapper.Map(uplata, oldUplata);

                UplataConfirmationDto confirmation = UplataRepository.UpdateUplata(uplataDto);

                LoggerService.createLogAsync("Uplata " + uplata.UplataID + " je ažurirana");

                return Ok(Mapper.Map<UplataConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    
        [HttpDelete("{uplataId}")]
        public ActionResult<UplataConfirmationDto> DeleteUplata(Guid uplataId)
        {
            try
            {
                Uplata uplata = UplataRepository.getUplataById(uplataId);

                if (uplata == null)
                {
                    return NotFound();
                }


                UplataConfirmationDto confirmation = UplataRepository.DeleteUplata(uplataId);

                LoggerService.createLogAsync("Uplata " + uplata.UplataID + " je izbrisana");

                return Ok(Mapper.Map<UplataConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
