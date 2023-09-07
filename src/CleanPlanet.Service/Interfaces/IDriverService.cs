using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Drivers;

namespace CleanPlanet.Service.Interfaces;

public interface IDriverService
{
    ValueTask<DriverResultDto> CreateAsync(DriverCreationDto dto);
    ValueTask<DriverResultDto> ModefyAsync(DriverUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<DriverResultDto> RetrieveByIdAsync(long id);
    ValueTask<DriverResultDto> RetrieveByPasswordAsync(string password);
    ValueTask<DriverResultDto> RetrieveByEmailAndPasswordAsync(string email, string password);
    ValueTask<IEnumerable<DriverResultDto>> RetrieveAsync(PaginationParams pagination);
}