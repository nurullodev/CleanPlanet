﻿using AutoMapper;
using CleanPlanet.Domain.Entities.Addresses;
using CleanPlanet.Domain.Entities.Attachs;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Messages;
using CleanPlanet.Domain.Entities.Statistics;
using CleanPlanet.Domain.Entities.TrashCans;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Service.DTOs.Addresses.Countries;
using CleanPlanet.Service.DTOs.Attachs;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Service.DTOs.Messages;
using CleanPlanet.Service.DTOs.Places.Addresses;
using CleanPlanet.Service.DTOs.Places.Districts;
using CleanPlanet.Service.DTOs.Places.Regions;
using CleanPlanet.Service.DTOs.Places.Streets;
using CleanPlanet.Service.DTOs.Statistic;
using CleanPlanet.Service.DTOs.TrashCan;
using CleanPlanet.Service.DTOs.Users;

namespace CleanPlanet.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<User, UserCreationDto>().ReverseMap();

        //Car
        CreateMap<Car, CarUpdateDto>().ReverseMap();
        CreateMap<Car, CarResultDto>().ReverseMap();
        CreateMap<Car, CarCreationDto>().ReverseMap();

        //Driver
        CreateMap<Driver, DriverUpdateDto>().ReverseMap();
        CreateMap<Driver, DriverResultDto>().ReverseMap();
        CreateMap<Driver, DriverCreationDto>().ReverseMap();

        //Address
        CreateMap<Address, AddressUpdateDto>().ReverseMap();
        CreateMap<Address, AddressResultDto>().ReverseMap();
        CreateMap<Address, AddressCreationDto>().ReverseMap();

        //City
        CreateMap<District, DistrictResultDto>().ReverseMap();
        CreateMap<District, DistrictCreationDto>().ReverseMap();

        //Country
        CreateMap<Country, CountryResultDto>().ReverseMap();
        CreateMap<Country, CountryCreationDto>().ReverseMap();

        //Region
        CreateMap<Region, RegionResultDto>().ReverseMap();
        CreateMap<Region, RegionCreationDto>().ReverseMap();

        //Street
        CreateMap<Street, CarUpdateDto>().ReverseMap();
        CreateMap<Street, CarResultDto>().ReverseMap();
        CreateMap<Street, StreetCreationDto>().ReverseMap();

        //Attachment
        CreateMap<AttachResultDto, Attach>().ReverseMap();

        //Statistic
        CreateMap<Statistic, StatisticResultDto>().ReverseMap();
        CreateMap<Statistic, StatisticCreationDto>().ReverseMap();

        //TrashCan
        CreateMap<TrashCan, TrashCanUpdateDto>().ReverseMap();
        CreateMap<TrashCan, TrashCanResultDto>().ReverseMap();
        CreateMap<TrashCan, TrashCanCreationDto>().ReverseMap();

        //Message 
        CreateMap<Message, MessageUpdateDto>().ReverseMap();
        CreateMap<Message, MessageResultDto>().ReverseMap();
        CreateMap<Message, MessageCreationDto>().ReverseMap();
    }
}