using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Addresses;

public class AddressUpdateDto
{
    [DisplayName("Id")]
	public long Id { get; set; }

    [DisplayName("Quantity of the car")]
    public int QuantityOfCar { get; set; }

    [DisplayName("District id")]
    public long DistrictId { get; set; }

    [DisplayName("Country id")]
    public long CountryId { get; set; }

    [DisplayName("Region id")]
    public long RegionId { get; set; }

    [DisplayName("Street id")]
    public long StreetId { get; set; }
}