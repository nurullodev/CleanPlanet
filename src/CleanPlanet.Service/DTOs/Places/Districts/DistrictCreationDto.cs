using Newtonsoft.Json;

namespace CleanPlanet.Service.DTOs.Places.Districts;

public class DistrictCreationDto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("region_id")]
    public long RegionId { get; set; }
}