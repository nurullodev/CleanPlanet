using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Addresses;

namespace CleanPlanet.Domain.Entities.Statistics;

public class Statistic : Auditable
{
	public long AddressId { get; set; }
	public Address Address { get; set; }
}
