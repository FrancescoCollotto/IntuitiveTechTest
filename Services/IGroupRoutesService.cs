namespace IntuitiveTechTest.Services;

public interface IGroupRoutesService
{
  Task<List<GroupRouteResponse>> ListAsync();
  Task AddAsync(int departureAirportGroupId, int arrivalAirportGroupId);
}
