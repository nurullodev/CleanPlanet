using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.Service.Services;

public class DriverService : IDriverService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ValueTask<DriverResultDto> CreateAsync(DriverCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DestroyAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DriverResultDto> ModefyAsync(DriverUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<DriverResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DriverResultDto> RetrieveByEmailAndPasswordAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DriverResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
