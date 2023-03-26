
using SenseWebApi1.Features.EventFeature;


namespace SenseWebApi1.Context
{
    public interface IEventContext
    {
        Task<List<Event>> GetEvents();
        Task AddEvent(Event @event);
        Task RemoveEvent(Guid id);
        Task UpdateEvent(Event @event);

        Task<bool> HaveEvent(Guid eventId);

        Task<bool> CheckPlaceForEvent(Guid eventId,int place);

        Task UpdateEventForImage(Guid imageId);

        Task DeleteEventForSpace(Guid spaceId);
    }
}
