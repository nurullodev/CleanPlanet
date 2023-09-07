using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Cities;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.Interfaces;

public interface ICityService
{
    Task<bool> SaveInDBAsync();
    Task<CityResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CityResultDto>> RetrieveAllAsync(PaginationParams @pagination);
}
