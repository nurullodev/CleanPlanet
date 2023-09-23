using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Statistic;
using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.Service.Services;

public class StatisticService : IStatisticService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public StatisticService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ValueTask<StatisticResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<StatisticResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }
}