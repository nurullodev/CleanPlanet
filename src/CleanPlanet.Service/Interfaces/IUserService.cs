using CleanPlanet.Service.DTOs.Users;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserResultDto> CreateAsync(UserCreationDto dto);
    ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserResultDto> RetrieveByIdAsync(long id);
    ValueTask<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAsync(PaginationParams pagination);
    ValueTask<UserResultDto> UpgradeRoleAsync(long id, UserRole role);
}