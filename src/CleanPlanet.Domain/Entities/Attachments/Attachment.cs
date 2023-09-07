using CleanPlanet.Domain.Commons;

namespace CleanPlanet.Domain.Entities.Attachments;

public class Attachment : Auditable
{
	public string FilePath { get; set; }
	public string FileName { get; set; }
}