using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using SC.Internship.Common.Exceptions;
using SenseWebApi1.Features.TicketFeature;
using SenseWebApi1.MongoDB;

namespace SenseWebApi1.Context
{
    public class TicketContext : ITicketContext
    {
        private readonly IMongoDbContext _databaseContext;

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Ticket> _tickets=new List<Ticket>();
        public TicketContext(IMongoDbContext mongoDbContext) 
        {
            _databaseContext = mongoDbContext;
        }
        
        public async Task<List<Ticket>> GetTickets(Guid eventId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            
            var eventsCollection = await mongoCollection.Find(p => p.EventId==eventId).ToListAsync();

            return eventsCollection;
        }
        public async Task AddFreeTickets(Guid eventId, int countOfTickets)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            
            for (var i = 0; i < countOfTickets; i++)
            {
                _tickets.Add(
                new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    EventId=eventId
                });
            }
            await mongoCollection.InsertManyAsync(_tickets);
        }

        public async Task<bool> CheckTicketForUser(Guid userId, Guid eventId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            var eventsCollection = await mongoCollection.Find(_ => true).ToListAsync();
            var ticket = eventsCollection.FirstOrDefault(p => p.OwnerId == userId && p.EventId == eventId);
            return ticket != null;
        }

        public async Task GiveTicketForUser(Guid userId, Guid ticketId,string? place)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            var ticket = await mongoCollection.Find(p => p.TicketId == ticketId).FirstOrDefaultAsync();
            if (ticket != null)
            {
                ticket.OwnerId = userId;
                var filter = Builders<Ticket>.Filter
                .Where(p => p.TicketId == ticketId);
                var update = Builders<Ticket>.Update
                    .Set(p => p.TicketId, ticketId)
                    .Set(p => p.Place, place)
                    .Set(p => p.OwnerId, userId);
                    
                
                var personUpdateResult = await mongoCollection.UpdateOneAsync(filter, update);
            }
            else
            {
                
                
                throw new ScException("Такой билет не найден");
            }
        }

        public async Task<bool> TicketHave(Guid ticketId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            var eventObj = await mongoCollection.Find(p => p.TicketId == ticketId).FirstOrDefaultAsync();
            return eventObj != null;
        }

        public async Task<bool> UserHaveTicket(Guid userId, Guid ticketId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            var ticket = await mongoCollection.Find(p => p.OwnerId == userId&&p.TicketId==ticketId).FirstOrDefaultAsync();
            return ticket != null;
        }
    }
}
