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

  public async Task<CountryResponse?> AddAsync(AddCountryRequest addCountryRequest)
  {
    var countryExists = await context.Countries.AnyAsync(country => country.Name == addCountryRequest.Name);

    if (countryExists)
    {
      throw new BadDataException($"Country {addCountryRequest.Name} already exists.");
    }

    var country = new Country
    {
      Name = addCountryRequest.Name
    };

    context.Countries.Add(country);
    await context.SaveChangesAsync();

    return (CountryResponse?)country;
  }

  public async Task DeleteAsync(int id)
  {
    var countryToDelete = await context.Countries.FindAsync(id);

    if (countryToDelete == null)
    {
      throw new BadDataException($"Country with id {id} not found.");
    }

    var countryInUse = await context.Airports.AnyAsync(airport => airport.CountryId == id);

    if (countryInUse)
    {
      throw new BadDataException($"Country with id {id} in use for an Airport. Cannot be deleted.");
    }

    context.Countries.Remove(countryToDelete);
    await context.SaveChangesAsync();
  }
}
