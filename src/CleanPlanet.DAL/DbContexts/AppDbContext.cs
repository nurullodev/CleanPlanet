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
    public DbSet<Attach> Attachs { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Street> Streets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Fluent API
        modelBuilder.Entity<Address>()
              .HasOne(t => t.Street);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.District);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.Street);

        modelBuilder.Entity<Address>()
              .HasOne(t => t.Country);

        modelBuilder.Entity<Driver>()
              .HasOne(x => x.Car);

        modelBuilder.Entity<TrashCan>()
              .HasOne(t => t.Address);

        modelBuilder.Entity<TrashCan>()
              .HasOne(t => t.Car);

        modelBuilder.Entity<Statistic>()
              .HasOne(t => t.Address);
        #endregion

        //#region Seet Data
        //modelBuilder.Entity<User>()
        //  .HasData(new User { Id = 1, FirstName = "Nurullo", LastName = "Mansurjon", Email = "mansurjon@gmail.com", Phone = "+998942240816", Role = Domain.Enums.UserRole.User, AddressId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null, Password = "1234" });

        //modelBuilder.Entity<Address>()
        //  .HasData(new Address { Id = 1, DistrictId = 182, StreetId = 1, RegionId = 12, QuantityOfCar = 10, CountryId = 233, CreatedAt = DateTime.UtcNow });

        //modelBuilder.Entity<District>()
        //  .HasData(new District { Id = 182, CreatedAt = DateTime.UtcNow, RegionId = 12, Name = "Uchkoprik tumani", UpdatedAt = null });

        //modelBuilder.Entity<Country>()
        //  .HasData(new Country { Id = 233, CountryCode = "UZ", Name = "Uzbekistan", CreatedAt = DateTime.UtcNow, UpdatedAt = null });

        //modelBuilder.Entity<Region>()
        //  .HasData(new Region { Id = 12, CountryId = 233, Name = "Fargona viloyati",CreatedAt = DateTime.UtcNow, UpdatedAt = null });

        //modelBuilder.Entity<Attach>()
        //  .HasData(new Attach { Id = 1, FileName = "City", FilePath = @"" });

        //modelBuilder.Entity<Car>()
        //  .HasData(new Car { Id = 1, AttachId = 1, Number = "777ZZZ", QunatityTrashCan = 20, Type = "ISUZU", CreatedAt = DateTime.UtcNow, UpdatedAt = null });

        //modelBuilder.Entity<Driver>()
        //  .HasData(new Driver { Id = 1, AttachId = 1, CarId = 1, FirstName = "Bekzod", LastName = "Xokimov", Password = "xokimov", Phone = "+998908976789", Role = Domain.Enums.UserRole.Driver, DateOfBirth = new DateTimeOffset(new DateTime(1992, 02, 02)).UtcDateTime, CreatedAt = DateTime.UtcNow, UpdatedAt = null});

        //modelBuilder.Entity<TrashCan>()
        //  .HasData(new TrashCan { Id = 1, CarId = 1, DueData = new DateTimeOffset(new DateTime(2023, 12, 12)).UtcDateTime, AddressId = 1, CreatedAt = DateTime.UtcNow,UpdatedAt = null});
        //#endregion
    }
}

