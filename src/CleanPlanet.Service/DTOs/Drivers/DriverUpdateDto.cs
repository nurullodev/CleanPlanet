using CleanPlanet.Domain.Enums;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverUpdateDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

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