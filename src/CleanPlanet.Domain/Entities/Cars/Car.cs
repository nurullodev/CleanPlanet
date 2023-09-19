using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Attachments;

namespace CleanPlanet.Domain.Entities.Cars;

public class Car : Auditable
{
    public string Type { get; set; }
    public string Number { get; set; }
    public int QunatityTrashCan { get; set; }

    public long? AttachId { get; set; }
    public Attach? Attach { get; set; }
}