using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Service.DTOs.Places.Streets;

namespace CleanPlanet.Service.Services;

public class StreetService : IStreetService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public StreetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<StreetResultDto> CreateAsync(StreetCreationDto dto)
    {
        var existStreet = await this.unitOfWork.Streets.GetAsync(s => s.Name.Equals(dto.Name));
        if (existStreet is not null)
            throw new AlreadyExistException("This street is already exist");

        var district = await this.unitOfWork.Districts.GetAsync(r => r.Id.Equals(dto.DistrictId));
        if (district is null)
            throw new NotFoundException("This district is not found");

        var mappedStreet = this.mapper.Map<Street>(dto);
        mappedStreet.DistrictId = dto.DistrictId;
        mappedStreet.District = district;
        await this.unitOfWork.Streets.AddAsync(mappedStreet);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<StreetResultDto>(mappedStreet);
    }

    public async ValueTask<StreetResultDto> ModifyAsync(StreetUpdateDto dto)
    {
        var existStreet = await this.unitOfWork.Streets.GetAsync(s => s.Id.Equals(dto.Id));
        if (existStreet is null)
            throw new NotFoundException("This street is not found");

        if (existStreet.Name.Equals(dto.Name))
            throw new AlreadyExistException("This street is already exist");

        var district = await this.unitOfWork.Districts.GetAsync(r => r.Id.Equals(dto.DistrictId));
        if (district is null)
            throw new NotFoundException("This district is not found");

        var mappedStreet = this.mapper.Map(dto, existStreet);
        mappedStreet.DistrictId = dto.DistrictId;
        mappedStreet.District = district;
        this.unitOfWork.Streets.Update(mappedStreet);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<StreetResultDto>(mappedStreet);
    }

    public async ValueTask<bool> DestroyAsync(long id)
    {
        var existStreet = await this.unitOfWork.Streets.GetAsync(s => s.Id.Equals(id));
        if (existStreet is null)
            throw new NotFoundException("This street is not found");

        this.unitOfWork.Streets.Destroy(existStreet);
        await this.unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<StreetResultDto> RetrieveByIdAsync(long id)
    {
        var existStreet = await this.unitOfWork.Streets.GetAsync(s => s.Id.Equals(id), includes: new[] { "District" });
        if (existStreet is null)
            throw new NotFoundException("This street is not found");

        return this.mapper.Map<StreetResultDto>(existStreet);
    }

    public async ValueTask<IEnumerable<StreetResultDto>> RetrieveAsync()
    {
        var streets = await this.unitOfWork.Streets.GetAll(includes: new[] { "District" }).ToListAsync();
        var result = this.mapper.Map<IEnumerable<StreetResultDto>>(streets);
        return result;
    }
}