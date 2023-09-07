using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.TrashCan;

public class TrashCanCreationDto
{
    [DisplayName("Due date")]
    public DateTime DueData { get; set; }

    [DisplayName("Address id")]
    public long AddressId { get; set; }

    [DisplayName("Car id")]
    public long CarId { get; set; }
}