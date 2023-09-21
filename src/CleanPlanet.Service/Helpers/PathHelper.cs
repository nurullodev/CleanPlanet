using Newtonsoft.Json;

namespace CleanPlanet.Service.Helpers;

public static class PathHelper
{
    public static string WebRootPath { get; set; }

    [JsonProperty("CountriesFilePath")]
    public static string CountryPath { get; set; }

    [JsonProperty("RegionsFilePath")]
    public static string RegionPath { get; set; }

    [JsonProperty("DictrictsFilePath")]
    public static string DistrictPath { get; set; }
}