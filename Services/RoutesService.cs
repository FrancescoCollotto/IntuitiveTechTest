
using IntuitiveTechTest.Constants;
using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest.Services;

public class RoutesService : IRoutesService
{
  private readonly DataContext context;

  public RoutesService(DataContext context)
  {
    this.context = context;
  }

  public async Task AddAsync(int departureAirportId, int arrivalAirportId)
  {
    if (departureAirportId == arrivalAirportId)
    {
      throw new BadDataException("Invalid airports. Cannot be the same for departure and arrival.");
    }

    var routeExists = await context.Routes.AnyAsync(
      route => route.DepartureAirportId == departureAirportId && route.ArrivalAirportId == arrivalAirportId
    );

    if (routeExists )
    {
      throw new BadDataException("Airports route already exists.");
    }

    var departureAirport = await context.Airports
      .Include(a => a.AirportType)
      .FirstOrDefaultAsync(airport => airport.Id == departureAirportId);

    if (departureAirport == null)
    {
      throw new BadDataException("Departure airport not found.");
    }

    if (departureAirport.AirportType!.Type!.Equals(AirportTypes.Arrival))
    {
      throw new BadDataException("Invalid departure airport type");
    }

    var arrivalAirport = await context.Airports
      .Include(a => a.AirportType)
      .FirstOrDefaultAsync(airport => airport.Id == arrivalAirportId);

    if (arrivalAirport == null)
    {
      throw new BadDataException("Arrival airport not found.");
    }

    if (arrivalAirport.AirportType!.Type!.Equals(AirportTypes.Departure))
    {
      throw new BadDataException("Invalid arrival airport type");
    }

    var route = new Route
    {
      DepartureAirportId = departureAirportId,
      ArrivalAirportId = arrivalAirportId
    };

    context.Routes.Add(route);
  }
}
