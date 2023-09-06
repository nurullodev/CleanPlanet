namespace CleanPlanet.Domain.Entities.Addresses;

public class Address : Auditable
{
	public int QuantityOfCar { get; set; }

	public long CityId { get; set; }
	public City City { get; set; }

	public long CountryId { get; set; }
	public Country Country { get; set; }

	public long RegionId { get; set; }
	public Region Region { get; set; }

	public long StreetId { get; set; }
	public Street Street { get; set; }
}
public class City : Auditable
{
	public string Name { get; set; }

	public long Id { get; set; }
	public Country Country { get; set; }
}

public class Country : Auditable
{
	public string Name { get; set; }
	public string CountryCode { get; set; }
}
public class Region : Auditable
{
	public string Name { get; set; }

	public long CityId { get; set; }
	public City City { get; set; }
}

public class Street : Auditable
{
	public string Name { get; set; }
	
	public long RegionId { get; set; }
	public Region Region { get; set; }
}