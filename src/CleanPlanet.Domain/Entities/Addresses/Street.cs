using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Street : Auditable
{
	public string Name { get; set; }
	
	public long RegionId { get; set; }
	public Region Region { get; set; }
}