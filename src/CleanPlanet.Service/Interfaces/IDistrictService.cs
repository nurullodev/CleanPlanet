using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Districts;

namespace CleanPlanet.Service.Interfaces;

public interface IDistrictService
{
    ValueTask<bool> SaveInDBAsync();
    ValueTask<DistrictResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync(PaginationParams pagination);
}
