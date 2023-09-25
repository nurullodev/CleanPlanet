using System.ComponentModel;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Service.DTOs.Users;

public class UserUpdateDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

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