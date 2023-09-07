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
	private readonly IRepository<City> repository;
	private readonly IUnitOfWork unitOfWork;
	public CityService(IMapper mapper, IRepository<City> repository,IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
		this.mapper = mapper;
		this.repository = repository;
	}
	public async Task<IEnumerable<CityResultDto>> RetrieveAllAsync(PaginationParams @pagination)
	{
		var countries = await this.repository.GetAll()
			.ToPaginate(@pagination)
			.ToListAsync();
		var result = this.mapper.Map<IEnumerable<CityResultDto>>(countries);
		return result;
	}

	public async Task<CityResultDto> RetrieveByIdAsync(long id)
	{
		var country = await this.repository.GetAsync(r => r.Id.Equals(id));
		if (country is null)
			throw new NotFoundException("This country is not found");

		var mappedCountry = this.mapper.Map<CityResultDto>(country);
		return mappedCountry;
	}

	public async Task<bool> SaveInDBAsync()
	{
		var dbSource = this.repository.GetAll();
		if (dbSource.Any())
			throw new AlreadyExistException("Countries are already exist");

		string path = @"../../../../CleanPlanet/src/CleanPlanet.Shared/Files/cities.json";
		var source = File.ReadAllText(path);
		var countries = JsonConvert.DeserializeObject<IEnumerable<CityCreationDto>>(source);

		foreach (var country in countries)
		{
			var mappedCountry = this.mapper.Map<City>(country);
			await this.repository.AddAsync(mappedCountry);
			await this.repository.SaveAsync();
		}
		return true;
	}
}
