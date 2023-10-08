using CleanPlanet.API.Models;
using Microsoft.AspNetCore.Mvc;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Configurations;
using Microsoft.AspNetCore.Authorization;

namespace CleanPlanet.API.Controllers;

public class RegionsController : BaseController
{
    private readonly IRegionService regionService;
    public RegionsController(IRegionService regionService)
    {
        this.regionService = regionService;
    }

    [HttpPost("set")]
    [Authorize(Roles = "SuberAdmin, Admin")]
    public async Task<IActionResult> PostAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.SaveInDBAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.regionService.RetrieveAllAsync(pagination)
        });
}