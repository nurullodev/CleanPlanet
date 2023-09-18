using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.DTOs.TrashCan;
using CleanPlanet.Domain.Entities.TrashCans;

namespace CleanPlanet.Service.Services;

public class TrashCanService : ITrashCanService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public TrashCanService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async ValueTask<TrashCanResultDto> CreateAsync(TrashCanCreationDto dto)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(t => t.Id.Equals(dto.CarId));
        if (existCar is null)
            throw new NotFoundException("This car is not found");
        
        var mappedTrashCan = this.mapper.Map<TrashCan>(dto);
        mappedTrashCan.CarId = existCar.Id;
        mappedTrashCan.Car = existCar;
        await this.unitOfWork.TrashCans.AddAsync(mappedTrashCan);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<TrashCanResultDto>(mappedTrashCan);
    }

    public async ValueTask<TrashCanResultDto> ModifyAsync(TrashCanUpdateDto dto)
    {
        var existTrashCan = await this.unitOfWork.TrashCans.GetAsync(t => t.Id.Equals(dto.Id));
        if (existTrashCan is null)
            throw new NotFoundException("This trash can is not found");

        var existCar = await this.unitOfWork.Cars.GetAsync(t => t.Id.Equals(dto.CarId));
        if (existCar is null)
            throw new NotFoundException("This car is not found");

        var mappedTrashCan = this.mapper.Map(dto,existTrashCan);
        mappedTrashCan.Car = existCar;
        mappedTrashCan.CarId = existCar.Id;

        this.unitOfWork.TrashCans.Update(mappedTrashCan);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<TrashCanResultDto>(mappedTrashCan);
    }

    public async ValueTask<bool> DestroyAsync(long id)
    {
        var existTrashCan = await this.unitOfWork.TrashCans.GetAsync(t => t.Id.Equals(id));
        if(existTrashCan is null)
            throw new NotFoundException("This trash can is not found");

        this.unitOfWork.TrashCans.Destroy(existTrashCan);
        await this.unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<TrashCanResultDto> RetrieveByIdAsync(long id)
    {
        var existTrashCan = await this.unitOfWork.TrashCans.GetAsync(t => t.Id.Equals(id), includes: new[] { "Car" });
        if (existTrashCan is null)
            throw new NotFoundException("This trash can is not found");

        return this.mapper.Map<TrashCanResultDto>(existTrashCan);
    }

    public async ValueTask<IEnumerable<TrashCanResultDto>> RetrieveAsync()
    {
        var trashcans = await this.unitOfWork.TrashCans.GetAll(includes: new[] { "Car" }).ToListAsync();
        return this.mapper.Map<IEnumerable<TrashCanResultDto>>(trashcans);
    }
}