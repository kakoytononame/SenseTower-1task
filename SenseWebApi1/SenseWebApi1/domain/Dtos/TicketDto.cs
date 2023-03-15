namespace SenseWebApi1.domain.Dtos
{
    public class TicketDto
    {
        public Guid TicketId { get; set; }

        public Guid OwnerId { get; set; }

        public Guid AreaId { get; set; }
    }
}
