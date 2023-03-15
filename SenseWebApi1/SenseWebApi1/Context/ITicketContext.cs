using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public interface ITicketContext
    {
        void AddFreeTicket(TicketDto ticketdto);
        bool UserHaveTicket(Guid userId, Guid ticketId);
    }
}
