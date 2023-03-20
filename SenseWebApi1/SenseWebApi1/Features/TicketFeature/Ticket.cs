using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SenseWebApi1.Features.TicketFeature
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public Guid TicketId { get; set; }

        public Guid? OwnerId { get; set; }

        public int? Place { get; set; }

        
    }
}
