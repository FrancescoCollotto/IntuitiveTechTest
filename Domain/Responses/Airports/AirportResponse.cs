namespace IntuitiveTechTest;

public class AirportResponse
{
  public int Id { get; set; }
  public string? IATACode { get; set; }
  public CountryResponse? Country { get; set; }
  public AirportTypeResponse? Type { get; set; }

  public static explicit operator AirportResponse?(Airport? airport)
  {
    if (airport == null)
    {
      return null;
    }

    return new AirportResponse
    {
      Id = airport.Id,
      IATACode = airport.IATACode,
      Country = (CountryResponse?)airport.Country,
      Type = (AirportTypeResponse?)airport.AirportType
    };
  }
}
