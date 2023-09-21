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
using CleanPlanet.Service.DTOs.Addresses.Countries;

namespace CleanPlanet.Service.Services;

public class CountryService : ICountryService
{
	private readonly IMapper mapper;
	private readonly IUnitOfWork unitOfWork;
    public CountryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> SaveInDBAsync()
    {
        var dbSource = this.unitOfWork.Countries.GetAll();
        if (dbSource.Any())
            throw new AlreadyExistException("Countries are already exist");

        string path = PathHelper.CountryPath;
        var source = File.ReadAllText(path);
        var countries = JsonConvert.DeserializeObject<IEnumerable<CountryCreationDto>>(source);

        foreach (var country in countries)
        {
            var mappedCountry = this.mapper.Map<Country>(country);
            await this.unitOfWork.Countries.AddAsync(mappedCountry);
            await this.unitOfWork.SaveAsync();
        }
        return true;
    }

    public async Task<CountryResultDto> RetrieveByIdAsync(long id)
    {
        var country = await this.unitOfWork.Countries.GetAsync(r => r.Id.Equals(id));
        if (country is null)
            throw new NotFoundException("This country is not found");

        var mappedCountry = this.mapper.Map<CountryResultDto>(country);
        return mappedCountry;
    }

    public async Task<IEnumerable<CountryResultDto>> RetrieveAllAsync(PaginationParams pagination)
	{
		var countries = await this.unitOfWork.Countries.GetAll()
			.ToPaginate(pagination)
			.ToListAsync();
		var result = this.mapper.Map<IEnumerable<CountryResultDto>>(countries);
		return result;
	}
}