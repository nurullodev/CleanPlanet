using CleanPlanet.Service.DTOs.Addresses.Countries;
using CleanPlanet.Service.DTOs.Places.Cities;
using CleanPlanet.Service.DTOs.Places.Regions;
using CleanPlanet.Service.DTOs.Places.Streets;

namespace CleanPlanet.Service.DTOs.Places.Addresses;

public class AddressResultDto
{
	public long Id { get;set; }
	public int QuantityOfCar { get; set; }
	public CityResultDto City { get; set; }
	public CountryResultDto Country { get; set; }
	public RegionResultDto Region { get; set; }
	public StreetResultDto Street { get; set; }
}