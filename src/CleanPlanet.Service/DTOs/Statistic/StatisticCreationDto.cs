using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Statistic;

public class StatisticCreationDto
{
    [DisplayName("Address id")]
    public long AddressId { get; set; }
}