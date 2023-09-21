using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverUpdateDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("User id")]
    public long UserId { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Car id")]
    public long? CarId { get; set; }
}