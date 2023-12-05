using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class AddRouteRequest
{
  public int? DepartureAirportId { get; set; }
  public int? ArrivalAirportId { get; set; }
  public int? DepartureAirportGroupId { get; set; }
  public int? ArrivalAirportGroupId { get; set; }

  public void Validate()
  {
    if ((DepartureAirportId == null || ArrivalAirportId == null) &&
        (DepartureAirportGroupId == null || ArrivalAirportGroupId == null))
    {
      throw new BadDataException("Either DepartureAirportID and ArrivalAirportID or DepartureAirportGroupID and ArrivalAirportGroupID must be provided.");
    }
  }
}
