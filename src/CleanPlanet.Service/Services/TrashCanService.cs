using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.TrashCan;
using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.Service.Services;

public class TrashCanService : ITrashCanService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TrashCanService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ValueTask<TrashCanResultDto> CreateAsync(TrashCanCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DestroyAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TrashCanResultDto> ModefyAsync(TrashCanUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<TrashCanResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TrashCanResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
