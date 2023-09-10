using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Streets;
using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.Service.Services;

public class StreetService : IStreetService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public StreetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ValueTask<StreetResultDto> CreateAsync(StreetCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DestroyAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<StreetResultDto> ModifyAsync(StreetUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<StreetResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public ValueTask<StreetResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}