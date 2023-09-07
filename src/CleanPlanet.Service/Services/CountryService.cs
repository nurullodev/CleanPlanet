using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Addresses.Countries;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CleanPlanet.Service.Services;

public class CountryService : ICountryService
{
	private readonly IMapper mapper;
	private readonly IRepository<Country> repository;
	public CountryService(IMapper mapper, IRepository<Country> repository)
	{
		this.mapper = mapper;
		this.repository = repository;
	}
	public async Task<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams @pagination)
	{
		var countries = await this.repository.GetAll()
			.ToPaginate(@pagination)
			.ToListAsync();
		var result = this.mapper.Map<IEnumerable<CountryResultDto>>(countries);
		return result;
	}

	public async Task<CountryResultDto> RetrieveByIdAsync(long id)
	{
		var country = await this.repository.GetAsync(r => r.Id.Equals(id));
		if (country is null)
			throw new NotFoundException("This country is not found");

		var mappedCountry = this.mapper.Map<CountryResultDto>(country);
		return mappedCountry;
	}

	public async Task<bool> SaveInDBAsync()
	{
		var dbSource = this.repository.GetAll();
		if (dbSource.Any())
			throw new AlreadyExistException("Countries are already exist");

		string path = @"../../../../CleanPlanet/src/CleanPlanet.Shared/Files/counties.json";
		var source = File.ReadAllText(path);
		var countries = JsonConvert.DeserializeObject<IEnumerable<CountryCreationDto>>(source);

		foreach (var country in countries)
		{
			var mappedCountry = this.mapper.Map<Country>(country);
			await this.repository.AddAsync(mappedCountry);
			await this.repository.SaveAsync();
		}
		return true;
	}
}
