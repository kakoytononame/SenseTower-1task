using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Stubs
{
    public interface IAreaContext
    {
        List<Area> GetAreas();
        bool IsHave(Guid id);
    }
}
