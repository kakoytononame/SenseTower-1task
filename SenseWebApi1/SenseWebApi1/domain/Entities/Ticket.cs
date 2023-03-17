namespace SenseWebApi1.domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        public Guid ?OwnerId { get; set; }

        public string ?Place { get; set; }

        public Guid EventId { get; set; }
    }
}
