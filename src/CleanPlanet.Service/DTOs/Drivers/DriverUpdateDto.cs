using CleanPlanet.Domain.Enums;

namespace CleanPlanet.Service.DTOs.Drivers;

public class DriverUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirt { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public long CarId { get; set; }
}
