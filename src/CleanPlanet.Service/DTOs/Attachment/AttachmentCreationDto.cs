using Microsoft.AspNetCore.Http;

namespace CleanPlanet.Service.DTOs.Attachment;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}