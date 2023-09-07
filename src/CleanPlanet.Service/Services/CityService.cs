using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Places.Cities;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CleanPlanet.Service.Services;

public class CityService : ICityService
{
	private readonly IMapper mapper;
	private readonly IUnitOfWork unitOfWork;
	public CityService(IMapper mapper, IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
		this.mapper = mapper;
	}
	public async Task<IEnumerable<CityResultDto>> RetrieveAllAsync(PaginationParams @pagination)
	{
		var countries = await this.unitOfWork.Countries.GetAll()
			.ToPaginate(@pagination)
			.ToListAsync();
		var result = this.mapper.Map<IEnumerable<CityResultDto>>(countries);
		return result;
	}

	public async Task<CityResultDto> RetrieveByIdAsync(long id)
	{
		var country = await this.unitOfWork.Cities.GetAsync(r => r.Id.Equals(id));
		if (country is null)
			throw new NotFoundException("This country is not found");

		var mappedCountry = this.mapper.Map<CityResultDto>(country);
		return mappedCountry;
	}

	public async Task<bool> SaveInDBAsync()
	{
		var dbSource = this.unitOfWork.Countries.GetAll();
		if (dbSource.Any())
			throw new AlreadyExistException("Countries are already exist");

		string path = @"..//..//..//../CleanPlanet/src/CleanPlanet.Shared/Files/cities.json";
		var source = File.ReadAllText(path);
		var countries = JsonConvert.DeserializeObject<IEnumerable<CityCreationDto>>(source);

		foreach (var country in countries)
		{
			var mappedCountry = this.mapper.Map<City>(country);
			await this.unitOfWork.Cities.AddAsync(mappedCountry);
			await this.unitOfWork.Countries.SaveAsync();
		}
		return true;
	}
}
