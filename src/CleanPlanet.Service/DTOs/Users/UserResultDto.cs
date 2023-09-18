using CleanPlanet.Domain.Enums;
using CleanPlanet.Service.DTOs.Places.Addresses;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Users;

public class UserResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Phone number")]
    public string Phone { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Role")]
    public UserRole Role { get; set; }
}