using CleanPlanet.Domain.Entities.Attachments;
using CleanPlanet.Service.DTOs.Attachment;

namespace CleanPlanet.Service.Services;

public interface IAttachService
{
    Task<Attach> UploadAsync(AttachCreationDto dto);
    Task<bool> RemoveAsync(Attach attachment);
}