using CleanPlanet.API.Models;
using Microsoft.AspNetCore.Mvc;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Places.Addresses;

namespace CleanPlanet.API.Controllers;

public class AddressesController : BaseController
{
    private readonly IAddressService addressService;
    public AddressesController(IAddressService addressService)
    {
        this.addressService = addressService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(AddressCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.CreateAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(AddressUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.addressService.RetrieveAsync(pagination)
        });
}