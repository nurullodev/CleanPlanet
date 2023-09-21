using CleanPlanet.Domain.Enums;
using CleanPlanet.Service.DTOs.Attachment;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Cars;

public class CarResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Type")]
    public string Type { get; set; }

    [DisplayName("Number")]
    public string Number { get; set; }

    [DisplayName("Qunatity of the trash can")]
    public int QunatityTrashCan { get; set; }

    [DisplayName("Attachment result")]
    public AttachResultDto Attach { get; set; }
}