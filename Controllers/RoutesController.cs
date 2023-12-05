using IntuitiveTechTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntuitiveTechTest.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutesController : ControllerBase
{
  private readonly IRoutesService routesService;
  private readonly IGroupRoutesService groupRoutesService;
  private readonly DataContext context;

  public RoutesController(
    IRoutesService routesService, 
    IGroupRoutesService groupRoutesService, 
    DataContext context)
  {
    this.routesService = routesService;
    this.groupRoutesService = groupRoutesService;
    this.context = context;
  }

  [HttpGet]
  public async Task<ActionResult<RoutesResponse>> ListAsync()
  {
    var airportRoutesResponse = await routesService.ListAsync();
    var groupRouteResponse = await groupRoutesService.ListAsync();

    var routesResponse = new RoutesResponse
    {
      AirportRoutes = airportRoutesResponse,
      AirportGroupRoutes = groupRouteResponse
    };

    return Ok(routesResponse);
  }

  [HttpPost]
  public async Task<ActionResult> AddAsync(AddRouteRequest addRouteRequest)
  {
    try
    {
      addRouteRequest.Validate();

      if (addRouteRequest.DepartureAirportId != null && addRouteRequest.ArrivalAirportId != null)
      {
          await routesService.AddAsync((int)addRouteRequest.DepartureAirportId, (int)addRouteRequest.ArrivalAirportId);
      }
      if (addRouteRequest.DepartureAirportGroupId != null && addRouteRequest.ArrivalAirportGroupId != null)
      {
          await groupRoutesService.AddAsync((int)addRouteRequest.DepartureAirportGroupId, (int)addRouteRequest.ArrivalAirportGroupId);
      }

      await context.SaveChangesAsync();

      return Ok("Routes processed successfully.");
    }
    catch (BadDataException ex)
    {
        return BadRequest(ex.Message);
    }
  } 
}
