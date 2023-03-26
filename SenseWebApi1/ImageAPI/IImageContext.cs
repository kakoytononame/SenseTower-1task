namespace ImageAPI;

public interface IImageContext
{
    List<Image> GetImages();

    Task DeleteImage(Guid imageId);
}