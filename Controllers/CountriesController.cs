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

  [HttpPost]
  public async Task<ActionResult<CountryResponse?>> AddAsync(AddCountryRequest addCountryRequest)
  {
    try
    {
      var country = await countriesService.AddAsync(addCountryRequest);
      return Ok(country);
    }
    catch(BadDataException ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteAsync([FromRoute]int id)
  {
    try
    {
      await countriesService.DeleteAsync(id);
      return Ok("Country deleted.");
    }
    catch(BadDataException ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
