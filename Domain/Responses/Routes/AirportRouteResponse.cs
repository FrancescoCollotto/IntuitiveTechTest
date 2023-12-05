namespace IntuitiveTechTest;

public class AirportRouteResponse
{
  public int Id { get; set; }
  public int DepartureAirportId { get; set; }
  public int ArrivalAirportId { get; set; }

  public static explicit operator AirportRouteResponse(Route route)
  {
    return new AirportRouteResponse
    {
      Id = route.Id,
      DepartureAirportId = route.DepartureAirportId,
      ArrivalAirportId = route.ArrivalAirportId
    };
  }
}
