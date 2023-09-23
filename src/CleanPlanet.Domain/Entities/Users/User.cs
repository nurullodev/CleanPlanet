using CleanPlanet.Domain.Enums;
using CleanPlanet.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace CleanPlanet.Domain.Entities.Users;

public class User : Auditable
{
    [Required, StringLength(30, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required, StringLength(30, MinimumLength = 3)]
    public string LastName { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    [Required, StringLength(25, MinimumLength = 4)]
    public string Password { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

	public UserRole Role { get; set; }
}