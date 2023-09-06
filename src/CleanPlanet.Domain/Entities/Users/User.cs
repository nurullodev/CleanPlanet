using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Domain.Entities.Users;

public class User : Auditable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }
	public UserRole Role { get; set; }

	public long AddressId { get; set; }
	public Address Address { get; set; }


}
