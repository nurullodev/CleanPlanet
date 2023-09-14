using CleanPlanet.API.Models;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanPlanet.API.Controllers;

public class CitiesController : BaseController
{
    private readonly IDistrictService districtService;

    public CitiesController(IDistrictService districtService)
    {
        this.districtService = districtService;
    }

    [HttpPost("set")]
    public async Task<IActionResult> PostAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.SaveInDBAsync()
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.districtService.RetrieveAllAsync(pagination)
        });
}