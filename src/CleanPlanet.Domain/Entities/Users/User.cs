using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Domain.Entities.Users;

public class User : Auditable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }
	public UserRole Role { get; set; }
}