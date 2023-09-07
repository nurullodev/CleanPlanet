namespace CleanPlanet.Service.DTOs.Places.Addresses;

public class AddressCreationDto
{

	public int QuantityOfCar { get; set; }
	public long CityId { get; set; }
	public long CountryId { get; set; }
	public long RegionId { get; set; }
	public long StreetId { get; set; }
}
