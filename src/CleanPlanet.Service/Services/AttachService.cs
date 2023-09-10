using CleanPlanet.Service.Helpers;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Service.Extensions;
using CleanPlanet.Service.Interfaces;
using CleanPlanet.Service.DTOs.Attachment;
using CleanPlanet.Domain.Entities.Attachments;

namespace CleanPlanet.Service.Services;

public class AttachService : IAttachService
{
    private readonly IUnitOfWork unitOfWork;
    public AttachService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Attach> UploadAsync(AttachCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "Images");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtention = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtention}";
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var attachment = new Attach()
        {
            FileName = fileName,
            FilePath = filePath,
        };

        await unitOfWork.Attachments.AddAsync(attachment);
        await unitOfWork.Attachments.SaveAsync();

        return attachment;
    }

    public async Task<bool> RemoveAsync(Attach attachment)
    {
        if (attachment is null)
            return false;

        var existAttachment = await unitOfWork.Attachments.GetAsync(a => a.Id.Equals(attachment.Id));

        if (existAttachment is null)
            return false;

        unitOfWork.Attachments.Delete(attachment);
        await unitOfWork.Attachments.SaveAsync();

        return true;
    }
}