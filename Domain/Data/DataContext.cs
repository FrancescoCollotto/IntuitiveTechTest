using Microsoft.EntityFrameworkCore;

namespace IntuitiveTechTest;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) {}

  public DbSet<Airport> Airports { get; set; }
  public DbSet<Country> Countries { get; set; }
  public DbSet<AirportType> AirportTypes { get; set; }
  public DbSet<Route> Routes { get; set; }
  public DbSet<AirportGroup> AirportGroups { get; set; }
  public DbSet<AirportGroupJunction> AirportGroupJunctions { get; set; }
  public DbSet<GroupRoute> GroupRoutes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<AirportType>().HasData(
      new AirportType { Id = 1, Type = "Departure and Arrival" },
      new AirportType { Id = 2, Type = "Departure Only" },
      new AirportType { Id = 3, Type = "Arrival Only" }
    );

    modelBuilder.Entity<Country>().HasData(
      new Country { Id = 1, Name = "United Kingdom" },
      new Country { Id = 2, Name = "Spain" },
      new Country { Id = 3, Name = "United States" },
      new Country { Id = 4, Name = "Turkey" }
    );

    modelBuilder.Entity<Airport>().HasData(
      new Airport { Id = 1, IATACode = "LGW", CountryId = 1, AirportTypeId = 1 },
      new Airport { Id = 2, IATACode = "PMI", CountryId = 2, AirportTypeId = 3 },
      new Airport { Id = 3, IATACode = "LAX", CountryId = 3, AirportTypeId = 3 }
    );

    modelBuilder.Entity<Route>()
        .HasOne(r => r.DepartureAirport)
        .WithMany(a => a.DepartureRoutes)
        .HasForeignKey(r => r.DepartureAirportId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Route>()
        .HasOne(r => r.ArrivalAirport)
        .WithMany(a => a.ArrivalRoutes)
        .HasForeignKey(r => r.ArrivalAirportId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Route>()
        .HasIndex(r => new { r.DepartureAirportId, r.ArrivalAirportId })
        .IsUnique();

    modelBuilder.Entity<AirportGroupJunction>()
        .HasKey(agj => new { agj.AirportId, agj.AirportGroupId });

    modelBuilder.Entity<GroupRoute>()
        .HasOne(gr => gr.DepartureAirportGroup)
        .WithMany(ag => ag.DepartureGroupRoutes)
        .HasForeignKey(gr => gr.DepartureAirportGroupId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<GroupRoute>()
        .HasOne(gr => gr.ArrivalAirportGroup)
        .WithMany(ag => ag.ArrivalGroupRoutes)
        .HasForeignKey(gr => gr.ArrivalAirportGroupId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<GroupRoute>()
        .HasIndex(gr => new { gr.DepartureAirportGroupId, gr.ArrivalAirportGroupId })
        .IsUnique();
  }
}
