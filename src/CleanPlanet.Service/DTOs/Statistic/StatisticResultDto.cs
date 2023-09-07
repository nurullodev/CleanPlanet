using CleanPlanet.Service.DTOs.Places.Addresses;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Statistic;

public class StatisticResultDto
{
    [DisplayName("Address result")]
    public AddressResultDto Address { get; set; }
}