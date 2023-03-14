using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public class EventContext : IEventContext
    {
        private List<Event> Events=new List<Event>();
        
        public EventContext()
        {
            Events.Add(new Event()
            {
                EventId = Guid.Parse("4e1d7548-5605-455b-94a5-c18c4f1e9a4f"),
                EventName = "Name 1",
                Beginning = DateTime.Now,
                End = DateTime.Now,
                AreaId = Guid.Parse("aaf2c1b9-6372-44bc-b0e4-1251b914c2dd"),
                ImageId = Guid.Parse("074a2eb2-4b45-4ac8-88ac-12b5dc52b252"),
                Description = "Desc 1"
            });
            Events.Add(new Event()
            {
                EventId = Guid.Parse("454184a3-1be7-4738-9a01-ffe48a04f200"),
                EventName = "Name 2",
                Beginning = DateTime.Now,
                End = DateTime.Now,
                AreaId = Guid.Parse("53eaf4f5-b005-4eb1-a030-96205cbd9a89"),
                ImageId = Guid.Parse("9f4813cd-6d37-4393-b7ce-f2cc2c81ef3b"),
                Description = "Desc 2"
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
