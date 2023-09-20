using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Places.Addresses;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanPlanet.Service.Services;

public class AddressService : IAddressService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<AddressResultDto> CreateAsync(AddressCreationDto dto)
    {
        var country = await this.unitOfWork.Countries.GetAsync(c => c.Id.Equals(dto.CountryId));
        if (country is null)
            throw new NotFoundException("This country is not found");
        
        var region = await this.unitOfWork.Regions.GetAsync(r => r.Id.Equals(dto.RegionId));
        if (region is null)
            throw new NotFoundException("This region is not found");

        var district = await this.unitOfWork.Districts.GetAsync(d => d.Id.Equals(dto.DistrictId));
        if (district is null)
            throw new NotFoundException("This district is not found");

        var street = await this.unitOfWork.Streets.GetAsync(c => c.Id.Equals(dto.StreetId));
        if (street is null)
            throw new NotFoundException("This street is not found");

        var mappedAddress = this.mapper.Map<Address>(dto);

        mappedAddress.District = district;
        mappedAddress.Country = country;
        mappedAddress.Region = region;
        mappedAddress.Street = street;

        await this.unitOfWork.Addresses.AddAsync(mappedAddress);
        await this.unitOfWork.SaveAsync();
        return this.mapper.Map<AddressResultDto>(mappedAddress);
    }

    public async ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        var existAddress = await this.unitOfWork.Addresses.GetAsync(a => a.Id.Equals(dto.Id));
        if (existAddress is null)
            throw new NotFoundException("This address is not found");

        var country = await this.unitOfWork.Countries.GetAsync(c => c.Id.Equals(dto.CountryId));
        if (country is null)
            throw new NotFoundException("This country is not found");

        var region = await this.unitOfWork.Regions.GetAsync(r => r.Id.Equals(dto.RegionId));
        if (region is null)
            throw new NotFoundException("This region is not found");

        var district = await this.unitOfWork.Districts.GetAsync(d => d.Id.Equals(dto.DistrictId));
        if (district is null)
            throw new NotFoundException("This district is not found");

        var street = await this.unitOfWork.Streets.GetAsync(c => c.Id.Equals(dto.StreetId));
        if (street is null)
            throw new NotFoundException("This street is not found");

        var mappedAddress = this.mapper.Map(dto,existAddress);

        mappedAddress.District = district;
        mappedAddress.Country = country;
        mappedAddress.Region = region;
        mappedAddress.Street = street;

        this.unitOfWork.Addresses.Update(mappedAddress);
        await this.unitOfWork.SaveAsync();
        return this.mapper.Map<AddressResultDto>(mappedAddress);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existAddress = await this.unitOfWork.Addresses
                           .GetAsync(a => a.Id.Equals(id), includes: new[] { "District", "Region", "Country", "Street" });
        if (existAddress is null)
            throw new NotFoundException("This address is not found");

        this.unitOfWork.Addresses.Delete(existAddress);
        await this.unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<AddressResultDto> RetrieveByIdAsync(long id)
    {
        var address = await this.unitOfWork.Addresses
                      .GetAsync(a => a.Id.Equals(id), includes: new[] { "District", "Region", "Country", "Street" });
        if (address is null)
            throw new NotFoundException("This address is not found");

        return this.mapper.Map<AddressResultDto>(address);
    }

    public async ValueTask<IEnumerable<AddressResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        var existAddresses = await this.unitOfWork.Addresses.GetAll().ToListAsync();
        return this.mapper.Map<IEnumerable<AddressResultDto>>(existAddresses);
    }
}