using AutoMapper;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Service.DTOs.Users;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Interfaces;

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
            throw new AlreadyExistException("This user is already exist");

        var mappedUser = this.mapper.Map<User>(dto);
        await this.unitOfWork.Users.AddAsync(mappedUser);
        await this.unitOfWork.Users.SaveAsync();

        return this.mapper.Map<UserResultDto>(mappedUser);
    }

    public ValueTask<UserResultDto> ModefyAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<UserResultDto>> RetrieveAsync(PaginationParams pagination)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserResultDto> RetrieveByPasswordAsync(string password)
    {
        throw new NotImplementedException();
    }
}
