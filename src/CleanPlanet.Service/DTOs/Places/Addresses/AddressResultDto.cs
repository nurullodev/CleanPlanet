using System.ComponentModel;
using CleanPlanet.Service.DTOs.Places.Cities;
using CleanPlanet.Service.DTOs.Places.Regions;
using CleanPlanet.Service.DTOs.Places.Streets;
using CleanPlanet.Service.DTOs.Addresses.Countries;

namespace CleanPlanet.Service.DTOs.Places.Addresses;

public class AddressResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

	[DisplayName("Quantity of the car")]
    public int QuantityOfCar { get; set; }

	[DisplayName("City result")]
	public CityResultDto City { get; set; }

	[DisplayName("Country result")]
	public CountryResultDto Country { get; set; }

	[DisplayName("Region result")]
	public RegionResultDto Region { get; set; }

	[DisplayName("Street result")]
	public StreetResultDto Street { get; set; }
}