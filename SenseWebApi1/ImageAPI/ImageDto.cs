// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace ImageAPI;

public class ImageDto
{
    public Guid Id { get; set; }
    public ImageType Type { get; set; }
}

public enum ImageType
{
    ImageDeleteEvent=2
}