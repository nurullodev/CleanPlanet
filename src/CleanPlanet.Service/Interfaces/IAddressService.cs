using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Addresses;

namespace CleanPlanet.Service.Interfaces;

public interface IAddressService
{
    ValueTask<AddressResultDto> CreateAsync(AddressCreationDto dto);
    ValueTask<AddressResultDto> ModefyAsync(AddressUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<AddressResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AddressResultDto>> RetrieveAsync(PaginationParams pagination);
}