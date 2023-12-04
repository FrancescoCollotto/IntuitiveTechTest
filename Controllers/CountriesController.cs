using IntuitiveTechTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntuitiveTechTest.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
  private readonly ICountriesService countriesService;

  public CountriesController(ICountriesService countriesService)
  {
    this.countriesService = countriesService;
  }

  [HttpGet]
  public async Task<ActionResult<List<CountryResponse?>>> ListAsync()
  {
    var countries = await countriesService.ListAsync();

    return Ok(countries);
  }
}
