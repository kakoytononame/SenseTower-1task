using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Stubs
{
    public class ImageContext:IImageContext
    {
        private List<Image> Images = new List<Image>();

        public ImageContext()
        {
            Images.Add(new Image()
            {
                ImageId=Guid.NewGuid(),
                src="image 1"
            });
            Images.Add(new Image()
            {
                ImageId = Guid.NewGuid(),
                src = "image 2"
            });
        }

        public List<Image> GetImages()
        {
            return Images;
        }

        public bool IsHave (Guid id)
        {
            var image=Images.Where(p=>p.ImageId==id).FirstOrDefault();
            return Images.Contains(image);
        }
    }
}
