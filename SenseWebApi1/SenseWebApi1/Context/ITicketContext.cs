
using SenseWebApi1.Features.TicketFeature;

namespace SenseWebApi1.Context
{
    public interface ITicketContext
    {
        Task AddTickets(Guid eventId,int countOfTickets);
        Task<bool> UserHaveTicket(Guid userId, Guid ticketId);
        Task GiveTicketForUser(Guid userId, Guid ticketId);

        Task<bool> CheckTicketForUser(Guid userId,Guid eventId);

        Task<bool> TicketHave(Guid ticketId);

        Task<List<Ticket>> GetTickets(Guid eventId);

        Task<Ticket> SellTicketForUser(Guid userId, Guid ticketId);
    }
}
