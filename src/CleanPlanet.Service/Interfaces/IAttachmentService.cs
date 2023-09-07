using CleanPlanet.Service.DTOs.Attachment;
using CleanPlanet.Domain.Entities.Attachments;

namespace CleanPlanet.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}