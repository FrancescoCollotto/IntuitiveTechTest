namespace IntuitiveTechTest.Services;

public interface IRoutesService
{
  Task<List<AirportRouteResponse>> ListAsync();
  Task AddAsync(int departureAirportId, int arrivalAirportId);
}
