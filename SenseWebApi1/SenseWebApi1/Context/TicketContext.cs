using MongoDB.Driver;
using SC.Internship.Common.Exceptions;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.Features.TicketFeature;
using SenseWebApi1.MongoDB;

namespace SenseWebApi1.Context
{
    public class TicketContext : ITicketContext
    {
        private readonly IMongoDbContext _databaseContext;
        private readonly IEventContext _eventContext;
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        public TicketContext(IMongoDbContext mongoDbContext,IEventContext eventContext) 
        {
            _databaseContext = mongoDbContext;
            _eventContext = eventContext;
        }
        
        public async Task<List<Ticket>> GetTickets(Guid eventId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            
            var eventObj = await mongoCollection.Find(p => p.EventId==eventId).FirstOrDefaultAsync();

            if (eventObj == null)
            {
                throw new ScException("Такого мероприятия нет");
            }
            else
            {
                var tickets =  eventObj.Tickets;
    
                return tickets!;
            }
            
        }
        public async Task AddFreeTickets(Guid eventId, int countOfTickets)
        {
            
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(p => p.EventId == eventId).FirstOrDefaultAsync();
            if (eventObj != null)
            {
                if (eventObj.IsHavePlaces)
                {
                    var tickets = (await mongoCollection.Find(p => p.EventId == eventId).FirstOrDefaultAsync()).Tickets;
#pragma warning disable CS8604
                    var maxPlace = tickets.Max(p => p.Place);
#pragma warning restore CS8604

                    for (var i = maxPlace; i < maxPlace + countOfTickets; i++)
                    {

                        tickets.Add(
                            new Ticket
                            {
                                TicketId = Guid.NewGuid(),
                                Place = i + 1,
                            });
                    }

                    eventObj.Tickets = tickets;
                }
                else
                {
                    var tickets = (await mongoCollection.Find(p => p.EventId == eventId).FirstOrDefaultAsync()).Tickets;
#pragma warning disable CS8604
                    // ReSharper disable once IdentifierTypo
                    var maxplace = tickets.Max(p => p.Place);
#pragma warning restore CS8604

                    for (var i = maxplace; i < maxplace + countOfTickets; i++)
                    {

                        tickets.Add(
                            new Ticket
                            {
                                TicketId = Guid.NewGuid()
                            });
                    }

                    eventObj.Tickets = tickets;
                }
            

            }
            else
            {
                throw new ScException("Такого мерприятия нет");
            }


            await _eventContext.UpdateEvent(eventObj);
            
        }

        public async Task<bool> CheckTicketForUser(Guid userId, Guid eventId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(p=>p.EventId==eventId).FirstOrDefaultAsync();
#pragma warning disable CS8604
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            return eventObj?.Tickets.Where(p => p.OwnerId == userId) != null;
#pragma warning restore CS8604


        }

        public async Task GiveTicketForUser(Guid userId, Guid ticketId,int? place)
        {
            var filterForSearch = Builders<Event>.Filter.ElemMatch(p => p.Tickets, t => t.TicketId == ticketId);
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(filterForSearch).FirstOrDefaultAsync();
#pragma warning disable CS8604
            var ticket = eventObj.Tickets.FirstOrDefault(p => p.OwnerId == userId);
            if (ticket != null)
            {
                ticket.OwnerId = userId;
                ticket.Place = place;
#pragma warning restore CS8604
                 await _eventContext.UpdateEvent(eventObj);
            }
            else
            {
                throw new ScException("Такой билет не найден");
            }
        }

        public async Task<bool> TicketHave(Guid ticketId)
        {
            var filterForSearch = Builders<Event>.Filter.ElemMatch(p => p.Tickets, t => t.TicketId == ticketId);
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Event>("Events");
            var eventObj = await mongoCollection.Find(filterForSearch).FirstOrDefaultAsync();
#pragma warning disable CS8604
            var ticket = eventObj.Tickets.FirstOrDefault(p => p.TicketId == ticketId);
#pragma warning restore CS8604
            return ticket != null;
        }

        public async Task<bool> UserHaveTicket(Guid userId, Guid ticketId)
        {
            var mongoCollection = _databaseContext.GetMongoDatabase().GetCollection<Ticket>("Tickets");
            var ticket = await mongoCollection.Find(p => p.OwnerId == userId&&p.TicketId==ticketId).FirstOrDefaultAsync();
            return ticket != null;
        }
    }
}
