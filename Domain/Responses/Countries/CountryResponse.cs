namespace IntuitiveTechTest;

public class CountryResponse
{
  public int Id { get; set; }
  public string? Name { get; set; }

  public static explicit operator CountryResponse?(Country? country)
  {
    if (country == null)
    {
      return null;
    }

    return new CountryResponse
    {
      Id = country.Id,
      Name = country.Name
    };
  }
}
