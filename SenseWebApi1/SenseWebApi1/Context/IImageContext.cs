

namespace SenseWebApi1.Context
{
    public interface IImageContext
    {
        Task<bool> IsHave(Guid id);
    }
}
