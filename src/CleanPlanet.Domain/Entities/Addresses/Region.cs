﻿using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Addresses;

public class Region : Auditable
{
	public string Name { get; set; }

	public long CountryId { get; set; }
	public Country Country { get; set; }
}