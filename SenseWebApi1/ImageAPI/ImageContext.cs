namespace ImageAPI;

public class ImageContext:IImageContext
{
    private List<Image> _images;
    
    public ImageContext()
    {
        _images=new List<Image>()
        {
            new Image()
            {
                Id=Guid.Parse("5a448705-8ad7-4456-9847-f3b07e26edf9")
            },
            new Image()
            {
                Id=Guid.Parse("08e8f2cf-7594-4e6d-9df9-77f524ad1e3e")
            },
            new Image()
            {
                Id=Guid.Parse("0e034023-5f16-4a4e-852d-d76e511147df")
            }
        };
    }

    public List<Image> GetImages()
    {
        return _images;
    }

    public async Task DeleteImage(Guid imageId)
    {
        var image = _images.FirstOrDefault(p => p.Id == imageId)!;
        _images.Remove(image);
        await Task.CompletedTask;
    }
}