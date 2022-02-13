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

namespace UplataService.Controllers
{
    [ApiController]
    [Route("api/v1/uplata")]
    [Produces("application/json")]
    //[Authorize]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository UplataRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public UplataController(IUplataRepository uplataRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.UplataRepository = uplataRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
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
        public ActionResult<UplataConfirmationDto> CreateUplata([FromBody] UplataCreateDto uplataDto)
        {
            try
            {
                UplataConfirmationDto confirmation = UplataRepository.CreateUplata(uplataDto);

                string location = LinkGenerator.GetPathByAction("GetUplataById", "Uplata", new { uplataId = confirmation.UplataID });

                return Created(location, Mapper.Map<UplataConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpPut]
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

                return Ok(Mapper.Map<UplataConfirmationDto>(oldUplata));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
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

                UplataRepository.DeleteUplata(uplataId);

                return Ok(Mapper.Map<UplataConfirmationDto>(uplata));
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
