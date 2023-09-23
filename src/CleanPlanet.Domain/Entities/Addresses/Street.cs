using CleanPlanet.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Street : Auditable
{
    [Required]
    public string Name { get; set; }
	
	public long? DistrictId { get; set; }
	public District District { get; set; }
}