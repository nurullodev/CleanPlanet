using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Addresses;

namespace CleanPlanet.Domain.Entities.TrashCans;

public class TrashCan : Auditable
{
	public DateTime DueData { get; set; }

	public long AddressId { get; set; }
	public Address Address { get; set; }

	public long CarId { get; set; }
	public Car Car { get; set; }
}