using System.ComponentModel;
using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Region result")]
    public RegionResultDto Region { get; set; }
}