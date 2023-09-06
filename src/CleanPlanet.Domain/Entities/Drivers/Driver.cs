using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Domain.Entities.Drivers;

public class Driver : Auditable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirt { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }

	public long CarId { get; set; }
	public Car Car { get; set; }

	public UserRole Role { get; set; }
}
