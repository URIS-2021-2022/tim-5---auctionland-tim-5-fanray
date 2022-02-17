using AutoMapper;
using LiceService.Data;
using LiceService.Entities;
using LiceService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Controllers
{
	[ApiController]
	[Route("api/v1/pravnoLice")]
	[Produces("application/json")]
	[Authorize]
	public class PravnoLiceController : ControllerBase
	{
		private readonly IPravnoLiceRepository PravnoLiceRepository;
		private readonly IMapper Mapper;

		public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, IMapper mapper)
		{
			this.PravnoLiceRepository = pravnoLiceRepository;
			this.Mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<PravnoLiceDto>> GetPravnoLiceList()
		{
			List<PravnoLice> pravnoLiceList = PravnoLiceRepository.GetPravnoLiceList();

			if (pravnoLiceList == null || pravnoLiceList.Count == 0)
			{
				return NoContent();
			}

			return Ok(Mapper.Map<List<PravnoLiceDto>>(pravnoLiceList));
		}

		[HttpGet("{pravnoLiceId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<PravnoLiceDto> GetPravnoLiceById(Guid pravnoLiceId)
		{
			PravnoLice pravnoLice = PravnoLiceRepository.GetPravnoLiceById(pravnoLiceId);

			if (pravnoLice == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<PravnoLiceDto>(pravnoLice));
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

