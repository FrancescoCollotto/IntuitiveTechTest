namespace IntuitiveTechTest.Services;

public interface IRoutesService
{
  Task AddAsync(int departureAirportId, int arrivalAirportId);
}
