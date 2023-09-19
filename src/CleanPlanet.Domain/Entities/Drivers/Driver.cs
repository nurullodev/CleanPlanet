using CleanPlanet.Domain.Enums;
using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Attachments;

namespace CleanPlanet.Domain.Entities.Drivers;

public class Driver : Auditable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }
	public UserRole Role { get; set; }

	public long CarId { get; set; }
	public Car Car { get; set; }

	public long? AttachId { get; set; }
    public Attach? Attach { get; set; }
}