using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Streets;

public class StreetCreationDto
{
    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("District id")]
    public long DistrictId { get; set; }
}