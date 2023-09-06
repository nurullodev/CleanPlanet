namespace CleanPlanet.Domain.Entities.TrashCans;

public class TrashCan : Auditable
{
	public DateTime DueData { get; set; }

	public long AddressId { get; set; }
	public Address Address { get; set; }

	public long AddressId { get; set; }
	public Address Address { get; set; }
}
