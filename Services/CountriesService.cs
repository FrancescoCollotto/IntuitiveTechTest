using IntuitiveTechTest.Services;
using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest;

public class CountriesService : ICountriesService
{
  private readonly DataContext context;

  public CountriesService(DataContext context)
  {
    this.context = context;
  }

  public async Task<List<CountryResponse?>> ListAsync()
  {
    var countries = await context.Countries.ToListAsync();

    return countries.Select(country => (CountryResponse?)country).ToList();
  }
}
