using CleanPlanet.Domain.Enums;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Users;

public class UserCreationDto
{
    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Phone number")]
    public string Phone { get; set; }

    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }
}