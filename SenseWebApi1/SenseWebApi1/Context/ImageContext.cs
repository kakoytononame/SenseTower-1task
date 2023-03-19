using SenseWebApi1.Features.EventFeature;

namespace SenseWebApi1.Context
{
    public class ImageContext:IImageContext
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Image> _images = new List<Image>();

        public ImageContext()
        {
            _images.Add(new Image()
            {
                ImageId=Guid.Parse("074a2eb2-4b45-4ac8-88ac-12b5dc52b252"),
                src="image 1"
            });
            _images.Add(new Image()
            {
                ImageId = Guid.Parse("9f4813cd-6d37-4393-b7ce-f2cc2c81ef3b"),
                src = "image 2"
            });
        }


        public bool IsHave (Guid id)
        {
            var image=_images.FirstOrDefault(p => p.ImageId==id);
            return image != null;
        }
    }
}
