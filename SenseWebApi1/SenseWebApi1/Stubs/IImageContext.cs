using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Stubs
{
    public interface IImageContext
    {
        List<Image> GetImages();
        bool IsHave(Guid id);
    }
}
