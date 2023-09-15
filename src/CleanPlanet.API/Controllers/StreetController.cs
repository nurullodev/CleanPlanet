using CleanPlanet.API.Models;
using CleanPlanet.Service.DTOs.Places.Streets;
using CleanPlanet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanPlanet.API.Controllers;

public class StreetController : BaseController
{
    private readonly IStreetService streetService;
    public StreetController(IStreetService streetService)
    {
        this.streetService = streetService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(StreetCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.CreateAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(StreetUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.streetService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
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
