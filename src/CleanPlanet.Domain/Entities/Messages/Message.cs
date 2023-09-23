using CleanPlanet.Domain.Commons;
using CleanPlanet.Domain.Entities.Users;
using CleanPlanet.Domain.Entities.Drivers;
using CleanPlanet.Domain.Entities.Attachs;

namespace CleanPlanet.Domain.Entities.Messages;

public class Message : Auditable
{
    public string Content { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long DriverId { get; set; }
    public Driver Driver { get; set; }

    public long? AttachId { get; set; }
    public Attach Attach { get; set; }
}