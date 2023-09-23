using CleanPlanet.API.Models;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CleanPlanet.API.Controllers;

public class DistrictsController : BaseController
{
    private readonly IDistrictService districtService;

    public DistrictsController(IDistrictService districtService)
    {
        this.districtService = districtService;
    }

    [HttpPost("set")]
    [Authorize(Roles = "SuberAdmin, Admin")]
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