using System.ComponentModel.DataAnnotations;

namespace IntuitiveTechTest;

public class AddCountryRequest
{
  [Required]
  public string? Name { get; set; }
}
