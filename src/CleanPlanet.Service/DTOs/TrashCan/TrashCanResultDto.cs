using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.DTOs.Places.Addresses;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.TrashCan;

public class TrashCanResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Due date")]
    public DateTime DueData { get; set; }

    [DisplayName("Address result")]
    public AddressResultDto Address { get; set; }

    [DisplayName("Car result")]
    public CarResultDto Car { get; set; }
}