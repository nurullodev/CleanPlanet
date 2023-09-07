using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Addresses;

public class AddressCreationDto
{
    [DisplayName("Quantity of the car")]
    public int QuantityOfCar { get; set; }

    [DisplayName("City id")]
    public long CityId { get; set; }

    [DisplayName("Country id")]
    public long CountryId { get; set; }

    [DisplayName("Region id")]
    public long RegionId { get; set; }

    [DisplayName("Street id")]
    public long StreetId { get; set; }
}