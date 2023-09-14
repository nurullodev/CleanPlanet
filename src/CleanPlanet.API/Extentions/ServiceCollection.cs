using CleanPlanet.DAL.IRepositories;
using CleanPlanet.DAL.Repositories;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.Mappers;
using CleanPlanet.Service.Services;

namespace CleanPlanet.API.Extentions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDistrictService, DistrictService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<ICountryService, CountryService>();
    }
}