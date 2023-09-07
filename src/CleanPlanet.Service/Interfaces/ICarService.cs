using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Domain.Configurations;

namespace CleanPlanet.Service.Interfaces;

public interface ICarService
{
    ValueTask<CarResultDto> CreateAsync(CarCreationDto dto);
    ValueTask<CarResultDto> ModefyAsync(CarUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<CarResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CarResultDto>> RetrieveAsync(PaginationParams pagination);
}
