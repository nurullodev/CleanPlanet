using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Addresses.Countries;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.Interfaces;

public interface ICountryService
{
    Task<bool> SaveInDBAsync();
    Task<CountryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams pagination);
}