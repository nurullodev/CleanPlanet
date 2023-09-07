using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.Interfaces;

public interface ICountryService
{
    Task<bool> SetAsync();
    Task<RegionResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params);
}