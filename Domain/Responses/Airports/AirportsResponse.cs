namespace IntuitiveTechTest;

public class AirportsResponse
{
  public int Id { get; set; }  
  public string? IATACode { get; set; }

  public static explicit operator AirportsResponse(Airport airport)
  {
    return new AirportsResponse
    {
      Id = airport.Id,
      IATACode = airport.IATACode  
    };
  }
}
