namespace CleanPlanet.Service.DTOs.Cars;

public class CarResultDto
{
    public long Id { get; set; }
    public string Type { get; set; }
    public string CarNumber { get; set; }
    public int QunatityTrashCan { get; set; }
    public long AttachmentId { get; set; }
}