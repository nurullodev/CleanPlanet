namespace CleanPlanet.DAL.IRepositories;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}