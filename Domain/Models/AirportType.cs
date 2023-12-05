using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class AirportType
{
  public int Id { get; set; }
  [Required]
  public string? Type { get; set; }

  public ICollection<Airport> Airports { get; set; } = new List<Airport>();
}
