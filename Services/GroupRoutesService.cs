
using IntuitiveTechTest.Constants;
using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest.Services;

public class GroupRoutesService : IGroupRoutesService
{
  private readonly DataContext context;

  public GroupRoutesService(DataContext context)
  {
    this.context = context;
  }

  public async Task AddAsync(int departureAirportGroupId, int arrivalAirportGroupId)
  {
    if (departureAirportGroupId == arrivalAirportGroupId)
    {
      throw new BadDataException("Invalid airport groups. Cannot be the same for departure and arrival.");
    }

    var groupRouteExists = await context.GroupRoutes.AnyAsync(
      gr => gr.DepartureAirportGroupId == departureAirportGroupId && gr.ArrivalAirportGroupId == arrivalAirportGroupId
    );

    if (groupRouteExists)
    {
      throw new BadDataException("Airport group route already exists.");
    }

    var departureGroup = await context.AirportGroups
      .Include(ag => ag.AirportGroupJunctions)
      .FirstOrDefaultAsync(ag => ag.Id == departureAirportGroupId);

    if (departureGroup == null)
    {
      throw new BadDataException("DepartureGroup not found.");
    }

    var departureAirportsIds = departureGroup.AirportGroupJunctions.Select(agj => agj.AirportId);

    if (!departureAirportsIds.Any())
    {
      throw new BadDataException($"No airports assigned to airport group with id {departureAirportGroupId}");
    }

    var departureAirportTypes = await context.Airports
      .Where(a => departureAirportsIds.Contains(a.Id))
      .Select(a => a.AirportType!.Type)
      .ToListAsync();

    if (departureAirportTypes.Any(type => type == AirportTypes.Arrival))
    {
      throw new BadDataException("One or more invalid departure airport type");
    }

    var arrivalGroup = await context.AirportGroups
      .Include(ag => ag.AirportGroupJunctions)
      .FirstOrDefaultAsync(ag => ag.Id == arrivalAirportGroupId);

    if (arrivalGroup == null)
    {
      throw new BadDataException("ArrivalGroup not found.");
    }

    var arrivalAirportsIds = arrivalGroup.AirportGroupJunctions.Select(agj => agj.AirportId);

    if (!arrivalAirportsIds.Any())
    {
      throw new BadDataException($"No airports assigned to airport group with id {arrivalAirportGroupId}");
    }

    var arrivalAirportTypes = await context.Airports
      .Where(a => arrivalAirportsIds.Contains(a.Id))
      .Select(a => a.AirportType!.Type)
      .ToListAsync();

    if (arrivalAirportTypes.Any(type => type == AirportTypes.Departure))
    {
      throw new BadDataException("One or more invalid arrival airport type");
    }

    var groupRoute = new GroupRoute
    {
      DepartureAirportGroupId = departureAirportGroupId,
      ArrivalAirportGroupId = arrivalAirportGroupId
    };

    context.GroupRoutes.Add(groupRoute);
  }
}
