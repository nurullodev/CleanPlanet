using CleanPlanet.API.Models;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Attachs;
using CleanPlanet.Service.DTOs.Cars;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanPlanet.API.Controllers;
public class CarsController : BaseController
{
    private readonly ICarService carService;
    public CarsController(ICarService carService)
    {
        this.carService = carService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> PostAsync(CarCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.CreateAsync(dto)
        });


    [HttpPatch("update")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> PatchAsync(CarUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    [Authorize(Roles = "Admin, Driver")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.RemoveAsync(id)
        });

    [HttpDelete("destroy/{id:long}")]
    [Authorize(Roles = "Admin")]
    public async ValueTask<IActionResult> DestroyAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.DestroyAsync(id)
        });

    [HttpGet("get/id:{long}")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> GetAllAsync([FromQuery]  PaginationParams pagination)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.carService.RetrieveAsync(pagination)
       });


    [HttpPost("image-upload")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> ImageUploadAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.UploadImageAsync(driverId, dto)
        });


    [HttpPost("update-image")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> UpdateImageAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.carService.ModifyImageAsync(driverId, dto)
        });
}