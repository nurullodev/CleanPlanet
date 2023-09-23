using CleanPlanet.Service.DTOs.Attachs;
using CleanPlanet.Domain.Entities.Attachs;

namespace CleanPlanet.Service.Interfaces;

public interface IAttachService
{
    Task<Attach> UploadAsync(AttachCreationDto dto);
    Task<bool> RemoveAsync(Attach attachment);
}