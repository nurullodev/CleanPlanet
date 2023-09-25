namespace CleanPlanet.Service.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension = fileInfo.Extension;
        string name = "_IMG" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new[]
        {
            // JPG Files
            ".jpg",".jpeg",
            // PNG Files
            ".png",
            // BMP Files
            ".bmp",
            // Svg Files
            ".svg"
        };
    }
}
