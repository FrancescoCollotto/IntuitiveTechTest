namespace IntuitiveTechTest.Services;

public interface ICountriesService
{
  Task<List<CountryResponse?>> ListAsync();
}
