﻿using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Entities.Attachments;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Statistics;
using CleanPlanet.Domain.Entities.TrashCans;
using CleanPlanet.Domain.Entities.Users;

namespace CleanPlanet.DAL.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<TrashCan> TrashCans { get; }
    IRepository<Car> Cars { get; }
    IRepository<Driver> Drivers { get; }
    IRepository<Attach> Attachments { get; }
    IRepository<Statistic> Statistics { get; }
    IRepository<Address> Addresses { get; }
    IRepository<City> Cities { get; }
    IRepository<Country> Countries { get; }
    IRepository<Region> Regions { get; }
    IRepository<Street> Streets { get; }
}