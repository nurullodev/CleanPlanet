using CleanPlanet.DAL.DbContexts;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Entities.Attachs;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Messages;
using CleanPlanet.Domain.Entities.Statistics;
using CleanPlanet.Domain.Entities.TrashCans;
using CleanPlanet.Domain.Entities.Users;

namespace CleanPlanet.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;

        Users = new Repository<User>(dbContext);
        TrashCans = new Repository<TrashCan>(dbContext);
        Cars = new Repository<Car>(dbContext);
        Drivers = new Repository<Driver>(dbContext);
        Statistics = new Repository<Statistic>(dbContext);
        Attachs = new Repository<Attach>(dbContext);
        Addresses = new Repository<Address>(dbContext);
        Districts = new Repository<District>(dbContext);
        Countries = new Repository<Country>(dbContext);
        Regions = new Repository<Region>(dbContext);
        Streets = new Repository<Street>(dbContext);
        Messages = new Repository<Message>(dbContext);  
    }

    public IRepository<User> Users { get; }

    public IRepository<TrashCan> TrashCans { get; }

    public IRepository<Car> Cars { get; }

    public IRepository<Driver> Drivers { get; }

    public IRepository<Attach> Attachs { get; }

    public IRepository<Statistic> Statistics { get; }

    public IRepository<Address> Addresses { get; }

    public IRepository<District> Districts { get; }

    public IRepository<Country> Countries { get; }

    public IRepository<Region> Regions { get; }

    public IRepository<Street> Streets { get; }

    public IRepository<Message> Messages { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async ValueTask SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}