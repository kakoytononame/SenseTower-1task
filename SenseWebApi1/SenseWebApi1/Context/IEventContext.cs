
using SenseWebApi1.Features.TicketFeature;
using SenseWebApi1.Features.EventFeature;
using static System.Net.Mime.MediaTypeNames;

namespace SenseWebApi1.Context
{
    public interface IEventContext
    {
        Task<List<Event>> GetEvents();
        Task AddEvent(Event @event);
        Task RemoveEvent(Guid id);
        Task UpdateEvent(Event @event);

        Task<bool> HaveEvent(Guid eventId);
    }
}
