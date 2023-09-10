using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Streets;

namespace CleanPlanet.Service.Interfaces;

public interface IStreetService
{
    ValueTask<StreetResultDto> CreateAsync(StreetCreationDto dto);
    ValueTask<StreetResultDto> ModifyAsync(StreetUpdateDto dto);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<StreetResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<StreetResultDto>> RetrieveAsync(PaginationParams pagination);
}