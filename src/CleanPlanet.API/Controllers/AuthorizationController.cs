using CleanPlanet.API.Models;
using Microsoft.AspNetCore.Mvc;
using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.API.Controllers;

public class AuthorizationController : BaseController
{
    private readonly IAuthorizationService authorizationService;
    public AuthorizationController(IAuthorizationService authorizationService)
    {
        this.authorizationService = authorizationService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> GenerateTokenAsync(string phone, string password)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.authorizationService.GenerateTokenAsync(phone, password)
        });
}