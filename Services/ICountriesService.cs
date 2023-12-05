namespace IntuitiveTechTest.Services;

public interface ICountriesService
{
  Task<List<CountryResponse?>> ListAsync();
  Task<CountryResponse?> AddAsync(AddCountryRequest addCountryRequest);
  Task DeleteAsync(int id);
}
