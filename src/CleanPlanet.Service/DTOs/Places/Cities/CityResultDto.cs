using CleanPlanet.Service.DTOs.Addresses.Countries;

namespace CleanPlanet.Service.DTOs.Places.Cities;

public class CityResultDto
{
	public long Id { get; set; }
	public string Name { get; set; }
	public CountryResultDto Country { get; set; }
}