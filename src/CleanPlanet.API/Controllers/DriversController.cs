using CleanPlanet.API.Models;
using Microsoft.AspNetCore.Mvc;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Domain.Configurations;
using Microsoft.AspNetCore.Authorization;
using CleanPlanet.Service.DTOs.Attachs;

namespace CleanPlanet.API.Controllers;

public class DriversController : BaseController
{
    private readonly IDriverService driverService;

    public DriversController(IDriverService driverService)
    {
        this.driverService = driverService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> PostAsync(DriverCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.CreateAsync(dto)
        });


    [HttpPut("update")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> PutAsync(DriverUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.ModifyAsync(dto)
        });


    [HttpDelete("delete")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.RemoveAsync(id)
        });


    [HttpDelete("destroy")]
    [Authorize(Roles = "SuberAdmin")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.DestroyAsync(id)
        });


    [HttpGet("get/id:{long}")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    [Authorize(Roles = "SuberAdmin, Admin")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.driverService.RetrieveAsync(pagination)
       });

    [HttpPost("image-upload")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> ImageUploadAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.UploadImageAsync(driverId, dto)
        });


    [HttpPost("update-image")]
    [Authorize(Roles = "SuberAdmin, Admin, Driver")]
    public async Task<IActionResult> UpdateImageAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.ModifyImageAsync(driverId, dto)
        });
}