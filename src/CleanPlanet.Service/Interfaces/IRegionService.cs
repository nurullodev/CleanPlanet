using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.Interfaces;

public interface IRegionService
{
    ValueTask<bool> SaveInDBAsync();
    ValueTask<RegionResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams pagination);
}