using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Stubs
{
    public class EventContext : IEventContext
    {
        private List<Event> Events=new List<Event>();

        public EventContext()
        {
            Events.Add(new Event()
            {
                EventId = Guid.NewGuid(),
                EventName = "Name 1",
                Beginning = DateTime.Now,
                End = DateTime.Now,
                AreaId = Guid.NewGuid(),
                ImageId = Guid.NewGuid(),
                Description = "Desc 1"
            });
            Events.Add(new Event()
            {
                EventId = Guid.NewGuid(),
                EventName = "Name 2",
                Beginning = DateTime.Now,
                End = DateTime.Now,
                AreaId = Guid.NewGuid(),
                ImageId = Guid.NewGuid(),
                Description = "Desc 2"
            });
            Events.Add(new Event()
            {
                EventId = Guid.NewGuid(),
                EventName = "Name 3",
                Beginning = DateTime.Now,
                End = DateTime.Now,
                AreaId = Guid.NewGuid(),
                ImageId = Guid.NewGuid(),
                Description = "Desc 3"
            });
        }
        public List<Event> GetEvents()
        {
            
            return Events;
            
        }
        public void AddEvent(Event @event)
        {
            Events.Add(@event);
        }

        public void RemoveEvent(Guid id)
        {
            Event ?deletobject=Events.Where(p => p.EventId == id).FirstOrDefault();
            Events.Remove(deletobject!);
        }

        public void UpdateEvent(Event @event)
        {
            Event ?updateobject= Events.Where(p => p.EventId == @event.EventId).FirstOrDefault();
            updateobject.EventName = @event.EventName;
            updateobject.Beginning = @event.Beginning;
            updateobject.End = @event.End;
            updateobject.AreaId = @event.AreaId;
            updateobject.Description = @event.Description;
            updateobject.ImageId = @event.ImageId;
        }
    }
}
