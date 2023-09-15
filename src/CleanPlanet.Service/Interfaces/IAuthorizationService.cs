namespace CleanPlanet.Service.Interfaces;

public interface IAuthorizationService
{
    ValueTask<string> GenerateTokenAsync(string phone, string originalPassword);
}