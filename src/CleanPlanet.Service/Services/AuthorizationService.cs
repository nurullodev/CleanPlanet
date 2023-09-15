using System.Text;
using System.Security.Claims;
using CleanPlanet.Service.Helpers;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.Exceptions;
using CleanPlanet.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace CleanPlanet.Service.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IConfiguration configuration;
    public AuthorizationService(IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.configuration = configuration;
    }

    public async ValueTask<string> GenerateTokenAsync(string phone, string originalPassword)
    {
        var user = await this.unitOfWork.Users.GetAsync(u => u.Phone.Equals(phone));
        if (user is null)
            throw new NotFoundException("This user is not found");

        bool verifiedPassword = PasswordHash.Verify(user.Password, originalPassword);
        if (!verifiedPassword)
            throw new CustomException(400, "Phone or password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Phone", user.Phone),
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);
        return result;
    }
}