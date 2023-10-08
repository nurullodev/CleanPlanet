using CleanPlanet.API.Models;
using Microsoft.AspNetCore.Mvc;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CleanPlanet.Service.DTOs.Places.Streets;

namespace CleanPlanet.API.Controllers;

public class StreetController : BaseController
{
    private readonly IStreetService streetService;
    public StreetController(IStreetService streetService)
    {
        this.streetService = streetService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "SuberAdmin, Admin")]
    public async ValueTask<IActionResult> PostAsync(StreetCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.CreateAsync(dto)
        });


    [HttpPut("update")]
    [Authorize(Roles = "SuberAdmin, Admin")]
    public async ValueTask<IActionResult> PutAsync(StreetUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    [Authorize(Roles = "SuberAdmin, Admin")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.DestroyAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.RetrieveAsync()
        });
}
