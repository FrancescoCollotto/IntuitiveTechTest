namespace IntuitiveTechTest.Services;

public interface IAirportsService
{
  Task<List<AirportsResponse>> ListAsync();
  Task<AirportResponse?> GetByIdAsync(int id);
}
