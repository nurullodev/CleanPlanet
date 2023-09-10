using System.ComponentModel;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverCreationDto
{
    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Phone number")]
    public string Phone { get; set; }

    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Role")]
    public UserRole Role { get; set; }

    [DisplayName("Car id")]
    public long CarId { get; set; }

    [DisplayName("Attachment id")]
    public long AttachId { get; set; }
}