using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Region : Auditable
{
	public string Name { get; set; }

	public long CityId { get; set; }
	public City City { get; set; }
}
