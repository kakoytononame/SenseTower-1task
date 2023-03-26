

namespace SenseWebApi1.Context
{
    public interface IAreaContext
    {
        Task<bool> IsHave(Guid id);
    }
}
