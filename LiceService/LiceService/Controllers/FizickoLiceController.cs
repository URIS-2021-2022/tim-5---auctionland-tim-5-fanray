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
[Route("api/v1/fizickolice")]
[Produces("application/json")]
[Authorize]
public class FizickoLiceController : ControllerBase
{
	private readonly IFizickoLiceRepository FizickoLiceRepository;
	private readonly IMapper Mapper;

	public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, IMapper mapper)
	{
		this.FizickoLiceRepository = fizickoLiceRepository;
		this.Mapper = mapper;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public ActionResult<List<FizickoLiceDto>> GetFizickoLiceList()
	{
		List<FizickoLice> fizickoLiceList = FizickoLiceRepository.GetFizickoLiceList();

		if (fizickoLiceList == null || fizickoLiceList.Count == 0)
		{
			return NoContent();
		}

		return Ok(Mapper.Map<List<FizickoLiceDto>>(fizickoLiceList));
	}


	[HttpGet("{fizickoLiceId}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public ActionResult<FizickoLiceDto> GetFizickoLiceById(Guid fizickoLiceId)
	{
		FizickoLice fizickoLice = FizickoLiceRepository.GetFizickoLiceById(fizickoLiceId);

		if (fizickoLice == null)
		{
			return NotFound();
		}

		return Ok(Mapper.Map<FizickoLiceDto>(fizickoLice));
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
