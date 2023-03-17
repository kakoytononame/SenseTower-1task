using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public interface ITicketContext
    {
        void AddFreeTickets(Guid EventId,int CountOfTickets);
        bool UserHaveTicket(Guid userId, Guid ticketId);
        void GiveTicketForUser(Guid userId, Guid ticketId);

        bool CheckTicketForUser(Guid userId,Guid EventId);

        bool TicketHave(Guid ticketId);
    }
}
