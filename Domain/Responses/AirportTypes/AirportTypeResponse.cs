namespace IntuitiveTechTest;

public class AirportTypeResponse
{
  public int Id { get; set; }
  public string? Type { get; set; }

  public static explicit operator AirportTypeResponse?(AirportType? airportType)
  {
    if (airportType == null)
    {
      return null;
    }

    return new AirportTypeResponse
    {
      Id = airportType.Id,
      Type = airportType.Type
    };
  }
}
