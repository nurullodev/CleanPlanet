using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Attachs;
using System.ComponentModel.DataAnnotations;

namespace CleanPlanet.Domain.Entities.Cars;

public class Car : Auditable
{
    [Required]
    public string Type { get; set; }

    [Required]
    public string Number { get; set; }
    public int QunatityTrashCan { get; set; }

    public long? AttachId { get; set; }
    public Attach Attach { get; set; }
}