using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Addresses.Countries;

public class CountryResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Country code")]
    public string CountryCode { get; set; }
}