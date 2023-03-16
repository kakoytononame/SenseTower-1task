namespace SenseWebApi1.domain.Dtos
{
    public class TicketDto
    {
        public Guid TicketId { get; set; }

        public Guid EventId { get; set; }

        public Guid AreaId { get; set; }

        public string Place { get; set; }
    }
}
