using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class Country
{
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }

  public ICollection<Airport>? Airports { get; set; }
}
