using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class Airport
{
  public int Id { get; set; }
  [Required]
  [StringLength(3)]
  public string? IATACode { get; set; }
  public int CountryId { get; set; }
  public int AirportTypeId { get; set; }

  public Country? Country { get; set; }
  public AirportType? AirportType { get; set; }
}
