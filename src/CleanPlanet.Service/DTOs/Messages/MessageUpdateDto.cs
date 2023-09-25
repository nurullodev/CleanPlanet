namespace CleanPlanet.Service.DTOs.Messages;

public class MessageUpdateDto
{
    public long Id { get; set; }
    public string Content { get; set; }
    public long UserId { get; set; }
    public long DriverId { get; set; }
    public long? AttachId { get; set; }
}