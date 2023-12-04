using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest.Services;

public class AirportsService : IAirportsService
{
  private readonly DataContext context;

  public AirportsService(DataContext context)
  {
    this.context = context;
  }
  public async Task<List<AirportsResponse>> ListAsync()
  {
    var airports = await context.Airports.ToListAsync();

    return airports.Select(airport => (AirportsResponse)airport).ToList();
  }

  public async Task<AirportResponse?> GetByIdAsync(int id)
  {
    var airport = await context.Airports
      .Include(a => a.Country)
      .Include(a => a.AirportType)
      .FirstOrDefaultAsync(airport => airport.Id == id);

    if (airport == null)
    {
      throw new NotFoundException($"Airport with ID {id} not found.");
    }

    return (AirportResponse?)airport;
  }
}
