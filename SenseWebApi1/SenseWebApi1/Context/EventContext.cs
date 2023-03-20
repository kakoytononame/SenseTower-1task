
using MongoDB.Driver;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.MongoDB;


namespace SenseWebApi1.Context
{
    public class EventContext : IEventContext
    {
        
        private readonly IMongoDbContext _databaseContext;

        public EventContext(IMongoDbContext databaseContext)
        {
            _databaseContext = databaseContext;

            databaseContext.EventIniz();
            
        }
        public async Task<List<Event>> GetEvents()
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventsCollection = await mongoCollection.Find(_ => true).ToListAsync();
            return eventsCollection;
            
        }
        public async Task AddEvent(Event @event)
        {           
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            await mongoCollection.InsertOneAsync(@event);
        }

        public async Task RemoveEvent(Guid id)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            await mongoCollection.DeleteOneAsync(p => p.EventId == id);
        }

        public async Task UpdateEvent(Event @event)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var filter = Builders<Event>.Filter
                .Where(p=>p.EventId==@event.EventId);
            if (@event.Tickets != null)
            {
                var updatewittick = Builders<Event>.Update
                    
                    .Set(p => p.Beginning, @event.Beginning)
                    .Set(p => p.End, @event.End)
                    .Set(p => p.AreaId, @event.AreaId)
                    .Set(p => p.Description, @event.Description)
                    .Set(p => p.ImageId, @event.ImageId)
                    .Set(p => p.Tickets, @event.Tickets)
                    .Set(p => p.IsHavePlaces, @event.IsHavePlaces);
                await mongoCollection.UpdateOneAsync(filter, updatewittick);
            }
            else
            {
                var update = Builders<Event>.Update
                    
                    .Set(p => p.Beginning, @event.Beginning)
                    .Set(p => p.End, @event.End)
                    .Set(p => p.AreaId, @event.AreaId)
                    .Set(p => p.Description, @event.Description)
                    .Set(p => p.ImageId, @event.ImageId)
                    .Set(p => p.IsHavePlaces, @event.IsHavePlaces);
                await mongoCollection.UpdateOneAsync(filter, update);
            }
            
           
        }

        public async Task<bool> HaveEvent(Guid eventId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(p => p.EventId == eventId).FirstOrDefaultAsync();
            return eventObj != null;
        }

        public async Task<bool> CheckPlaceForEvent(Guid eventId,int place)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(p => p.EventId == eventId).FirstOrDefaultAsync();
            var placeObj = eventObj.Tickets.FirstOrDefault(p=>p.Place==place);
            return placeObj != null;
        }
    }
}
