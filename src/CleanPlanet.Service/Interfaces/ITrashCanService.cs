using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.TrashCan;

namespace CleanPlanet.Service.Interfaces;

public interface ITrashCanService
{
    ValueTask<TrashCanResultDto> CreateAsync(TrashCanCreationDto dto);
    ValueTask<TrashCanResultDto> ModifyAsync(TrashCanUpdateDto dto);
    ValueTask<bool> DestroyAsync(long id);
    ValueTask<TrashCanResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<TrashCanResultDto>> RetrieveAsync(PaginationParams pagination);
}