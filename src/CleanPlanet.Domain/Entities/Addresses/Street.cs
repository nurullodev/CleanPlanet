using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Street : Auditable
{
	public string Name { get; set; }
	
	public long? DistrictId { get; set; }
	public District District { get; set; }
}