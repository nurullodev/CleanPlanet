using Newtonsoft.Json;

namespace CleanPlanet.Service.DTOs.Places.Cities;

public class CityCreationDto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("region_id")]
    public long RegionId { get; set; }
}