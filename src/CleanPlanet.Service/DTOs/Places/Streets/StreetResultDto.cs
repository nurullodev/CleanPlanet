using CleanPlanet.Service.DTOs.Places.Regions;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public RegionResultDto Region { get; set; }
}