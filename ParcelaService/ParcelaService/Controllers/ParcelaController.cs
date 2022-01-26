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
    [Route("api/v1/parcela")]
    public class ParcelaController : ControllerBase
    {
        private IParcelaRepository ParcelaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public ParcelaController(IParcelaRepository parcelaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ParcelaRepository = parcelaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ParcelaDto>> GetParcelaList()
        {
            List<Parcela> parcelaList = ParcelaRepository.GetParcelaList();

            if (parcelaList == null || parcelaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ParcelaDto>>(parcelaList));
        }

        [HttpGet("{parcelaId}")]
        public ActionResult<Parcela> GetParcelaById(Guid parcelaId)
        {
            Parcela parcela = ParcelaRepository.GetParcelaById(parcelaId);

            if (parcela == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ParcelaDto>(parcela));
        }

        [HttpPost]
        public ActionResult<ParcelaConfirmationDto> CreateParcela([FromBody] ParcelaCreateDto parcelaDto)
        {
            try
            {
                ParcelaConfirmationDto confirmation = ParcelaRepository.CreateParcela(parcelaDto);

                string location = LinkGenerator.GetPathByAction("GetParcelaById", "Parcela", new { parcelaId = confirmation.ParcelaID });

                return Created(location, Mapper.Map<ParcelaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpPut]
        public ActionResult<ParcelaConfirmationDto> UpdateParcela(ParcelaUpdateDto parcelaDto)
        {
            try
            {
                Parcela oldParcela = ParcelaRepository.GetParcelaById(parcelaDto.ParcelaID);

                if (oldParcela == null)
                {
                    return NotFound();
                }

                Parcela parcela = Mapper.Map<Parcela>(parcelaDto);

                Mapper.Map(parcela, oldParcela);

                return Ok(Mapper.Map<ParcelaConfirmationDto>(oldParcela));
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        [HttpDelete("{parcelaId}")]
        public ActionResult<ParcelaConfirmationDto> DeleteParcela(Guid parcelaId)
        {
            try
            {
                Parcela parcela = ParcelaRepository.GetParcelaById(parcelaId);

                if (parcela == null)
                {
                    return NotFound();
                }

                ParcelaRepository.DeleteParcela(parcelaId);

                return Ok(Mapper.Map<ParcelaConfirmationDto>(parcela));
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
