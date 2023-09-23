using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Attachs;

namespace CleanPlanet.Service.Interfaces;

public interface ICarService
{
    ValueTask<CarResultDto> CreateAsync(CarCreationDto dto);
    ValueTask<CarResultDto> ModifyAsync(CarUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<CarResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CarResultDto>> RetrieveAsync(PaginationParams pagination);
    ValueTask<CarResultDto> ModifyImageAsync(long carId, AttachCreationDto dto);
    ValueTask<CarResultDto> UploadImageAsync(long carId, AttachCreationDto dto);
}