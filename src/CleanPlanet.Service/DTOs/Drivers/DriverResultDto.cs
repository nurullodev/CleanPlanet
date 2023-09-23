using System.ComponentModel;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.DTOs.Users;
using CleanPlanet.Service.DTOs.Attachs;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("User result")]
    public UserResultDto User { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Car result")]
    public CarResultDto Car { get; set; }

    [DisplayName("Attachment result")]
    public AttachResultDto Attach { get; set; }
}