using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public class ImageContext:IImageContext
    {
        private List<Image> Images = new List<Image>();

        public ImageContext()
        {
            Images.Add(new Image()
            {
                ImageId=Guid.Parse("074a2eb2-4b45-4ac8-88ac-12b5dc52b252"),
                src="image 1"
            });
            Images.Add(new Image()
            {
                ImageId = Guid.Parse("9f4813cd-6d37-4393-b7ce-f2cc2c81ef3b"),
                src = "image 2"
            });
        }


        public bool IsHave (Guid id)
        {
            var image=Images.Where(p=>p.ImageId==id).FirstOrDefault();
            if(image==null) 
            {
                return false;
            }
            return true;
        }
    }
}
