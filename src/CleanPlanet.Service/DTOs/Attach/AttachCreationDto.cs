using Microsoft.AspNetCore.Http;

namespace CleanPlanet.Service.DTOs.Attachment;

public class AttachCreationDto
{
    public IFormFile FormFile { get; set; }
}