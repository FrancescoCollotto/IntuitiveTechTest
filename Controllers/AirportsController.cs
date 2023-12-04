using IntuitiveTechTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportsController : ControllerBase
{

  private readonly IAirportsService airportsService;

  public AirportsController(IAirportsService airportsService)
  {
    this.airportsService = airportsService;
  }

  [HttpGet]
  public async Task<ActionResult<List<AirportsResponse>>> ListAsync()
  {
    var airportsResponse = await airportsService.ListAsync();

    return Ok(airportsResponse);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AirportResponse>> GetAsync(int id)
  {
    try
    {
      var airportResponse = await airportsService.GetByIdAsync(id);
      return Ok(airportResponse);
    }
    catch (NotFoundException ex)
    {
      return NotFound(ex.Message);
    }
  }
}
