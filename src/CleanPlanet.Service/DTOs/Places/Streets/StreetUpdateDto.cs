using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetUpdateDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Region id")]
    public long RegionId { get; set; }
}