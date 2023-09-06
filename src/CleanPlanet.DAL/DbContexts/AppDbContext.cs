using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Entities.Attachments;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Statistics;
using CleanPlanet.Domain.Entities.TrashCans;
using CleanPlanet.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanPlanet.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<TrashCan> TrashCans { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Street> Streets { get; set; }
}