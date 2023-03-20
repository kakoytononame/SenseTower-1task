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
                ImageId=Guid.Parse("bda59f4e-c60b-411b-87e5-61a73125979b"),
                src="image 1"
            });
            _images.Add(new Image()
            {
                ImageId = Guid.Parse("ccd50edc-a02f-48a8-8ae8-70b47dd087d8"),
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
