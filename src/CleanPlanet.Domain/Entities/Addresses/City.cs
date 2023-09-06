using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class City : Auditable
{
	public string Name { get; set; }

	public long Id { get; set; }
	public Country Country { get; set; }
}
