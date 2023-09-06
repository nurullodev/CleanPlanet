using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Country : Auditable
{
	public string Name { get; set; }
	public string CountryCode { get; set; }
}
