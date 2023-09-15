using AutoMapper;
using Newtonsoft.Json;
using CleanPlanet.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Places.Districts;
using CleanPlanet.Service.Helpers;

namespace CleanPlanet.Service.Services;

public class DistrictService : IDistrictService
{
	private readonly IMapper mapper;
	private readonly IUnitOfWork unitOfWork;
	public DistrictService(IMapper mapper, IUnitOfWork unitOfWork)
	{
		this.mapper = mapper;
		this.unitOfWork = unitOfWork;
	}

    public async ValueTask<bool> SaveInDBAsync()
    {
        var dbSource = this.unitOfWork.Districts.GetAll();
        if (dbSource.Any())
            throw new AlreadyExistException("Districts are already exist");

		string path = @"D:\Portfolio\CleanPlanet\src\CleanPlanet.Shared\Files\districts.json";
        var source = File.ReadAllText(path);

        var districts = JsonConvert.DeserializeObject<IEnumerable<DistrictCreationDto>>(source);

        foreach (var district in districts)
        {
            var mappedDistrict = this.mapper.Map<District>(district);
            await this.unitOfWork.Districts.AddAsync(mappedDistrict);
            await this.unitOfWork.Districts.SaveAsync();
        }
        return true;
    }

    public async ValueTask<DistrictResultDto> RetrieveByIdAsync(long id)
    {
        var district = await this.unitOfWork.Districts.GetAsync(r => r.Id.Equals(id), includes: new[] { "Region.Country" });
        if(district is null)
            throw new NotFoundException("This district is not found");

        var mappedDistrict = this.mapper.Map<DistrictResultDto>(district);
        return mappedDistrict;
    }

    public async ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var districts = await this.unitOfWork.Districts.GetAll(includes: new[] { "Region.Country" })
                        .ToPaginate(@params)
                        .ToListAsync();
        var result = this.mapper.Map<IEnumerable<DistrictResultDto>>(districts);
        return result;
    }
}