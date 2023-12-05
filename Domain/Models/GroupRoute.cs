namespace IntuitiveTechTest;

public class GroupRoute
{
  public int Id { get; set; }
  public int DepartureAirportGroupId { get; set; }
  public int ArrivalAirportGroupId { get; set; }

  public AirportGroup? DepartureAirportGroup { get; set; }
  public AirportGroup? ArrivalAirportGroup { get; set; }
}
