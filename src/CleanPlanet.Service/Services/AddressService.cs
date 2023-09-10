using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Addresses;
using CleanPlanet.Service.Interfaces;

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

    public ValueTask<AddressResultDto> CreateAsync(AddressCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<AddressResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}