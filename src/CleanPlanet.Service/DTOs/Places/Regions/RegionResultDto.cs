using CleanPlanet.Service.DTOs.Places.Cities;

namespace CleanPlanet.Service.DTOs.Places.Regions;

public class RegionResultDto
{
	public long Id { get; set; }
	public string Name { get; set; }
	public CityResultDto City { get; set; }
}
