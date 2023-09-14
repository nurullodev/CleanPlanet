using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Attachment;

namespace CleanPlanet.Service.Services;

public class CarService : ICarService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAttachService attachService;
    public CarService(IUnitOfWork unitOfWork, IMapper mapper, IAttachService attachService)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.attachService = attachService;
    }

    public async ValueTask<CarResultDto> CreateAsync(CarCreationDto dto)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(c => c.Number.Equals(dto.Number) , includes: new[] { "Attach" });
        if (existCar is not null)
            throw new AlreadyExistException("This car is already exist");

        var mappedCar = this.mapper.Map<Car>(dto);
        await this.unitOfWork.Cars.AddAsync(mappedCar);
        await this.unitOfWork.Cars.SaveAsync();

        return this.mapper.Map<CarResultDto>(mappedCar);
    }

    public async ValueTask<CarResultDto> ModifyAsync(CarUpdateDto dto)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(c => c.Id.Equals(dto.Id), includes: new[] { "Attach" });
        if (existCar is null)
            throw new NotFoundException("This car is not found");

        var checkCar = await this.unitOfWork.Cars.GetAsync(c => c.Number.Equals(dto.Number));
        if (checkCar is not null)
            throw new AlreadyExistException("This car is already exist");

        var mappedCar = this.mapper.Map(dto, existCar);
        this.unitOfWork.Cars.Update(mappedCar);
        await this.unitOfWork.Cars.SaveAsync();

        return this.mapper.Map<CarResultDto>(mappedCar);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(c => c.Id.Equals(id));
        if (existCar is null)
            throw new NotFoundException("This car number is not found");

        this.unitOfWork.Cars.Delete(existCar);
        await this.unitOfWork.Cars.SaveAsync();
        return true;
    }

    public async ValueTask<bool> DestroyAsync(long id)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(c => c.Id.Equals(id));
        if (existCar is null)
            throw new NotFoundException("This car number is not found");

        this.unitOfWork.Cars.Destroy(existCar);
        await this.unitOfWork.Cars.SaveAsync();
        return true;
    }

    public async ValueTask<CarResultDto> RetrieveByIdAsync(long id)
    {
        var existCar = await this.unitOfWork.Cars.GetAsync(c => c.Id.Equals(id) , includes: new[] { "Attach" });
        if (existCar is null)
            throw new NotFoundException("This car number is not found");

        return this.mapper.Map<CarResultDto>(existCar);
    }

    public async ValueTask<IEnumerable<CarResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        var cars = await this.unitOfWork.Cars.GetAll(includes: new[] {"Attach"})
                        .ToPaginate(pagination).ToListAsync();

        return this.mapper.Map<IEnumerable<CarResultDto>>(cars);
    }

    public async ValueTask<CarResultDto> UploadImageAsync(long carId, AttachCreationDto dto)
    {
        var car = await this.unitOfWork.Cars.GetAsync(p => p.Id.Equals(carId));
        if (car is null)
            throw new NotFoundException("This car Id is not found");

        var createdAttachment = await this.attachService.UploadAsync(dto);
        car.AttachId = createdAttachment.Id;
        car.Attach = createdAttachment;

        this.unitOfWork.Cars.Update(car);
        await this.unitOfWork.Cars.SaveAsync();

        return this.mapper.Map<CarResultDto>(car);
    }

    public async ValueTask<CarResultDto> ModifyImageAsync(long carId, AttachCreationDto dto)
    {
        var car = await this.unitOfWork.Cars.GetAsync(p => p.Id.Equals(carId), includes: new[] { "Attach" });
        if (car is null)
            throw new NotFoundException("This car Id is not found");

        await this.attachService.RemoveAsync(car.Attach);
        var createdAttachment = await this.attachService.UploadAsync(dto);

        car.AttachId = createdAttachment.Id;
        car.Attach = createdAttachment;
        this.unitOfWork.Cars.Update(car);
        await this.unitOfWork.Cars.SaveAsync();

        return this.mapper.Map<CarResultDto>(car);
    }
}