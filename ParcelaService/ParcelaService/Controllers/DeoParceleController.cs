using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/v1/deo-parcele")]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository DeoParceleRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public DeoParceleController(IDeoParceleRepository deoParceleRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.DeoParceleRepository = deoParceleRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<DeoParceleDto>> GetDeoParceleList([FromQuery(Name = "parcelaId")] Guid parcelaId)
        {
            List<DeoParcele> deoParceleList = DeoParceleRepository.GetDeoParceleList(parcelaId);

            if (deoParceleList == null || deoParceleList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DeoParceleDto>>(deoParceleList));
        }

        [HttpGet("{deoParceleId}")]
        public ActionResult<DeoParceleDto> GetDeoParceleById(Guid deoParceleId)
        {
            DeoParcele deoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleId);

            if (deoParcele == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DeoParceleDto>(deoParcele));
        }

        [HttpPost]
        public ActionResult<DeoParceleConfirmationDto> CreateDeoParcele([FromBody] DeoParceleCreateDto deoParceleDto)
        {
            try
            {
                DeoParcele deoParcele = Mapper.Map<DeoParcele>(deoParceleDto);
                DeoParceleConfirmationDto confirmation = DeoParceleRepository.CreateDeoParcele(deoParcele);

                string location = LinkGenerator.GetPathByAction("GetDeoParceleById", "DeoParcele", new { deoParceleId = confirmation.DeoParceleID });

                return Created(location, Mapper.Map<DeoParceleConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<DeoParceleConfirmationDto> UpdateDeoParcele(DeoParceleUpdateDto deoParceleDto)
        {
            try
            {
                DeoParcele oldDeoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleDto.DeoParceleID);

                if (oldDeoParcele == null)
                {
                    return NotFound();
                }

                DeoParcele deoParcele = Mapper.Map<DeoParcele>(deoParceleDto);

                Mapper.Map(deoParcele, oldDeoParcele);

                DeoParceleConfirmationDto confirmation = DeoParceleRepository.UpdateDeoParcele(deoParcele);

                return Ok(Mapper.Map<DeoParceleConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{deoParceleId}")]
        public ActionResult<DeoParceleConfirmationDto> DeleteDeoParcele(Guid deoParceleId)
        {
            try
            {
                DeoParcele deoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleId);

                if (deoParcele == null)
                {
                    return NotFound();
                }

                DeoParceleConfirmationDto confirmation = DeoParceleRepository.DeleteDeoParcele(deoParceleId);

                return Ok(Mapper.Map<DeoParceleConfirmationDto>(confirmation));
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
