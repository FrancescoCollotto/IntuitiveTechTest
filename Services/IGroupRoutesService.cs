namespace IntuitiveTechTest.Services;

public interface IGroupRoutesService
{
  Task AddAsync(int departureAirportGroupId, int arrivalAirportGroupId);
}
