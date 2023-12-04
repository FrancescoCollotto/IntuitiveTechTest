using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) {}

  public DbSet<Airport> Airports { get; set; }
  public DbSet<Country> Countries { get; set; }
  public DbSet<AirportType> AirportTypes { get; set; }
}
