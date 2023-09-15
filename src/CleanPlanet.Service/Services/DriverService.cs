using AutoMapper;
using CleanPlanet.Service.Helpers;
using CleanPlanet.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Service.DTOs.Attachment;

namespace CleanPlanet.Service.Services;

public class DriverService : IDriverService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAttachService attachService;
    public DriverService(IUnitOfWork unitOfWork, IMapper mapper, IAttachService attachService)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.attachService = attachService;
    }

    public async ValueTask<DriverResultDto> CreateAsync(DriverCreationDto dto)
    {
        var driver = await this.unitOfWork.Drivers.GetAsync(d => d.Phone.Equals(dto.Phone));
        if (driver is not null)
            throw new AlreadyExistException("This driver is already exist");

        dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        dto.Password = PasswordHash.Encrypt(dto.Password);

        var mappedDriver = this.mapper.Map<Driver>(dto);
        await this.unitOfWork.Drivers.AddAsync(mappedDriver);
        await this.unitOfWork.Drivers.SaveAsync();

        return this.mapper.Map<DriverResultDto>(mappedDriver);
    }

    public async ValueTask<DriverResultDto> ModifyAsync(DriverUpdateDto dto)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Id.Equals(dto.Id));
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        if (existDriver.Phone.Equals(dto.Phone))
            throw new AlreadyExistException("This driver is already exist");

        dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        dto.Password = PasswordHash.Encrypt(dto.Password);
        var mappedDriver = this.mapper.Map(dto, existDriver);
        this.unitOfWork.Drivers.Update(mappedDriver);
        await this.unitOfWork.Drivers.SaveAsync();

        return this.mapper.Map<DriverResultDto>(mappedDriver);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Id.Equals(id));
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        this.unitOfWork.Drivers.Delete(existDriver);
        await this.unitOfWork.Drivers.SaveAsync();
        return true;
    }

    public async ValueTask<bool> DestroyAsync(long id)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Id.Equals(id));
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        this.unitOfWork.Drivers.Destroy(existDriver);
        await this.unitOfWork.Drivers.SaveAsync();
        return true;
    }

    public async ValueTask<DriverResultDto> RetrieveByIdAsync(long id)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Id.Equals(id), includes: new[] { "Attach", "Car" });
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        return this.mapper.Map<DriverResultDto>(existDriver);
    }

    public async ValueTask<DriverResultDto> RetrieveByEmailAndPasswordAsync(string phone, string password)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Phone.Equals(phone), includes: new[] { "Attach", "Car" });
        if (existDriver is null)
            throw new NotFoundException("This driver  is not found");

        bool checkPassword = PasswordHash.Verify(existDriver.Password, password);
        if (!checkPassword)
            throw new InvalidPasswordException("This driver password is invalid");

        return this.mapper.Map<DriverResultDto>(existDriver);
    }

    public async ValueTask<IEnumerable<DriverResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        var drivers = await this.unitOfWork.Drivers.GetAll(includes: new[] { "Attach", "Car" })
                        .ToPaginate(pagination).ToListAsync();

        return this.mapper.Map<IEnumerable<DriverResultDto>>(drivers);
    }

    public async ValueTask<DriverResultDto> ModifyImageAsync(long driverId, AttachCreationDto dto)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(d => d.Id.Equals(driverId));
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        var createdAttachment = await this.attachService.UploadAsync(dto);
        existDriver.AttachId = createdAttachment.Id;
        existDriver.Attach = createdAttachment;
        this.unitOfWork.Drivers.Update(existDriver);
        await this.unitOfWork.Drivers.SaveAsync();

        return this.mapper.Map<DriverResultDto>(existDriver);
    }

    public async ValueTask<DriverResultDto> UploadImageAsync(long driverId, AttachCreationDto dto)
    {
        var existDriver = await this.unitOfWork.Drivers.GetAsync(p => p.Id.Equals(driverId), includes: new[] { "Attach" });
        if (existDriver is null)
            throw new NotFoundException("This driver is not found");

        await this.attachService.RemoveAsync(existDriver.Attach);
        var createdAttachment = await this.attachService.UploadAsync(dto);

        existDriver.AttachId = createdAttachment.Id;
        existDriver.Attach = createdAttachment;
        this.unitOfWork.Drivers.Update(existDriver);
        await this.unitOfWork.Drivers.SaveAsync();

        return this.mapper.Map<DriverResultDto>(existDriver);
    }
}