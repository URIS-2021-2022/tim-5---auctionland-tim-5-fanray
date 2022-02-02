﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LicitacijaService.Data;
using LicitacijaService.Entities;
using LicitacijaService.Models;
using System;
using System.Collections.Generic;

namespace LicitacijaService.Controllers
{
    [ApiController]
    [Route("api/v1/licitacija")]
    public class LicitacijaController : ControllerBase
    {
        private ILicitacijaRepository LicitacijaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.LicitacijaRepository = licitacijaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<LicitacijaDto>> GetLicitacijaList()
        {
            List<Licitacija> licitacijaList = LicitacijaRepository.getLicitacijaList();

            if (licitacijaList == null || licitacijaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<LicitacijaDto>>(licitacijaList));
        }

        [HttpGet("{licitacijaId}")]
        public ActionResult<Licitacija> GetLicitacijaById(Guid licitacijaId)
        {
            Licitacija licitacija = LicitacijaRepository.getLicitacijaById(licitacijaId);

            if (licitacija == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LicitacijaDto>(licitacija));
        }

        [HttpPost]
        public ActionResult<LicitacijaConfirmationDto> CreateLicitacija([FromBody] LicitacijaCreateDto licitacijaDto)
        {
            try
            {
               LicitacijaConfirmationDto confirmation = LicitacijaRepository.CreateLicitacija(licitacijaDto);

                string location = LinkGenerator.GetPathByAction("GetLicitacijaById", "Licitacija", new { licitacijaId = confirmation.LicitacijaID });

                return Created(location, Mapper.Map<LicitacijaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpPut]
        public ActionResult<LicitacijaConfirmationDto> UpdateLicitacija(LicitacijaUpdateDto licitacijaDto)
        {
            try
            {
                Licitacija oldLicitacija = LicitacijaRepository.getLicitacijaById(licitacijaDto.LicitacijaID);

                if (oldLicitacija == null)
                {
                    return NotFound();
                }

                Licitacija licitacija = Mapper.Map<Licitacija>(licitacijaDto);

                Mapper.Map(licitacija, oldLicitacija);

                return Ok(Mapper.Map<LicitacijaConfirmationDto>(oldLicitacija));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        [HttpDelete("{licitacijaId}")]
        public ActionResult<LicitacijaConfirmationDto> DeleteParcela(Guid licitacijaId)
        {
            try
            {
                Licitacija licitacija = LicitacijaRepository.getLicitacijaById(licitacijaId);

                if (licitacija == null)
                {
                    return NotFound();
                }

                LicitacijaRepository.DeleteLicitacija(licitacijaId);

                return Ok(Mapper.Map<LicitacijaConfirmationDto>(licitacija));
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