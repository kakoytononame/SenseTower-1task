using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public interface IImageContext
    {
        bool IsHave(Guid id);
    }
}
