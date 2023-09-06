using CleanPlanet.DAL.IRepositories;

namespace CleanPlanet.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }
}
