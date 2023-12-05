namespace IntuitiveTechTest;

public class GroupRouteResponse
{
  public int Id { get; set; }
  public int DepartureAirportGroupId { get; set; }
  public int ArrivaleAirportGroupId { get; set; }

  public static explicit operator GroupRouteResponse(GroupRoute groupRoute)
  {
    return new GroupRouteResponse
    {
      Id = groupRoute.Id,
      DepartureAirportGroupId = groupRoute.DepartureAirportGroupId,
      ArrivaleAirportGroupId = groupRoute.ArrivalAirportGroupId
    };
  }
}
