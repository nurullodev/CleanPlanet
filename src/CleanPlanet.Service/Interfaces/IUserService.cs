using CleanPlanet.Service.DTOs.Users;
using CleanPlanet.Domain.Configurations;

namespace CleanPlanet.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserResultDto> CreateAsync(UserCreationDto dto);
    ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserResultDto> RetrieveByIdAsync(long id);
    ValueTask<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAsync(PaginationParams pagination);
}