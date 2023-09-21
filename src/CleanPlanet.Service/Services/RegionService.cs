using AutoMapper;
using Newtonsoft.Json;
using CleanPlanet.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.Services;

public class RegionService : IRegionService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<bool> SaveInDBAsync()
    {
        var dbSource = this.unitOfWork.Regions.GetAll();
        if (dbSource.Any())
            throw new AlreadyExistException("Regions are already exist");

        string path = PathHelper.RegionPath;

        var source = File.ReadAllText(path);
        var regions = JsonConvert.DeserializeObject<IEnumerable<RegionCreationDto>>(source);

        foreach (var region in regions)
        {
            var mappedRegion = this.mapper.Map<Region>(region);
            await this.unitOfWork.Regions.AddAsync(mappedRegion);
            await this.unitOfWork.SaveAsync();
        }
        return true;
    }

    public async ValueTask<RegionResultDto> RetrieveByIdAsync(long id)
    {
        var region = await this.unitOfWork.Regions.GetAsync(r => r.Id.Equals(id), includes: new[] { "Country" });
        if (region is null)
            throw new NotFoundException("This region is not found");

        var mappedRegion = this.mapper.Map<RegionResultDto>(region);
        return mappedRegion;
    }

    public async ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var regions = await this.unitOfWork.Regions.GetAll(includes: new[] { "Country" })
            .ToPaginate(@params)
            .ToListAsync();
        var result = this.mapper.Map<IEnumerable<RegionResultDto>>(regions);
        return result;
    }
}