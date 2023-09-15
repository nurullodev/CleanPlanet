using Newtonsoft.Json;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Places.Regions;

public class RegionCreationDto
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("country_id")]
    public long CountryId { get; set; }
}