using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetCreationDto
{
    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Region id")]
    public long RegionId { get; set; }
}