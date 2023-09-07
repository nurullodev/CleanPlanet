using System.ComponentModel;
using CleanPlanet.Service.DTOs.Addresses.Countries;

namespace CleanPlanet.Service.DTOs.Places.Regions;

public class RegionResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Country result")]
    public CountryResultDto Country { get; set; }
}