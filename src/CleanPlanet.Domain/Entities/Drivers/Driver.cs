using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Attachments;
using CleanPlanet.Domain.Entities.Cars;
using CleanPlanet.Domain.Entities.Users;

namespace CleanPlanet.Domain.Entities.Drivers;

public class Driver : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public DateTime DateOfBirth { get; set; }

    public long CarId { get; set; }
    public Car Car { get; set; }

    public long? AttachId { get; set; }
    public Attach Attach { get; set; }
}