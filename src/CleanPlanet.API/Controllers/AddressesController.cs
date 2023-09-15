using CleanPlanet.Service.Interfaces;

namespace CleanPlanet.API.Controllers;

public class AddressesController : BaseController
{
    private readonly IAddressService addressService;
    public AddressesController(IAddressService addressService)
    {
        this.addressService = addressService;
    }
}