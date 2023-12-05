using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class AirportGroup
{
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }

  public ICollection<AirportGroupJunction>? AirportGroupJunctions { get; set; }
}
