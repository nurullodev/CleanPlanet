using System.ComponentModel;
using CleanPlanet.Service.DTOs.Places.Districts;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("District result")]
    public DistrictResultDto District { get; set; }
}