using Microsoft.EntityFrameworkCore;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Attachs;
using CleanPlanet.Domain.Entities.TrashCans;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Entities.Statistics;
using CleanPlanet.Domain.Entities.Messages;

namespace CleanPlanet.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<TrashCan> TrashCans { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Attach> Attachs { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Fluent API
        modelBuilder.Entity<Address>()
              .HasOne(t => t.Street)
              .WithMany()
              .HasForeignKey(t => t.StreetId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.District)
              .WithMany()
              .HasForeignKey(t => t.DistrictId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.Street)
              .WithMany()
              .HasForeignKey(t => t.StreetId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.Country)
              .WithMany()
              .HasForeignKey(t => t.CountryId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Driver>()
              .HasOne(x => x.Car)
              .WithMany()
              .HasForeignKey(t => t.CarId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<TrashCan>()
              .HasOne(t => t.Address)
              .WithMany()
              .HasForeignKey(t => t.AddressId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<TrashCan>()
              .HasOne(t => t.Car)
              .WithMany()
              .HasForeignKey(t => t.CarId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Statistic>()
              .HasOne(t => t.Address)
              .WithMany()
              .HasForeignKey(t => t.AddressId)
        .OnDelete(DeleteBehavior.NoAction);
        #endregion
    }
}