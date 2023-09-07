using CleanPlanet.Domain.Entities.Addresses;

namespace CleanPlanet.Service.DTOs.Places.Regions;

public class RegionCreationDto
{
	public string Name { get; set; }
	public long CityId { get; set; }
	public City City { get; set; }
}
