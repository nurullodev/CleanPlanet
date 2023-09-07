using System.Net.Mail;
using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Cars;

public class Car : Auditable
{
	public string Type { get; set; }
	public string Number { get; set; }
	public int QunatityTrashCan { get; set; }

	public long AttachmentId { get; set; }
	public Attachment Attachment { get; set; }
}