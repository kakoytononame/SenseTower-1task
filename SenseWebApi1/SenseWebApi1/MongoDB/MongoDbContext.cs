using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.Features.TicketFeature;

namespace SenseWebApi1.MongoDB
{
    public class MongoDbContext:IMongoDbContext
    {

        
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            
            _database = client.GetDatabase(settings.Value.Database);
            
        }

        public IMongoDatabase GetMongoDatabase()
        {
            return _database;
        }

        public async Task EventIniz()
        {
            var mongoCollection = GetMongoDatabase().GetCollection<Event>("Events");
            List<Event> events = new List<Event>()
            {
                new Event
                {
                    EventName = "Event-1",
                    Description = "Какое то мероприятие 1",
                    EventId = Guid.Parse("491d776d-523a-4afa-9b36-a1c46fa126da"),
                    Beginning = DateTime.Parse("2023-03-13T17:10:17.5776731+03:00"),
                    End = DateTime.Parse("2023-03-13T20:10:17.5776731+03:00"),
                    AreaId = Guid.Parse("40880975-cf39-4674-ba22-511a38a158fb"),
                    ImageId = Guid.Parse("bda59f4e-c60b-411b-87e5-61a73125979b"),
                    IsHavePlaces = true,
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            TicketId = Guid.NewGuid(),
                            Place = 1,
                            OwnerId = Guid.NewGuid()
                        },
                        new Ticket()
                        {
                            TicketId = Guid.NewGuid(),
                            Place = 2,
                            OwnerId = Guid.NewGuid()
                        },
                        new Ticket()
                        {
                            TicketId = Guid.NewGuid(),
                            Place = 3,
                            OwnerId = Guid.NewGuid()
                        }
                        
                    }
                },
                new Event
                {
                    EventName = "Event-2",
                    Description = "Какое то мероприятие 2",
                    EventId = Guid.Parse("799b539a-763f-4ce7-b485-850df7ff6cc1"),
                    Beginning = DateTime.Parse("2023-03-14T17:10:17.5776731+03:00"),
                    End = DateTime.Parse("2023-03-14T20:10:17.5776731+03:00"),
                    AreaId = Guid.Parse("ec747803-890d-4ce4-8958-64cfea4e77a7"),
                    ImageId = Guid.Parse("ccd50edc-a02f-48a8-8ae8-70b47dd087d8"),
                    IsHavePlaces = false,
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            TicketId = Guid.NewGuid(),
                            OwnerId = Guid.NewGuid()
                        },
                        new Ticket()
                        {
                            TicketId = Guid.NewGuid(),
                            OwnerId = Guid.NewGuid()
                        }
                    }
                }
                
            };
            if (mongoCollection.CountDocuments(Builders<Event>.Filter.Where(p => true)) == 0)
            {
                await mongoCollection.InsertManyAsync(events);
            }

        }
        /*public async Task TicketIniz()
        {
            var mongoCollection = GetMongoDatabase().GetCollection<Ticket>("Tickets");
            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    TicketId = Guid.NewGuid(),
                    Place = "1",
                    OwnerId = Guid.NewGuid()
                },
                new Ticket()
                {
                    TicketId = Guid.NewGuid(),
                    Place = "2",
                    OwnerId = Guid.NewGuid()
                },
                new Ticket()
                {
                    TicketId = Guid.NewGuid(),
                    EventId = Guid.Parse("491d776d-523a-4afa-9b36-a1c46fa126da"),
                    Place = "3",
                    OwnerId = Guid.NewGuid()
                }
            };
            if (mongoCollection.CountDocuments(Builders<Ticket>.Filter.Where(p => true)) == 0)
            {
                await mongoCollection.InsertManyAsync(tickets);
            }
            
        }*/
    }
}
