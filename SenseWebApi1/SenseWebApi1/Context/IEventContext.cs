
using SenseWebApi1.domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SenseWebApi1.Context
{
    public interface IEventContext
    {
        List<Event> GetEvents();
        void AddEvent(Event @event);
        void RemoveEvent(Guid id);
        void UpdateEvent(Event @event);
    }
}
