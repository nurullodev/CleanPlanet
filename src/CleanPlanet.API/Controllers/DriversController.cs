using CleanPlanet.API.Models;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Service.DTOs.Attachment;
using CleanPlanet.Service.DTOs.Drivers;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanPlanet.API.Controllers;

public class DriversController : BaseController
{
    private readonly IDriverService driverService;

    public DriversController(IDriverService driverService)
    {
        this.driverService = driverService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(DriverCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.CreateAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(DriverUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.ModifyAsync(dto)
        });


    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.RemoveAsync(id)
        });


    [HttpDelete("destroy")]
    public async Task<IActionResult> DestroyAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.DestroyAsync(id)
        });


    [HttpGet("get/id:{long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await this.driverService.RetrieveAsync(pagination)
       });

    [HttpPost("image-upload")]
    public async Task<IActionResult> ImageUploadAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.UploadImageAsync(driverId, dto)
        });


    [HttpPost("update-image")]
    public async Task<IActionResult> UpdateImageAsync(long driverId, [FromForm] AttachCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.driverService.ModifyImageAsync(driverId, dto)
        });
}