using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public class TicketContext : ITicketContext
    {
        private List<Ticket> Tickets=new List<Ticket>();
        public TicketContext() 
        {
            Tickets.Add(
                new Ticket
                {
                    TicketId=Guid.Parse("7676ce96-417d-4214-9382-3eb46b4f86e3"),
                    AreaId=Guid.Parse("aaf2c1b9-6372-44bc-b0e4-1251b914c2dd"),
                    OwnerId=Guid.Parse("d04a76aa-2f20-4af9-a39e-427623323374")
                }
            );
            Tickets.Add(
                new Ticket
                {
                    TicketId = Guid.Parse("b15624ea-9cc3-42d4-a6a5-15c4e6697f4c"),
                    AreaId = Guid.Parse("53eaf4f5-b005-4eb1-a030-96205cbd9a89"),
                    OwnerId = Guid.Parse("da2a7240-8fbb-48eb-bdcb-cc154593587f")
                }
            );
        }
        public void AddFreeTicket(TicketDto ticketdto)
        {
            Tickets.Add(
                new Ticket
                {
                    TicketId = ticketdto.TicketId,
                    AreaId = ticketdto.AreaId,
                    OwnerId = ticketdto.OwnerId
                });
        }

        public bool UserHaveTicket(Guid userId, Guid ticketId)
        {
            var ticket = Tickets.Where(p => p.OwnerId == userId).FirstOrDefault();
            if (ticket == null)
            {
                return false;
            }
            return true;

        }
    }
}
