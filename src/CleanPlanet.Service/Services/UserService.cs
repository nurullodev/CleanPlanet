using AutoMapper;
using CleanPlanet.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.DTOs.Users;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        var existUser = await this.unitOfWork.Users.GetAsync(u => u.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exists");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.Role = UserRole.User;
        mappedUser.Password = PasswordHash.Encrypt(mappedUser.Password);

        await this.unitOfWork.Users.AddAsync(mappedUser);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<UserResultDto>(mappedUser);
    }

    public async ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var existUser = await this.unitOfWork.Users.GetAsync(u => u.Id.Equals(dto.Id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found");

        var checkUser = await this.unitOfWork.Users.GetAsync(u => u.Phone.Equals(dto.Phone) && !u.Id.Equals(existUser.Id));
        if (checkUser is not null)
            throw new AlreadyExistException($"This user is already exists");

        this.mapper.Map(dto, existUser);
        existUser.Password = PasswordHash.Encrypt(dto.Password);
        this.unitOfWork.Users.Update(existUser);
        await this.unitOfWork.SaveAsync();

        return this.mapper.Map<UserResultDto>(existUser);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existUser = await this.unitOfWork.Users.GetAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found");

        this.unitOfWork.Users.Delete(existUser);
        await this.unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        User existUser = await this.unitOfWork.Users.GetAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found");

        return this.mapper.Map<UserResultDto>(existUser);
    }

    public async ValueTask<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password)
    {
        User existUser = await this.unitOfWork.Users.GetAsync(u => u.Email.Equals(email));
        if (existUser is null)
            throw new NotFoundException($"This user is not found");

        var checkedPassword = PasswordHash.Verify(existUser.Password, password);
        if (!checkedPassword)
            throw new InvalidPasswordException("This user password is invalid");

        return this.mapper.Map<UserResultDto>(existUser);
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        var users = await this.unitOfWork.Users.GetAll().ToPaginate(pagination).ToListAsync();
        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }
}