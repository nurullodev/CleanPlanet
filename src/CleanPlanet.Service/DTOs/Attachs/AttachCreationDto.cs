using Microsoft.AspNetCore.Http;

namespace CleanPlanet.Service.DTOs.Attachs;

public class AttachCreationDto
{
    public IFormFile FormFile { get; set; }
}