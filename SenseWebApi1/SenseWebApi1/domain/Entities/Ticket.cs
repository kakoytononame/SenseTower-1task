namespace SenseWebApi1.domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }

        public Guid ?OwnerId { get; set; }

        public Guid AreaId { get; set; }
    }
}
