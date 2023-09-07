using AutoMapper;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.DTOs.Drivers;
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
    }
}