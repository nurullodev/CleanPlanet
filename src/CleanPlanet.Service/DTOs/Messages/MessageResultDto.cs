using CleanPlanet.Service.DTOs.Attachs;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Service.DTOs.Users;

namespace CleanPlanet.Service.DTOs.Messages;

public class MessageResultDto
{
    public long Id { get; set; }
    public string Content { get; set; }
    public UserResultDto User { get; set; }
    public DriverResultDto Driver { get; set; }
    public AttachResultDto Attach { get; set; }
}