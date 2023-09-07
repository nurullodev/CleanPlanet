﻿using CleanPlanet.Domain.Enums;
using CleanPlanet.Service.DTOs.Cars;
using System.ComponentModel;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }

    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [DisplayName("Lastname")]
    public string LastName { get; set; }

    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Phone number")]
    public string Phone { get; set; }

    [DisplayName("Role")]
    public UserRole Role { get; set; }

    [DisplayName("Car result")]
    public CarResultDto Car { get; set; }
}