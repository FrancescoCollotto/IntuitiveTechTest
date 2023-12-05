using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class AirportGroup
{
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }

  public ICollection<GroupRoute> DepartureGroupRoutes { get; set; } = new List<GroupRoute>();
  public ICollection<GroupRoute> ArrivalGroupRoutes { get; set; } = new List<GroupRoute>();
  public ICollection<AirportGroupJunction> AirportGroupJunctions { get; set; } = new List<AirportGroupJunction>();
}
