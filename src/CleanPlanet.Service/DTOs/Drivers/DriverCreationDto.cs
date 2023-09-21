using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverCreationDto
{
    [DisplayName("User id")]
    public long UserId { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Car id")]
    public long CarId { get; set; }
}