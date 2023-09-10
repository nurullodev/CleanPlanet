using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Attachment;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.DTOs.Drivers;

namespace CleanPlanet.Service.Interfaces;

public interface IDriverService
{
    ValueTask<DriverResultDto> CreateAsync(DriverCreationDto dto);
    ValueTask<DriverResultDto> ModifyAsync(DriverUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<DriverResultDto> RetrieveByIdAsync(long id);
    ValueTask<DriverResultDto> RetrieveByEmailAndPasswordAsync(string phone, string password);
    ValueTask<IEnumerable<DriverResultDto>> RetrieveAsync(PaginationParams pagination);
    ValueTask<DriverResultDto> ModifyImageAsync(long driverId, AttachCreationDto dto);
    ValueTask<DriverResultDto> UploadImageAsync(long driverId, AttachCreationDto dto);
}