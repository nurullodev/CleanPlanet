using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Users;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Address : Auditable
{
	public int QuantityOfCar { get; set; }

	public long CityId { get; set; }
	public City City { get; set; }

	public long CountryId { get; set; }
	public Country Country { get; set; }

	public long RegionId { get; set; }
	public Region Region { get; set; }

	public long? StreetId { get; set; }
	public Street Street { get; set; }

	public ICollection<User> Users { get; set; }
}